using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumParking.ParkingSystemBack
{
    public class Lamp
    {
        public bool Status { get; set; }
        public bool Green { get; set; }

        public Lamp()
        {
            Status = true;
            Green = true;
        }
    }
}
