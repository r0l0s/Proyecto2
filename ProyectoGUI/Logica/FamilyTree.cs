using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoGUI.Logica
{
    public class FamilyTree
    {
        public string FamilyName { get; private set; }
        public FamilyMember? Root = null;
        public Dictionary<string, FamilyMember> Members = new Dictionary<string, FamilyMember>();

        public FamilyTree(string familyName)
        {
            FamilyName = familyName;
        }

        public void AddRoot(FamilyMember Adam)
        {
            Root = Adam;
            Members.Add(Root.Name, Root);
        }


        public List<string> GetPossibleParents()
        {
            List<string> Parents = new List<string>();
            foreach(var suitor in Members)
            {
                if (suitor.Value.IsAlive && suitor.Value.Age > 18)
                {
                    Parents.Add(suitor.Key);
                }
                    
            }
            return Parents;
        }
    }
}
