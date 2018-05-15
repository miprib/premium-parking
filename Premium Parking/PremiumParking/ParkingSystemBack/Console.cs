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
        public Form1 Form { get; set; }
        public ParkingLot ParkingLot { get; set; }
        public List<Camera> Camera { get; set; }
        public List<Gate> Gates { get; set; }
        public List<Vehicle> NotParkedVehicles { get; set; }
        public List<Resident> ResidentsList { get; set; }
        public List<Vehicle> MockedVehiclesInOut { get; set; }
        public BindingList<string> ConsoleLog { get; set; }

        public Console()
        {
            Gates = new List<Gate>() { new Gate(444) };
            Camera = MakeCameras(Gates);
            ResidentsList = Resident.ResidentsFactory();
            NotParkedVehicles = new List<Vehicle>();
            MockedVehiclesInOut = new List<Vehicle>();
            ParkingLot = ParkingLot.CreateInstace(5, 1, 1, 1, this);
            ConsoleLog = new BindingList<string>();
        }

        private List<Camera> MakeCameras(List<Gate> gates)
        {
            var a = new List<Camera>();
            foreach (var gate in gates)
            {
                a.Add(new Camera(this, gate.Id));
            }

            return a;
        }

        public void CarIn(string licensePlate, int camId)
        {
            Gate g = Gates.FirstOrDefault(gt => gt.Id == camId);
            if (g == null)
            {
                Form.Invoke((MethodInvoker) delegate { ConsoleLog.Add("Kameros klaida"); });
            }

            if (CheckBoxInParkingLot(licensePlate))
            {
                Form.Invoke((MethodInvoker) delegate { ConsoleLog.Add("Mašina jau aikštelėje " + licensePlate); });
                return;
            }

            if (g.OpenVehicle())
            {
                Form.Invoke((MethodInvoker) delegate { ConsoleLog.Add("Mašina stovi po vartais!!!"); });
                g.TryClose();
            }
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
            System.Threading.Timer timer = new System.Threading.Timer(o =>
            {
                if (NotParkedVehicles.Contains(vehicle))
                {
                    Form.Invoke((MethodInvoker) delegate
                    {
                        ConsoleLog.Add("Nepastatytas automobilis " + vehicle.ToString());
                    });
                }
            });
            timer.Change(50000, 0);
            MockedVehiclesInOut.Add(vehicle);
            NotParkedVehicles.Add(vehicle);
        }

        private bool CheckBoxInParkingLot(string plate)
        {
            foreach (var vehicle in MockedVehiclesInOut)
            {
                if (vehicle.LicensePlate == plate && vehicle.InParkingLot)
                {
                    return true;
                }
            }

            return false;
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
            Form.Invoke((MethodInvoker) delegate
            {
                ConsoleLog.Add("Aikštelė pilna");
            });
        }

        public void FormInstance(Form1 form1)
        {
            Form = form1;
        }

        public void CarOut(Vehicle vehicle, int camId)
        {
            Gate g = Gates.FirstOrDefault(gt => gt.Id == camId);
            if (g == null)
            {
                Form.Invoke((MethodInvoker)delegate { ConsoleLog.Add("Kameros klaida"); });
            }

            if (!vehicle.Paid)
            {
                Form.Invoke((MethodInvoker)delegate { ConsoleLog.Add("Važiuoja nesusimokėjus " + vehicle); });
                vehicle.OnPay();
                return;
            }

            if (g.OpenVehicle())
            {
                Form.Invoke((MethodInvoker)delegate { ConsoleLog.Add("Mašina stovi po vartais!!!"); });
                g.TryClose();
            }

            NotParkedVehicles.Remove(vehicle);
            Vehicle v = MockedVehiclesInOut.FirstOrDefault(veh => veh == vehicle && veh.InParkingLot);
            v?.OnExit();
        }
    }
}
