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
        public BindingList<Gate> Gates { get; set; }
        public BindingList<Vehicle> NotParkedVehicles { get; set; }
        public List<Resident> ResidentsList { get; set; }
        public BindingList<Vehicle> MockedVehiclesInOut { get; set; }
        public BindingList<string> ConsoleLog { get; set; }

        public Console()
        {
            Gates = new BindingList<Gate>() { new Gate(444, this) };
            Camera = MakeCameras(Gates);
            ResidentsList = new List<Resident>();
            NotParkedVehicles = new BindingList<Vehicle>();
            MockedVehiclesInOut = new BindingList<Vehicle>();
            ParkingLot = ParkingLot.CreateInstace(5, 1, 1, 1, this);
            ConsoleLog = new BindingList<string>();
        }

        public List<Camera> MakeCameras(BindingList<Gate> gates)
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
            Gate gate = Gates.FirstOrDefault(gt => gt.Id == camId);
            if (gate == null)
            {
                Form.Invoke((MethodInvoker) delegate { ConsoleLog.Add("Kameros klaida"); });
                return;
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

            gate.OpenVehicle(licensePlate, true);
        }

        public void CarInGate(Gate gate)
        {
            if (!gate.DriveIn)
            {
                CarOutGate(gate);
                return;
            }
            bool residentVehicle = false;
            foreach (var resident in ResidentsList)
            {
                if (resident.LicensePlate == gate.OpenGatesFor)
                {
                    residentVehicle = true;
                }
            }
            Vehicle vehicle = new Vehicle(gate.OpenGatesFor, residentVehicle);
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
            Gate gate = Gates.FirstOrDefault(gt => gt.Id == camId);
            if (gate == null)
            {
                Form.Invoke((MethodInvoker)delegate { ConsoleLog.Add("Kameros klaida"); });
                return;
            }

            Vehicle vehicle = NotParkedVehicles.FirstOrDefault(veh => veh.LicensePlate == licensePlate);

            if (vehicle == null)
            {
                Form.Invoke((MethodInvoker)delegate { ConsoleLog.Add("Mašina sistemoje nerasta!!! " + licensePlate); });
                gate.OpenVehicle(licensePlate, false);
                return;
            }

            if (!vehicle.Paid)
            {
                if(ResidentsList.FirstOrDefault(s => s.LicensePlate == vehicle.LicensePlate) == null)
                {
                    Form.Invoke((MethodInvoker) delegate { ConsoleLog.Add("Važiuoja nesusimokėjus " + vehicle); });
                    return;
                }

                vehicle.Resident = true;
                vehicle.Paid = true;
            }

            gate.OpenVehicle(licensePlate, false);
        }

        public void CarOutGate(Gate gate)
        {
            var vehicle = NotParkedVehicles.FirstOrDefault(v => v.LicensePlate == gate.OpenGatesFor);
            if(vehicle == null) return;
            NotParkedVehicles.Remove(vehicle);
            MockedVehiclesInOut.First(veh => veh == vehicle && veh.InParkingLot).OnExit();
        }

        public bool CheckIfNotParked(Vehicle vehicle)
        {
            return NotParkedVehicles.Contains(vehicle);
        }

        public bool CheckBoxInParkingLot(string plate)
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

        public BindingList<Vehicle> GetVehicleList()
        {
            BindingList<Vehicle> vehicles = new BindingList<Vehicle>(NotParkedVehicles);
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
                    if (parkingLotParkingSpace.Vehicle != null && parkingLotParkingSpace.Vehicle.LicensePlate == licensePlat)
                    {
                        parkingLotParkingSpace.Vehicle.OnPay();
                        return;
                    }
                }
            }
        }

        public void UnderGates()
        {
            Form.Invoke((MethodInvoker)delegate { ConsoleLog.Add("Mašina stovi po vartais!!!"); });
        }
    }
}
