using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumParking.DataModels
{
    class Vehicle : IEquatable<Vehicle>
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
            if (!resident) Paid = false;
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

        public static BindingList<Vehicle> MakeMany()
        {
            var a = new BindingList<Vehicle>();
            for (int i = 1; i < 31; i++)
            {
                Vehicle v = new Vehicle("AAA" + i.ToString().PadLeft(3,'0'),true);
                a.Add(v);
            }

            for (int i = 0; i < 30; i += 2)
            {
                a[i].OnExit();
            }

            return a;
        }

        public bool Equals(Vehicle other)
        {
            return (other.LicensePlate.Equals(this.LicensePlate)) && (other.InParkingLot.Equals(this.InParkingLot));
        }
    }
}
