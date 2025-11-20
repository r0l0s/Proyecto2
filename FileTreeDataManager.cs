using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Proyecto.FamilyTree
{
    public sealed class FileTreeDataManager : ITreeDataManager
    {
        public void SaveTree(FamilyTree tree, string filePath)
        {
            var dto = ToDto(tree);
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(filePath, JsonSerializer.Serialize(dto, options));
        }

        public FamilyTree LoadTree(string filePath)
        {
            var dto = JsonSerializer.Deserialize<TreeDto>(File.ReadAllText(filePath));
            return FromDto(dto);
        }

        public void ExportToJson(FamilyTree tree, string filePath)
        {
            SaveTree(tree, filePath);
        }

        private TreeDto ToDto(FamilyTree tree)
        {
            var persons = new List<PersonDto>();
            var parents = new List<ParentDto>();
            var spouses = new List<SpouseDto>();

            var root = tree.GetRootInternal();
            if (root == null) return new TreeDto();

            foreach (var n in root.GetAllNodes().Distinct())
            {
                persons.Add(new PersonDto
                {
                    ID = n.Data.ID,
                    Name = n.Data.Name,
                    BirthDate = n.Data.BirthDate,
                    IsAlive = n.Data.IsAlive,
                    PhotoPath = n.Data.PhotoPath,
                    Latitude = n.Data.Latitude,
                    Longitude = n.Data.Longitude
                });

                if (n.Mother != null) parents.Add(new ParentDto { ParentId = n.Mother.Data.ID, ChildId = n.Data.ID, Type = "M" });
                if (n.Father != null) parents.Add(new ParentDto { ParentId = n.Father.Data.ID, ChildId = n.Data.ID, Type = "F" });

                foreach (var s in n.Spouses)
                {
                    if (string.Compare(n.Data.ID, s.Data.ID, StringComparison.Ordinal) < 0)
                        spouses.Add(new SpouseDto { A = n.Data.ID, B = s.Data.ID });
                }
            }

            return new TreeDto { Persons = persons, Parents = parents, Spouses = spouses };
        }

        private FamilyTree FromDto(TreeDto dto)
        {
            var tree = new FamilyTree();
            if (dto.Persons == null || dto.Persons.Count == 0) return tree;

            var map = new Dictionary<string, FamilyTreeNode>();

            foreach (var p in dto.Persons)
            {
                var person = new Person(p.ID, p.Name, p.BirthDate, p.IsAlive, p.PhotoPath, p.Latitude, p.Longitude);
                map[p.ID] = new FamilyTreeNode(person);
            }

            foreach (var rel in dto.Parents)
            {
                if (!map.TryGetValue(rel.ParentId, out var parent)) continue;
                if (!map.TryGetValue(rel.ChildId, out var child)) continue;

                if (rel.Type == "M") child.SetMother(parent);
                if (rel.Type == "F") child.SetFather(parent);
            }

            foreach (var sp in dto.Spouses)
            {
                if (map.TryGetValue(sp.A, out var a) && map.TryGetValue(sp.B, out var b))
                    a.AddSpouse(b);
            }

            tree.SetRootInternal(map.Values.First());
            return tree;
        }

        private class TreeDto
        {
            public List<PersonDto> Persons { get; set; }
            public List<ParentDto> Parents { get; set; }
            public List<SpouseDto> Spouses { get; set; }
        }

        private class PersonDto
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public DateTime BirthDate { get; set; }
            public bool IsAlive { get; set; }
            public string PhotoPath { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }

        private class ParentDto
        {
            public string ParentId { get; set; }
            public string ChildId { get; set; }
            public string Type { get; set; }
        }

        private class SpouseDto
        {
            public string A { get; set; }
            public string B { get; set; }
        }
    }
}

