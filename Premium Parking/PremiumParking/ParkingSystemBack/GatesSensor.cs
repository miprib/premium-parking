using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public void Drive()
        {
            State = false;
            Gate.Drive();
        }

        public void UnderGate()
        {
            State = true;
        }

        public void NotDrive()
        {
            State = false;
        }
    }
}
