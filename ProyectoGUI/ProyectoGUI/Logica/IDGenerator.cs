using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Text;

namespace ProyectoGUI.Logica
{
    struct MemberDetails
    {
        public string Nombre;
        public int Edad;
        public (double Latitude, double Longitude) Ubicacion;
        public int[] Cedula;
        public string Foto;

        public MemberDetails()
        {
            Nombre = "";
            Edad = 0;
            Ubicacion = (9.855270259973693, -83.90901312232018);
            Cedula = new int[9];
            Foto = "";
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
