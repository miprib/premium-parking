using System.Collections.Generic;
using System.ComponentModel;

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

        public static List<Gate> MakeGates()
        {
            return new List<Gate>()
            {
                new Gate(555),
                new Gate(5555),
                new Gate(444)
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
