using System;

namespace Proyecto.FamilyTree
{
    public sealed class Person
    {
        private string _name;
        private string _id;
        private DateTime _birthDate;
        private bool _isAlive;
        private string _photoPath;
        private double _latitude;
        private double _longitude;

        public string Name => _name;
        public string ID => _id;
        public DateTime BirthDate => _birthDate;
        public bool IsAlive => _isAlive;
        public string PhotoPath => _photoPath;
        public double Latitude => _latitude;
        public double Longitude => _longitude;

        public int Age
        {
            get
            {
                DateTime asOf = DateTime.UtcNow.Date;
                int age = asOf.Year - _birthDate.Year;
                if (_birthDate > asOf.AddYears(-age)) age--;
                return age;
            }
        }

        public Person(string id, string name, DateTime birthDate, bool isAlive = true, string photoPath = null, double latitude = 0, double longitude = 0)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("ID required", nameof(id));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name required", nameof(name));

            _id = id;
            _name = name;
            _birthDate = birthDate.Date;
            _isAlive = isAlive;
            _photoPath = photoPath;
            _latitude = latitude;
            _longitude = longitude;
        }

        public void UpdateLocation(double latitude, double longitude)
        {
            if (double.IsNaN(latitude) || double.IsNaN(longitude)) throw new ArgumentException("Invalid coordinates");
            _latitude = latitude;
            _longitude = longitude;
        }

        public void UpdatePhoto(string path)
        {
            _photoPath = path;
        }

        public void MarkDeceased()
        {
            _isAlive = false;
        }

        public string GetFullInfo()
        {
            return $"{_name} ({_id}) - Born: {_birthDate:yyyy-MM-dd} - Age: {Age} - Alive: {_isAlive}";
        }
    }
}
