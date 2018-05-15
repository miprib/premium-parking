using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PremiumParking.ParkingSystemBack;
using Console = System.Console;

namespace PremiumParking
{
    public partial class Form1 : Form
    {
        private ParkingSystemBack.Console _console;

        public Form1(ParkingSystemBack.Console console)
        {
            _console = console;
            InitializeComponent();
            _console.ConsoleLogM(this);
            consoleTab.Appearance = TabAppearance.FlatButtons;
            consoleTab.ItemSize = new Size(0, 1);
            consoleTab.SizeMode = TabSizeMode.Fixed;
        }

        private void LoadConsoleLog(object sender, EventArgs e)
        {
            _console.ConsoleLog.ListChanged += new ListChangedEventHandler(this.SetBottomConsole);
            infoBox.DataSource = _console.ConsoleLog;
        }

        private void SetBottomConsole(object sender, ListChangedEventArgs e)
        {
            Invoke((MethodInvoker) delegate
            {
                infoBox.TopIndex =
                    Math.Max(infoBox.Items.Count - infoBox.ClientSize.Height / infoBox.ItemHeight + 1, 0);
            });
        }

        private void LoadLights(object sender, EventArgs e)
        {
            trackBar1.Value = _console.ParkingLot.Brightness;
        }

        private void LoadParkingSpaces(object sender, EventArgs e)
        {
            textBox7.Text = _console.ParkingLot.GetTotalCount().ToString();
        }

        private void LoadArchivation(object sender, EventArgs e)
        {
            var vehiclesArvhive = new BindingList<Vehicle>(_console.GetVehicleList());
            archivationList.DataSource = vehiclesArvhive;
        }

        private void LoadResidents(object sender, EventArgs e)
        {
            var residents = new BindingList<Resident>(_console.ResidentsList);
            residentsTable.DataSource = residents;
        }

        private void LoadInOut(object sender, EventArgs e)
        {
            var vehicles = new BindingList<Vehicle>(_console.MockedVehiclesInOut);
            inout_jornal.AutoGenerateColumns = true;
            inout_jornal.DataSource = vehicles;
        }

        private void LoadGates(object sender, EventArgs e)
        {
            var bGates = new BindingList<Gate>(_console.Gates);
            gatesList.DataSource = bGates;
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
                    consoleTab.SelectedIndex = 7;
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
            console.Items.Add("Vardai " + item.Id + " " + (item.State ? "atidaromi" : "uždaromi"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t = textBox1.Text;
            if (t.Length > 1)
            {
                BindingList<Vehicle> vehicles = new BindingList<Vehicle>();
                foreach (var vehicle in _console.MockedVehiclesInOut)
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
                inout_jornal.DataSource = _console.MockedVehiclesInOut;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text == "") && (textBox3.Text == "") && (textBox4.Text == "") && (textBox5.Text == "") && (textBox6.Text == ""))
            {
                label7.Text = @"Užpildykite visus laukus";
                return;
            }
            Resident resident = new Resident(textBox2.Text, textBox3.Text,textBox4.Text, textBox5.Text, textBox6.Text);
            if (_console.ResidentsList.Contains(resident))
            {
                label7.Text = @"Toks gyventojas jau egzistuoja";
                return;
            }
            label7.Text = @"Išsaugota";
            _console.ResidentsList.Add(resident);
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;
            textBox6.Text = String.Empty;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            var residentsTableSelectedRow = residentsTable.SelectedRows[0];
            var name = residentsTableSelectedRow.Cells[0].Value.ToString();
            var surname = residentsTableSelectedRow.Cells[1].Value.ToString();
            var license = residentsTableSelectedRow.Cells[2].Value.ToString();
            var phone = residentsTableSelectedRow.Cells[3].Value.ToString();
            var apartament = residentsTableSelectedRow.Cells[4].Value.ToString();
            Resident resident = new Resident(name,surname,license,phone,apartament);
            residentsTable.Rows.Remove(residentsTableSelectedRow);
            _console.RemoveResident(resident);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var archivationListSelectedRow = archivationList.SelectedRows[0];
            var name = archivationListSelectedRow.Cells[0].Value.ToString();
            var enter = archivationListSelectedRow.Cells[1].Value is DateTime time ? time : new DateTime();
            var exit = archivationListSelectedRow.Cells[2].Value is DateTime dateTime ? dateTime : new DateTime();
            var resident = archivationListSelectedRow.Cells[3].Value is bool b && b;
            var paid = archivationListSelectedRow.Cells[4].Value as bool? ?? false;
            Vehicle a = new Vehicle(name,enter,exit,resident,paid);
            archivationList.Rows.Remove(archivationListSelectedRow);
            _console.ArchiveCar(a);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _console.ParkingLot.SetTotal(Int32.Parse(textBox8.Text));
            textBox7.Text = _console.ParkingLot.GetTotalCount().ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _console.ParkingLot.Brightness = (byte)trackBar1.Value;
            console.Items.Add("Pakeista " + trackBar1.Value + "%");
        }
    }
}
