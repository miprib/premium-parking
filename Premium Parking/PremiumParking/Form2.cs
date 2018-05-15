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
            Console.Camera[0].SimisIn();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.Camera[0].SimisOut();
        }
    }
}
