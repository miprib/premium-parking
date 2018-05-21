using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PremiumParking.ParkingSystemBack
{
    public class Camera : IEquatable<Camera>
    {
        public int Id { get; set; }
        public Console Test;

        public Camera(Console console, int id)
        {
            Test = console;
            Id = id;
        }

        public void In(string license)
        {
            Test.CarIn(license, Id);
        }

        public void Out(string license)
        {
            Test.CarOut(license, Id);
        }

        public bool Equals(Camera other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Test, other.Test) && Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Camera) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Test != null ? Test.GetHashCode() : 0) * 397) ^ Id;
            }
        }
    }
}
