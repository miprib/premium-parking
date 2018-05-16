﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace PremiumParking.ParkingSystemBack
{
    public class Gate : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public bool State { get; set; }
        public GatesSensor GatesSensor { get; set; }
        public string OpenGatesFor { get; set; }
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

        public void OpenVehicle(string licensePlate)
        {
            State = true;
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
