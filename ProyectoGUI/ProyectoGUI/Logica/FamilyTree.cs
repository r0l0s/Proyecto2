using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoGUI.Logica
{
    class FamilyTree
    {
        public string FamilyName { get; private set; }
        private FamilyMember? Adam = null;
        public List<FamilyMember> Members;

        public FamilyTree(string familyName)
        {
            FamilyName = familyName;
            Members = new List<FamilyMember>();
        }

        public void AddAdam(FamilyMember FamilyFounder)
        {
            Adam = FamilyFounder;
            Members.Add(Adam);
        }

        public List<FamilyMember> GetPossibleParents()
        {
            List<FamilyMember> Parents = new List<FamilyMember>();
            foreach(var suitor in Members)
            {
                if (suitor.IsAlive && suitor.Age > 18)
                    Parents.Add(suitor);
            }
            return Parents;
        }
    }
}
