using System;

namespace GraphTests
{
    public class FamilyMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        
        public FamilyMember(int id, string name, double lat, double lon)
        {
            Id = id;
            Name = name;
            Latitude = lat;
            Longitude = lon;
        }
        
        public override string ToString()
        {
            return $"{Name} (ID: {Id}) - Lat: {Latitude:F6}, Lon: {Longitude:F6}";
        }
    }
}