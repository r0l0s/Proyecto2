using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto.FamilyTree
{
    internal sealed class FamilyTreeNode
    {
        internal Person Data { get; }
        internal FamilyTreeNode Mother { get; private set; }
        internal FamilyTreeNode Father { get; private set; }

        private readonly List<FamilyTreeNode> _children = new();
        private readonly List<FamilyTreeNode> _spouses = new();

        internal IReadOnlyList<FamilyTreeNode> Children => _children.AsReadOnly();
        internal IReadOnlyList<FamilyTreeNode> Spouses => _spouses.AsReadOnly();

        internal FamilyTreeNode(Person person)
        {
            Data = person ?? throw new ArgumentNullException(nameof(person));
        }

        internal void SetMother(FamilyTreeNode mother)
        {
            if (mother == null) return;
            if (ReferenceEquals(mother, this)) throw new InvalidOperationException();
            if (CreatesCycle(mother)) throw new InvalidOperationException();
            Mother = mother;
            if (!mother._children.Contains(this)) mother._children.Add(this);
        }

        internal void SetFather(FamilyTreeNode father)
        {
            if (father == null) return;
            if (ReferenceEquals(father, this)) throw new InvalidOperationException();
            if (CreatesCycle(father)) throw new InvalidOperationException();
            Father = father;
            if (!father._children.Contains(this)) father._children.Add(this);
        }

        internal void AddSpouse(FamilyTreeNode spouse)
        {
            if (spouse == null) return;
            if (ReferenceEquals(spouse, this)) throw new InvalidOperationException();
            if (!_spouses.Contains(spouse)) _spouses.Add(spouse);
            if (!spouse._spouses.Contains(this)) spouse._spouses.Add(this);
        }

        internal bool RemoveSpouse(FamilyTreeNode spouse)
        {
            if (spouse == null) return false;
            bool removed = _spouses.Remove(spouse);
            if (removed) spouse._spouses.Remove(this);
            return removed;
        }

        internal FamilyTreeNode FindNode(string id)
        {
            if (Data.ID == id) return this;

            foreach (var c in _children)
            {
                var f = c.FindNode(id);
                if (f != null) return f;
            }

            foreach (var s in _spouses)
            {
                if (s.Data.ID == id) return s;
            }

            return null;
        }

        internal IEnumerable<FamilyTreeNode> GetAllNodes()
        {
            var visited = new HashSet<FamilyTreeNode>();
            return Traverse(this, visited);
        }

        private IEnumerable<FamilyTreeNode> Traverse(FamilyTreeNode node, HashSet<FamilyTreeNode> visited)
        {
            if (!visited.Add(node)) yield break;

            yield return node;

            if (node.Mother != null) foreach (var x in Traverse(node.Mother, visited)) yield return x;
            if (node.Father != null) foreach (var x in Traverse(node.Father, visited)) yield return x;

            foreach (var c in node._children)
                foreach (var x in Traverse(c, visited))
                    yield return x;

            foreach (var s in node._spouses)
                foreach (var x in Traverse(s, visited))
                    yield return x;
        }

        private bool CreatesCycle(FamilyTreeNode candidate)
        {
            var visited = new HashSet<FamilyTreeNode>();
            return HasPath(candidate, this, visited);
        }

        private bool HasPath(FamilyTreeNode start, FamilyTreeNode target, HashSet<FamilyTreeNode> visited)
        {
            if (start == null) return false;
            if (ReferenceEquals(start, target)) return true;
            if (!visited.Add(start)) return false;

            return HasPath(start.Mother, target, visited)
                || HasPath(start.Father, target, visited)
                || start._children.Any(c => HasPath(c, target, visited));
        }
    }
}

