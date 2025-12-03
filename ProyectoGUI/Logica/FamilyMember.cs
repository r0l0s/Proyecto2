using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoGUI.Logica
{
    public class FamilyMember
    {
        public string Family { get; private set; }
        public string Name { get; private set; }
        public DateTime? DateOfBirth { get; private set; }
        public int Age { get; private set; }
        public (double Latitude, double Longitude) Location { get; private set; }
        public string ID { get; private set; }
        public string PhotoPath { get; private set; }
        public bool IsAlive { get; private set; }
        public DateTime? DateOfDeath { get; private set; }

        public List<FamilyMember> Children = new List<FamilyMember>();
        

        public FamilyMember(
            string family,
            string name,
            DateTime? dateOfBirth,
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
            DateOfBirth = dateOfBirth;
            Age = age;
            Location = location;
            ID = id;
            PhotoPath = photoPath;
            IsAlive = isAlive;
            DateOfDeath = dateOfDeath;
        }


    }
}
