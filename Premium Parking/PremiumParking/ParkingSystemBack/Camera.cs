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
        public Timer Timer { get; set; }

        public Camera(Console forInvokeConsole)
        {
            Timer = new Timer(o =>
            {
                forInvokeConsole.CarIn(RandomString(6));
            });

            Timer.Change(5000, 20000);
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
