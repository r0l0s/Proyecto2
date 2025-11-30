using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto2.FamilyTreeSpace
{
    internal sealed class FamilyTreeNode
    {
        internal Person Data { get; }

        internal FamilyTreeNode? Mother { get; private set; }
        internal FamilyTreeNode? Father { get; private set; }

        private readonly List<FamilyTreeNode> _children = new();
        private readonly List<FamilyTreeNode> _spouses = new();

        internal IReadOnlyList<FamilyTreeNode> Children => _children.AsReadOnly();
        internal IReadOnlyList<FamilyTreeNode> Spouses => _spouses.AsReadOnly();

        internal FamilyTreeNode(Person data)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        internal void SetMother(FamilyTreeNode mother)
        {
            if (mother == null) return;
            if (ReferenceEquals(mother, this)) throw new InvalidOperationException("Un nodo no puede ser su propia madre.");
            if (CreatesCycle(mother)) throw new InvalidOperationException("Se generaría un ciclo en el árbol.");

            Mother = mother;
            if (!mother._children.Contains(this)) mother._children.Add(this);
        }

        internal void SetFather(FamilyTreeNode father)
        {
            if (father == null) return;
            if (ReferenceEquals(father, this)) throw new InvalidOperationException("Un nodo no puede ser su propio padre.");
            if (CreatesCycle(father)) throw new InvalidOperationException("Se generaría un ciclo en el árbol.");

            Father = father;
            if (!father._children.Contains(this)) father._children.Add(this);
        }

        internal void AddChild(FamilyTreeNode child)
        {
            if (child == null) return;
            if (!_children.Contains(child)) _children.Add(child);
        }

        internal void AddSpouse(FamilyTreeNode spouse)
        {
            if (spouse == null) return;
            if (!_spouses.Contains(spouse)) _spouses.Add(spouse);
            if (!spouse._spouses.Contains(this)) spouse._spouses.Add(this);
        }

        internal IEnumerable<FamilyTreeNode> TraverseAll(HashSet<FamilyTreeNode> visited)
        {
            if (!visited.Add(this))
                yield break;

            yield return this;

            if (Mother != null)
                foreach (var m in Mother.TraverseAll(visited))
                    yield return m;

            if (Father != null)
                foreach (var f in Father.TraverseAll(visited))
                    yield return f;

            foreach (var c in _children)
                foreach (var child in c.TraverseAll(visited))
                    yield return child;

            foreach (var s in _spouses)
                foreach (var sp in s.TraverseAll(visited))
                    yield return sp;
        }

       private bool CreatesCycle(FamilyTreeNode candidate)
        {

            return HasPathChildrenOnly(candidate, this, new HashSet<FamilyTreeNode>());
        }

        private bool HasPathChildrenOnly(FamilyTreeNode? start, FamilyTreeNode target, HashSet<FamilyTreeNode> visited)
        {
            if (start == null) return false;
            if (ReferenceEquals(start, target)) return true;
            if (!visited.Add(start)) return false;

            foreach (var c in start._children)
                if (HasPathChildrenOnly(c, target, visited)) return true;

            return false;
        }



        private bool HasPath(FamilyTreeNode? start, FamilyTreeNode target, HashSet<FamilyTreeNode> visited)
        {
            if (start == null) return false;
            if (ReferenceEquals(start, target)) return true;
            if (!visited.Add(start)) return false;

            if (HasPath(start.Mother, target, visited)) return true;
            if (HasPath(start.Father, target, visited)) return true;

            foreach (var c in start._children)
                if (HasPath(c, target, visited)) return true;

            // ❌ NO incluir esposos aquí
            // foreach (var s in start._spouses)
            //     if (HasPath(s, target, visited)) return true;

            return false;
        }
    }
}
