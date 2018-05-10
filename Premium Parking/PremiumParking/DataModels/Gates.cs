using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumParking.DataModels
{
    class Gates
    {
        public static int number = 0;
        public bool State { get; set; }
        public int GatesId { get; set; }

        public Gates()
        {
            State = false;
            GatesId = number++;
        }
    }
}
