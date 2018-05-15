using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PremiumParking.ParkingSystemBack
{
    public class Console
    {
        public ParkingLot ParkingLot { get; set; }
        public Camera Camera { get; set; }
        public List<Gate> Gates { get; set; }
        public List<Vehicle> NotParkedVehicles { get; set; }
        public List<Resident> ResidentsList { get; set; }
        public List<Vehicle> MockedVehiclesInOut { get; set; }
        public BindingList<string> ConsoleLog { get; set; }

        public Console()
        {
            Gates = Gate.MakeGates();
            Camera = new Camera(this);
            ResidentsList = Resident.ResidentsFactory();
            NotParkedVehicles = new List<Vehicle>();
            MockedVehiclesInOut = new List<Vehicle>();
            ParkingLot = ParkingLot.CreateInstace(5, 1, 1, 1, this);
            ConsoleLog = new BindingList<string>();
        }

        public void ConsoleLogM(Form1 f)
        {
            System.Threading.Timer t = new System.Threading.Timer(o => 
            {
                f.Invoke((MethodInvoker)delegate
                {
                    this.ConsoleLog.Add("heyyyy");
                });
            });
            t.Change(1000, 1000);
        }

        public void CarIn(string licensePlate)
        {
            Vehicle vehicle;
            foreach (var resident in ResidentsList)
            {
                if (resident.LicensePlate != licensePlate) continue;
                vehicle = new Vehicle(licensePlate, true);
                NotParkedVehicles.Add(vehicle);
                MockedVehiclesInOut.Add(vehicle);
                return;
            }
            vehicle = new Vehicle(licensePlate, false);
            MockedVehiclesInOut.Add(vehicle);
            NotParkedVehicles.Add(vehicle);
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

        public List<Vehicle> GetVehicleList()
        {
            List<Vehicle> vehicles = new List<Vehicle>(NotParkedVehicles);
            foreach (var parkingLotParkingSpace in ParkingLot.ParkingSpaces)
            {
                if (parkingLotParkingSpace.Vehicle != null)
                {
                    vehicles.Add(parkingLotParkingSpace.Vehicle);
                }
            }
            return vehicles;
        }

        public void ArchiveCar(Vehicle vehicle)
        {
            if (!NotParkedVehicles.Remove(vehicle))
            {
                foreach (var parkingLotParkingSpace in ParkingLot.ParkingSpaces)
                {
                    if (parkingLotParkingSpace.Vehicle == null) continue;
                    if (!parkingLotParkingSpace.Vehicle.Equals(vehicle)) continue;
                    parkingLotParkingSpace.Vehicle = null;
                }
            }
        }

        public void RemoveResident(Resident resident)
        {
            ResidentsList.Remove(resident);
        }

        public void UnParked(Vehicle vehicle)
        {
            NotParkedVehicles.Add(vehicle);
        }

        public void NotFree()
        {
            throw new NotImplementedException();
        }
    }
}
