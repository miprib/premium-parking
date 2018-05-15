using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PremiumParking.ParkingSystemBack
{
    public class Camera
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

        private readonly Random _random = new Random();
        private string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
