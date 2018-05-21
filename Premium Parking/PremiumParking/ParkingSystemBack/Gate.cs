using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PremiumParking.ParkingSystemBack
{
    public class Gate : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public bool State { get; set; }
        public GatesSensor GatesSensor { get; set; }
        public string OpenGatesFor { get; set; }
        public bool DriveIn { get; set; }
        public Console Console { get; set; }

        public Gate(int id, Console console)
        {
            Console = console;
            GatesSensor = new GatesSensor(this);
            Id = id;
            State = false;
        }

        public void Change()
        {
            State = !State;
            this.OnPropertyChanged("State");
        }

        public override string ToString()
        {
            return "Vartai " + Id.ToString() + "   " + (State ? "Atidaryta" : "Uždaryta");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public void OpenVehicle(string licensePlate, bool driveIn)
        {
            State = true;
            Console.Form.Invoke((MethodInvoker) delegate { OnPropertyChanged("State"); });
            DriveIn = driveIn;
            OpenGatesFor = licensePlate;
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(10000);
                while (GatesSensor.State)
                {
                    Console.UnderGates();
                    Thread.Sleep(10000);
                }

                State = false;
                OpenGatesFor = null;
                Console.Form.Invoke((MethodInvoker)delegate { OnPropertyChanged("State"); });
            });
        }

        public void Drive()
        {
            State = false;
            Console.CarInGate(this);
            OpenGatesFor = null;
        }
    }
}
