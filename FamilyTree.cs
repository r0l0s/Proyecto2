using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto.FamilyTree
{
    public sealed class FamilyTree
    {
        private FamilyTreeNode _root;
        private readonly Dictionary<string, FamilyTreeNode> _index = new(StringComparer.Ordinal);

        public bool HasRoot => _root != null;

        public IEnumerable<Person> GetAllMembers()
        {
            if (_root == null) return Enumerable.Empty<Person>();
            return _root.GetAllNodes().Select(n => n.Data);
        }

        public void AddRoot(Person person)
        {
            if (_root != null) throw new InvalidOperationException();
            var node = new FamilyTreeNode(person);
            _root = node;
            _index[person.ID] = node;
        }

        public void AddMember(Person person, string motherId = null, string fatherId = null, string spouseId = null)
        {
            if (person == null) throw new ArgumentNullException(nameof(person));
            if (_index.ContainsKey(person.ID)) throw new InvalidOperationException();

            if (_root == null)
            {
                AddRoot(person);
                return;
            }

            var newNode = new FamilyTreeNode(person);

            FamilyTreeNode mother = null;
            FamilyTreeNode father = null;
            FamilyTreeNode spouse = null;

            if (!string.IsNullOrWhiteSpace(motherId))
            {
                if (!_index.TryGetValue(motherId, out mother)) mother = FindInternal(motherId);
                if (mother == null) throw new InvalidOperationException();
                if (!AgeCoherent(mother.Data, person)) throw new InvalidOperationException();
            }

            if (!string.IsNullOrWhiteSpace(fatherId))
            {
                if (!_index.TryGetValue(fatherId, out father)) father = FindInternal(fatherId);
                if (father == null) throw new InvalidOperationException();
                if (!AgeCoherent(father.Data, person)) throw new InvalidOperationException();
            }

            if (mother != null) newNode.SetMother(mother);
            if (father != null) newNode.SetFather(father);

            if (!string.IsNullOrWhiteSpace(spouseId))
            {
                if (!_index.TryGetValue(spouseId, out spouse)) spouse = FindInternal(spouseId);
                if (spouse == null) throw new InvalidOperationException();
                newNode.AddSpouse(spouse);
            }

            if (mother == null && father == null && spouse == null)
            {
                newNode.SetMother(_root);
            }

            _index[person.ID] = newNode;
        }

        private FamilyTreeNode FindInternal(string id)
        {
            if (_index.TryGetValue(id, out var n)) return n;
            if (_root == null) return null;
            var f = _root.FindNode(id);
            if (f != null) _index[id] = f;
            return f;
        }

        private bool AgeCoherent(Person parent, Person child)
        {
            int minAge = 12;
            int ageAtBirth = child.BirthDate.Year - parent.BirthDate.Year;
            if (child.BirthDate < parent.BirthDate) return false;
            return ageAtBirth >= minAge;
        }

        internal FamilyTreeNode GetRootInternal() => _root;

        internal void SetRootInternal(FamilyTreeNode node)
        {
            _root = node;
            _index.Clear();
            foreach (var n in _root.GetAllNodes().Distinct())
                _index[n.Data.ID] = n;
        }
    }
}
