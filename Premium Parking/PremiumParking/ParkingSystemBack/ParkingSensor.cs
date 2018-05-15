using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PremiumParking.ParkingSystemBack
{
    public class ParkingSensor
    {
        public ParkingSpace ParkingSpace { get; set; }

        public ParkingSensor(ParkingSpace parkingSpace)
        {
            ParkingSpace = parkingSpace;
        }

        public void Parked(string license)
        {
            ParkingSpace.Parked(license);
        }

        public void UnParked()
        {
            ParkingSpace.UnParked();
        }

        public bool CheckIfGood()
        {
            return new Random().Next(0,100) <= 80;
        }
    }
}
