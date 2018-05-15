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
        public int Id { get; set; }

        public Camera(Console forInvokeConsole, int id)
        {
            Id = id;
            Timer = new Timer(o =>
            {
                if (forInvokeConsole.ParkingLot.IsFree())
                {
                    forInvokeConsole.CarIn(RandomString(6), Id);
                }
                else
                {
                    forInvokeConsole.NotFree();
                }
            });

            Timer timer2 = new Timer(o =>
            {
                Vehicle vehicle = forInvokeConsole.NotParkedVehicles.FirstOrDefault();
                if (vehicle != null)
                {
                    forInvokeConsole.CarOut(vehicle, Id);
                }
            });

            timer2.Change(30000, 30000);

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
