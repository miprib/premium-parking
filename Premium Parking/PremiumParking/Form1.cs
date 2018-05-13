using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PremiumParking.DataModels;

namespace PremiumParking
{
    public partial class Form1 : Form
    {
        private BindingList<string> _infoBoxItemsList;
        private BindingList<Vehicle> _vehicles;
        private BindingList<Resident> _residents;
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
            LoadInOut();
            LoadResidents();
        }

        private void LoadResidents()
        {
            _residents = new BindingList<Resident>();
        }

        private void LoadInOut()
        {
            _vehicles = Vehicle.MakeMany();
            inout_jornal.AutoGenerateColumns = true;
            inout_jornal.DataSource = _vehicles;
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
                    infoBox.TopIndex =
                        Math.Max(infoBox.Items.Count - infoBox.ClientSize.Height / infoBox.ItemHeight + 1, 0);
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

        private void button1_Click(object sender, EventArgs e)
        {
            string t = textBox1.Text;
            if (t.Length > 1)
            {
                BindingList<Vehicle> vehicles = new BindingList<Vehicle>();
                foreach (var vehicle in _vehicles)
                {
                    if (Regex.IsMatch(vehicle.LicensePlate, t))
                    {
                        Console.WriteLine(vehicle.LicensePlate);
                        vehicles.Add(vehicle);
                    }
                }
                inout_jornal.DataSource = vehicles;
            }
            else
            {
                inout_jornal.DataSource = _vehicles;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var failed = true;
            failed = textBox2.Text == "";
            failed = textBox3.Text == "";
            failed = textBox4.Text == "";
            failed = textBox5.Text == "";
            failed = textBox6.Text == "";
            if (failed)
            {
                label7.Text = "Užpildykite visus laukus";
                Console.WriteLine("1");
                return;
            }
            Resident resident = new Resident(textBox2.Text, textBox3.Text,textBox4.Text, textBox5.Text, textBox6.Text);
            if (_residents.Contains(resident))
            {
                label7.Text = "Toks gyventojas jau egzistuoja";
                Console.WriteLine("2");
                return;
            }
            Console.WriteLine("3");
            label7.Text = "Išsaugota";
            _residents.Add(resident);
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;
            textBox6.Text = String.Empty;
        }
    }
}
