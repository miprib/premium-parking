using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace PremiumParking.ParkingSystemBack
{
    public class Gate : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public bool State { get; set; }

        public Gate(int id)
        {
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

        public bool OpenVehicle()
        {
            if (State == true) return true;
            State = true;
            if (new Random().Next(0, 100) >= 95) return true;
            State = false;
            return false;
        }

        public void TryClose()
        {
            while (new Random().Next(0, 100) < 50)
            {
                State = true;
            }
            State = false;
        }
    }
}
