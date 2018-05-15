﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PremiumParking.ParkingSystemBack
{
    public class ParkingSensor
    {
        public Timer Timer { get; set; }

        public ParkingSensor(ParkingSpace parkingSpace)
        {
            Timer = new Timer(o =>
            {
                if(parkingSpace.Vehicle == null)
                {
                    parkingSpace.Parked();
                }
                else
                {
                    parkingSpace.UnParked();
                }
            });
            Timer.Change(5000, 5000);
        }
    }
}
