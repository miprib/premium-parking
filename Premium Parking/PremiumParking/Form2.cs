using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PremiumParking
{
    public partial class Form2 : Form
    {
        public ParkingSystemBack.Console Console { get; set; }
        public Form2(ref ParkingSystemBack.Console console)
        {
            Console = console;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.Camera[0].In("AAA001");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.Camera[0].Out("AAA001");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Console.ParkingLot.ParkingSpaces[0].ParkingSensor.Parked("AAA001");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Console.ParkingLot.ParkingSpaces[0].ParkingSensor.UnParked();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Console.Camera[0].In("AAA002");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Console.ParkingLot.ParkingSpaces[1].ParkingSensor.Parked("AAA002");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Console.ParkingLot.ParkingSpaces[1].ParkingSensor.UnParked();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Console.Pay("AAA002");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Console.Camera[0].Out("AAA002");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Console.Camera[0].In("AAA003");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Console.ParkingLot.ParkingSpaces[2].ParkingSensor.Parked("AAA002");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Console.ParkingLot.ParkingSpaces[2].ParkingSensor.UnParked();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Console.Pay("AAA003");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Console.Camera[0].Out("AAA003");
        }
    }
}
