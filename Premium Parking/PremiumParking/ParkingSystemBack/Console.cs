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
            if(!ParkingLot.IsFree())
            {
                Form.Invoke((MethodInvoker)delegate { ConsoleLog.Add("Aikštelė pilna!"); });
                return;
            };

            if (CheckBoxInParkingLot(licensePlate))
            {
                Form.Invoke((MethodInvoker) delegate { ConsoleLog.Add("Mašina jau aikštelėje " + licensePlate); });
                return;
            }

            if (g.OpenVehicle())
            {
                Form.Invoke((MethodInvoker) delegate { ConsoleLog.Add("Mašina stovi po vartais!!!"); });
                if(g.GatesSensor.GoOrNot()) return;
            }
            bool residentVehicle = false;
            foreach (var resident in ResidentsList)
            {
                if (resident.LicensePlate == licensePlate)
                {
                    residentVehicle = true;
                }
            }
            Vehicle vehicle = new Vehicle(licensePlate, residentVehicle);
            Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(20000);
                if (CheckIfNotParked(vehicle))
                {
                    Form.Invoke((MethodInvoker)delegate { ConsoleLog.Add("Automobilis nepastatytas " + vehicle); });
                }
            });
            MockedVehiclesInOut.Add(vehicle);
            NotParkedVehicles.Add(vehicle);
        }

        public void CarOut(string licensePlate, int camId)
        {
            Gate g = Gates.FirstOrDefault(gt => gt.Id == camId);
            if (g == null)
            {
                Form.Invoke((MethodInvoker)delegate { ConsoleLog.Add("Kameros klaida"); });
            }

            Vehicle vehicle = NotParkedVehicles.FirstOrDefault(veh => veh.LicensePlate == licensePlate);

            if (vehicle == null)
            {
                Form.Invoke((MethodInvoker)delegate { ConsoleLog.Add("Mašina sistemoje nerasta!!! " + licensePlate); });
                if (g.OpenVehicle())
                {
                    g.GatesSensor.GoOrNot();
                }
                return;
            }

            if (!vehicle.Paid)
            {
                Form.Invoke((MethodInvoker)delegate { ConsoleLog.Add("Važiuoja nesusimokėjus " + vehicle); });
                return;
            }

            if (g.OpenVehicle())
            {
                Form.Invoke((MethodInvoker)delegate { ConsoleLog.Add("Mašina stovi po vartais!!!"); });
                if (g.GatesSensor.GoOrNot()) return;
            }
            NotParkedVehicles.Remove(vehicle);
            Vehicle v = MockedVehiclesInOut.First(veh => veh == vehicle && veh.InParkingLot);
            v.OnExit();
        }

        private bool CheckIfNotParked(Vehicle vehicle)
        {
            return NotParkedVehicles.Contains(vehicle);
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

        public Vehicle Parked(string license)
        {
            Vehicle vehicle;
            lock (NotParkedVehicles)
            {
                vehicle = NotParkedVehicles.FirstOrDefault(v => v.LicensePlate == license);
                if (vehicle != null) NotParkedVehicles.Remove(vehicle);
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

        public void Pay(string licensePlat)
        {
            Vehicle vehicle = NotParkedVehicles.FirstOrDefault(v => v.LicensePlate == licensePlat);
            if (vehicle != null)
            {
                vehicle.OnPay();
            }
            else
            {
                foreach (var parkingLotParkingSpace in ParkingLot.ParkingSpaces)
                {
                    if (parkingLotParkingSpace.Vehicle.LicensePlate == licensePlat)
                    {
                        parkingLotParkingSpace.Vehicle.OnPay();
                        return;
                    }
                }
            }
        }
    }
}
