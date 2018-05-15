using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumParking.ParkingSystemBack
{
    public class GatesSensor
    {
        public bool State { get; set; }
        public Gate Gate;

        public GatesSensor(Gate gate)
        {
            Gate = gate;
            State = false;
        }

        public bool GoOrNot()
        {
            State = false;
            Gate.State = false;
            return new Random().Next(0, 100) > 50;
        }
    }
}
