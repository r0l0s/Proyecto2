using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoGUI.Logica
{
    class FamilyMember
    {
        public string Family { get; private set; }
        public string Name { get; private set; }
        public DateTime DateoOfBirth { get; private set; }
        public int Age { get; private set; }
        public (double Latitude, double Longitude) Location { get; private set; }
        public string ID { get; private set; }
        public string PhotoPath { get; private set; }
        public bool IsAlive { get; private set; }
        public DateTime? DateOfDeath { get; private set; }

        public List<FamilyMember> Children;
        

        public FamilyMember(
            string family,
            string name,
            DateTime dateOfBirth,
            int age,
            (double Latitude, double Longitude) location,
            string id,
            string photoPath,
            bool isAlive,
            DateTime? dateOfDeath
            )
        {
            Family = family;
            Name = name;
            DateoOfBirth = dateOfBirth;
            Age = age;
            Location = location;
            ID = id;
            PhotoPath = photoPath;
            DateOfDeath = dateOfDeath;
            Children = new List<FamilyMember>();
        }


    }
}
