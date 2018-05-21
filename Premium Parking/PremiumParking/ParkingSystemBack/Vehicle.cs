using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace PremiumParking.ParkingSystemBack
{
    public class Vehicle : IEquatable<Vehicle>, INotifyPropertyChanged
    {
        public string LicensePlate { get; set; }
        public DateTime timepstampEntry { get; set; }
        public DateTime timestampExit { get; set; }
        public bool InParkingLot { get; set; }
        public bool Resident { get; set; }
        public bool Paid { get; set; }

        public Vehicle(string licensePlate, bool resident)
        {
            LicensePlate = licensePlate;
            timepstampEntry = DateTime.Now;
            Resident = resident;
            InParkingLot = true;
            Paid = resident;
        }

        public Vehicle(string l, DateTime e, DateTime ex, bool res, bool paid)
        {
            LicensePlate = l;
            timestampExit = e;
            timestampExit = ex;
            InParkingLot = true;
            Resident = res;
            Paid = paid;
        }

        public void OnExit()
        {
            InParkingLot = false;
            timestampExit = DateTime.Now;
            OnPropertyChanged("InParkingLot");
        }

        public void OnPay()
        {
            Paid = true;
            OnPropertyChanged("Paid");
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(10000);
                if (InParkingLot)
                {
                    Paid = false;
                    OnPropertyChanged("Paid");
                }
            });
        }

        public override string ToString()
        {
            return LicensePlate.ToString();
        }

        public bool Equals(Vehicle other)
        {
            return (other.LicensePlate.Equals(this.LicensePlate)) && (other.InParkingLot.Equals(this.InParkingLot));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
