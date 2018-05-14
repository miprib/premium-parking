using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumParking.ParkingSystemBack
{
    public class ParkingSpace
    {
        public Vehicle Vehicle { get; set; }
        public ParkingSensor ParkingSensor { get; set; }
        public bool DisabledSpace { get; set; }
        public bool MotorbileSpace { get; set; }
        public bool ElectricCarSpace { get; set; }
        public bool RegularSpace { get; set; }
        public Lamp Lamp { get; set; }
        public Console Console { get; set; }

        public ParkingSpace(string state, ref Console console)
        {
            Console = console;
            ParkingSensor = new ParkingSensor(this);
            Lamp = new Lamp();
            switch (state)
            {
                case "disabled":
                    DisabledSpace = true;
                    MotorbileSpace = false;
                    RegularSpace = false;
                    ElectricCarSpace = false;
                    break;
                case "moto":
                    DisabledSpace = false;
                    MotorbileSpace = true;
                    RegularSpace = false;
                    ElectricCarSpace = false;
                    break;
                case "electric":
                    DisabledSpace = false;
                    MotorbileSpace = false;
                    RegularSpace = true;
                    ElectricCarSpace = false;
                    break;
                case "regular":
                    DisabledSpace = false;
                    MotorbileSpace = false;
                    RegularSpace = false;
                    ElectricCarSpace = true;
                    break;
            }
        }

        public void Parked()
        {
            if(Vehicle != null) return;
            Vehicle = Console.Parked();
        }
    }
}
