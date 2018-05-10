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
    public partial class Form1 : Form
    {
        private BindingList<string> InfoBoxItemsList;
        private System.Threading.Timer timer;

        public Form1()
        {
            InitializeComponent();
            consoleTab.Appearance = TabAppearance.FlatButtons;
            consoleTab.ItemSize = new Size(0, 1);
            consoleTab.SizeMode = TabSizeMode.Fixed;
            InfoBoxItemsList = new BindingList<string>();
            startTimer();
            this.infoBox.DataSource = InfoBoxItemsList;

        }

        private void startTimer()
        {
            timer = new System.Threading.Timer(updateConsoleLog);
            timer.Change(5000, 5000);

        }

        private void updateConsoleLog(object o)
        {
            Console.WriteLine("Eiii");
            this.Invoke((MethodInvoker)delegate()
            {
                this.InfoBoxItemsList.Add("naus");
            });
        }

        private void menu_SelectedIndexChanged(object sender, EventArgs e)
        {

            console.Items.Add(menu.SelectedItem.ToString());
            int visibleItems = console.ClientSize.Height / console.ItemHeight;
            console.TopIndex = Math.Max(console.Items.Count - visibleItems + 1, 0);
            int popupNumber = -1;

            switch (menu.SelectedIndex)
            {
                case 0:
                    consoleTab.SelectedIndex = 1;
                    Console.WriteLine(menu.SelectedItem);
                    break;
                case 1:
                    popupNumber = 1;
                    consoleTab.SelectedIndex = 2;
                    Console.WriteLine(menu.SelectedItem);
                    break;
                case 2:
                    popupNumber = 2;
                    consoleTab.SelectedIndex = 3;
                    Console.WriteLine(menu.SelectedItem);
                    break;
                case 3:
                    consoleTab.SelectedIndex = 4;
                    Console.WriteLine(menu.SelectedItem);
                    break;
                case 4:
                    consoleTab.SelectedIndex = 5;
                    Console.WriteLine(menu.SelectedItem);
                    break;
                case 5:
                    popupNumber = 3;
                    consoleTab.SelectedIndex = 6;
                    Console.WriteLine(menu.SelectedItem);
                    break;
                case 6:
                    consoleTab.SelectedIndex = 7;
                    Console.WriteLine(menu.SelectedItem);
                    break;
                default:
                    Console.WriteLine("You fucked up... Somehow...");
                    break;
            }

            if (popupNumber == (-1)) return;

            using(var popupUI = new Popup(popupNumber))
            {
                var result = popupUI.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var resultReturned = popupUI.PopupReturn;
                    console.Items.Add(resultReturned);
                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            consoleTab.SelectedIndex = 0;
        }
    }
}
