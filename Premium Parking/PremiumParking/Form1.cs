using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PremiumParking.DataModels;

namespace PremiumParking
{
    public partial class Form1 : Form
    {
        private BindingList<string> _infoBoxItemsList;
        private BindingSource _gates;
        private System.Threading.Timer _timer;

        public Form1()
        {
            InitializeComponent();
            consoleTab.Appearance = TabAppearance.FlatButtons;
            consoleTab.ItemSize = new Size(0, 1);
            consoleTab.SizeMode = TabSizeMode.Fixed;
            StartSystem();
        }

        private void StartSystem()
        {
            LoadGates();
            StartTimerForConsoleLog();
        }

        private void LoadGates()
        {
            var gates = new List<Gate> { new Gate(555), new Gate(5555), new Gate(444) };
            _gates = new BindingSource {DataSource = gates};
            gatesList.DataSource = _gates;
        }

        private void StartTimerForConsoleLog()
        {
            _infoBoxItemsList = new BindingList<string>(){"New list!"};
            infoBox.DataSource = _infoBoxItemsList;
            _timer = new System.Threading.Timer(o =>
            {
                Invoke((MethodInvoker)delegate
                {
                    _infoBoxItemsList.Add("New message!");
                });
            });
            _timer.Change(5000, 5000);
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
                    Console.WriteLine(menu.SelectedItem);
                    break;
                case 2:
                    popupNumber = 2;
                    Console.WriteLine(menu.SelectedItem);
                    break;
                case 3:
                    consoleTab.SelectedIndex = 0;
                    Console.WriteLine(menu.SelectedItem);
                    break;
                case 4:
                    consoleTab.SelectedIndex = 5;
                    Console.WriteLine(menu.SelectedItem);
                    break;
                case 5:
                    popupNumber = 3;
                    Console.WriteLine(menu.SelectedItem);
                    break;
                case 6:
                    consoleTab.SelectedIndex = 0;
                    Console.WriteLine(menu.SelectedItem);
                    break;
                default:
                    consoleTab.SelectedIndex = 0;
                    Console.WriteLine(@"You fucked up... Somehow...");
                    break;
            }

            if (popupNumber == (-1)) return;

            using(var popupUi = new Popup(popupNumber))
            {
                if (popupUi.ShowDialog() != DialogResult.OK) return;
                consoleTab.SelectedIndex = popupUi.PopupReturn;
                console.Items.Add(popupUi.PopupReturn);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            consoleTab.SelectedIndex = 0;
        }

        private void gatesList_DoubleClick(object sender, EventArgs e)
        {
            var item = gatesList.SelectedItem as Gate;
            item?.Change();
        }
    }
}
