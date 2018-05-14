using System;
using System.Collections.Generic;

namespace PremiumParking.ParkingSystemBack
{
    public class Resident : IEquatable<Resident>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LicensePlate { get; set; }
        public string Phone { get; set; }
        public string Apartaments { get; set; }

        public Resident(string name, string surname, string licensePlate, string phone, string apartaments)
        {
            Name = name;
            Surname = surname;
            LicensePlate = licensePlate;
            Phone = phone;
            Apartaments = apartaments;
        }

        public static List<Resident> ResidentsFactory()
        {
            return new List<Resident>()
            {
                new Resident("Simis", "Simutis", "AAA001", "8888", "1"),
                new Resident("a", "a", "AAA002", "888", "2"),
                new Resident("b", "b", "AAA003", "88", "3"),
                new Resident("c", "c", "AAA004", "8", "4"),
                new Resident("d", "d", "AAA005", "88888", "5"),
                new Resident("e", "e", "AAA006", "888888", "6"),
                new Resident("f", "f", "AAA007", "8888888", "7")
            };
        }

        public bool Equals(Resident other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name) && string.Equals(Surname, other.Surname) && string.Equals(LicensePlate, other.LicensePlate) && string.Equals(Phone, other.Phone) && string.Equals(Apartaments, other.Apartaments);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Resident) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Surname != null ? Surname.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LicensePlate != null ? LicensePlate.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Phone != null ? Phone.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Apartaments != null ? Apartaments.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return Name + " " + Surname + " " + LicensePlate + " " + Phone + " " + Apartaments;
        }
    }
}
