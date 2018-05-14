using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumParking.ParkingSystemBack
{
    public class Console
    {
        public ParkingLot ParkingLot { get; set; }
        public Camera Camera { get; set; }
        public List<Vehicle> NotParkedVehicles { get; set; }
        public List<Resident> ResidentsList { get; set; }

        public Console()
        {
            Camera = new Camera(this);
            ResidentsList = Resident.ResidentsFactory();
            NotParkedVehicles = new List<Vehicle>();
            ParkingLot = ParkingLot.CreateInstace(5, 1, 1, 1, this);
        }

        public void CarIn(string licensePlate)
        {
            foreach (var resident in ResidentsList)
            {
                if (resident.LicensePlate == licensePlate)
                {
                    NotParkedVehicles.Add(new Vehicle(licensePlate, true));
                    return;
                }
            }
            NotParkedVehicles.Add(new Vehicle(licensePlate, false));
        }

        public Vehicle Parked()
        {
            Vehicle vehicle;
            lock (NotParkedVehicles)
            {
                 vehicle = NotParkedVehicles.FirstOrDefault();
                if (vehicle == null) return vehicle;
                NotParkedVehicles.Remove(vehicle);
                System.Console.WriteLine(vehicle);
            }
            return vehicle;
        }
    }
}
