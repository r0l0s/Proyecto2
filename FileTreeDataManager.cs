using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Proyecto.FamilyTreeSpace
{
    public sealed class FileTreeDataManager : ITreeDataManager
    {
        public void SaveTree(FamilyTree tree, string path)
        {
            var all = tree.GetAllMembers();

            var dto = new TreeDto
            {
                Persons = new List<PersonDto>(),
                Parents = new List<ParentDto>()
            };

            foreach (var p in all)
            {
                dto.Persons.Add(new PersonDto
                {
                    ID = p.ID,
                    Name = p.Name,
                    BirthDate = p.BirthDate,
                    IsAlive = p.IsAlive,
                    PhotoPath = p.PhotoPath,
                    Latitude = p.Latitude,
                    Longitude = p.Longitude
                });
            }

            File.WriteAllText(path, JsonSerializer.Serialize(dto, new JsonSerializerOptions
            {
                WriteIndented = true
            }));
        }
        public void ExportToJson(FamilyTree tree, string filePath)
        {
            SaveTree(tree, filePath);
        }
        public FamilyTree LoadTree(string path)
        {
            var dto = JsonSerializer.Deserialize<TreeDto>(File.ReadAllText(path));

            var tree = new FamilyTree();
            if (dto.Persons.Count == 0)
                return tree;

            // Primera persona como raíz
            var root = dto.Persons[0];
            tree.AddRoot(new Person(root.ID, root.Name, root.BirthDate, root.IsAlive, root.PhotoPath, root.Latitude, root.Longitude));

            return tree;
        }
        

        private class TreeDto
        {
            public List<PersonDto> Persons { get; set; }
            public List<ParentDto> Parents { get; set; }
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
    }
}
