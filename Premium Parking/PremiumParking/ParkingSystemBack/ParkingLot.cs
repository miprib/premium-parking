using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumParking.ParkingSystemBack
{
    public class ParkingLot
    {
        public List<ParkingSpace> ParkingSpaces { get; set; }
        public byte Brightness { get; set; }
        public string Message { get; set; }
        private Console _console;

        private ParkingLot(int total, int disabled, int motorbike, int electric, ref Console console)
        {
            _console = console;
            Brightness = 100;
            ParkingSpaces = new List<ParkingSpace>();
            for (var i = 0; i < disabled; i++)
            {
                ParkingSpaces.Add(new ParkingSpace("disabled", ref console));
            }
            for (var i = 0; i < motorbike; i++)
            {
                ParkingSpaces.Add(new ParkingSpace("moto", ref console));
            }
            for (var i = 0; i < electric; i++)
            {
                ParkingSpaces.Add(new ParkingSpace("electric", ref console));
            }
            for (var i = 0; i < (total - disabled - motorbike - electric); i++)
            {
                ParkingSpaces.Add(new ParkingSpace("regular", ref console));
            }
        }

        public static ParkingLot CreateInstace(int total, int disabled, int motorbike, int electric, Console console)
        {
            return total > disabled + motorbike + electric ? new ParkingLot(total, disabled, motorbike, electric, ref console) : null;
        }

        public int GetTotalCount()
        {
            return ParkingSpaces.Count;
        }

        public void SetTotal(int n)
        {
            if (ParkingSpaces.Count < n)
            {
                n -= ParkingSpaces.Count;
                for (int i = 0; i < n; i++)
                {
                    ParkingSpaces.Add(new ParkingSpace("regular", ref _console));
                }
            }
            else
            {
                if (ParkingSpaces.Count == n)
                {
                    return;
                }
                else
                {
                    ParkingSpaces.RemoveRange(ParkingSpaces.Count - n, n);
                }
            }
        }
    }
}
