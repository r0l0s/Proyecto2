using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto.FamilyTreeSpace
{
    public sealed class FamilyTree
    {
        private FamilyTreeNode _root;
        private readonly Dictionary<string, FamilyTreeNode> _index = new();

        public bool HasRoot => _root != null;

        private FamilyTreeNode Get(string id)
        {
            if (!_index.ContainsKey(id))
                throw new Exception("No existe persona con ID: " + id);

            return _index[id];
        }

        private bool AgeOK(Person parent, Person child)
        {
            int age = child.BirthDate.Year - parent.BirthDate.Year;
            return age >= 18;
        }
        // Helper: obtener nodo existente o crear uno e indexarlo
        private FamilyTreeNode GetOrCreateNode(Person person)
        {
            if (_index.TryGetValue(person.ID, out var existing)) return existing;
            var node = new FamilyTreeNode(person);
            _index[person.ID] = node;
            return node;
        }

        public void AddRoot(Person p)
        {
            if (_root != null)
                throw new Exception("Ya existe una raíz.");

            var node = GetOrCreateNode(p);  // <-- Esta es la corrección
            _root = node;
        }


        public IEnumerable<Person> GetAllMembers()
        {
            if (_root == null) 
                return Enumerable.Empty<Person>();

            var visited = new HashSet<FamilyTreeNode>();
            return _root.TraverseAll(visited).Select(n => n.Data);
        }

        public void AddSpouse(string personId, Person spouse)
        {
            var p = Get(personId);

            if (p.Spouses.Count > 0)
                throw new Exception("Esta persona ya tiene esposo(a).");

            var spouseNode = GetOrCreateNode(spouse);


            p.AddSpouse(spouseNode);
        }

        public void AddChildToFather(string fatherId, Person child)
        {
            var father = Get(fatherId);

            if (!AgeOK(father.Data, child))
                throw new Exception("No tiene edad para ser padre.");

            var childNode = GetOrCreateNode(child);

            if (childNode.Father != null)
                throw new Exception("El hijo ya tiene padre.");

            childNode.SetFather(father);
            father.AddChild(childNode);
        }

        public void AddChildToMother(string motherId, Person child)
        {
            var mother = Get(motherId);

            if (!AgeOK(mother.Data, child))
                throw new Exception("No tiene edad para ser madre.");

            var childNode = GetOrCreateNode(child);

            if (childNode.Mother != null)
                throw new Exception("El hijo ya tiene madre.");

            childNode.SetMother(mother);
            mother.AddChild(childNode);
        }

        public void AssignFather(string childId, Person fatherPerson)
        {
            var child = Get(childId);

            if (child.Father != null)
                throw new Exception("El hijo ya tiene padre.");

            if (!AgeOK(fatherPerson, child.Data))
                throw new Exception("Edad no válida.");

            var father = GetOrCreateNode(fatherPerson);

            child.SetFather(father);
            father.AddChild(child);
        }

        public void AssignMother(string childId, Person motherPerson)
        {
            var child = Get(childId);

            if (child.Mother != null)
                throw new Exception("El hijo ya tiene madre.");

            if (!AgeOK(motherPerson, child.Data))
                throw new Exception("Edad no válida.");

            var mother = GetOrCreateNode(motherPerson);

            child.SetMother(mother);
            mother.AddChild(child);
        }

    }
}
