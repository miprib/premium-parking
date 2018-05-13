using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PremiumParking.DataModels
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
    }
}
