using System;
using System.ComponentModel;

namespace PremiumParking.ParkingSystemBack
{
    public class Vehicle : IEquatable<Vehicle>
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
        }

        public void OnPay()
        {
            Paid = true;
        }

        public override string ToString()
        {
            return LicensePlate.ToString();
        }

        public bool Equals(Vehicle other)
        {
            return (other.LicensePlate.Equals(this.LicensePlate)) && (other.InParkingLot.Equals(this.InParkingLot));
        }
    }
}
