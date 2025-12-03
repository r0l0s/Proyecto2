using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Text;

namespace ProyectoGUI.Logica
{
    struct MemberDetails
    {
        public string? Parent;
        public string Family;
        public string Name;
        public DateTime? DateOfBirth;
        public int Age;
        public (double Latitude, double Longitude) Location;
        public int[] ID;
        public string PhotoPath;
        public bool isAlive;
        public DateTime? DateOfDeath;

        public MemberDetails()
        {
            Parent = null;
            Family = "";
            Name = "";
            DateOfBirth = null;
            Age = 0;
            Location = (9.855270259973693, -83.90901312232018);
            ID = new int[9];
            PhotoPath = "";
            isAlive = true;
            DateOfDeath = null;
        }
    }
    static class Generator
    {
        public static int[] GenerateID(int Age, double LatValue, double LngValue)
        {
            int[] ID = new int[9];
            int seed = HashCode.Combine(Age, LatValue, LngValue);
         
            Random rnd = new Random(seed);

            for (int ctr = 0; ctr <= 8; ctr++)
                ID[ctr] = rnd.Next(0,10);
            return ID;
        }

        public static int GenerateAge(DateTime DateA, DateTime DateB)
        {
            return DateA.Year - DateB.Year;
        }
    }
}
