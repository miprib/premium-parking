﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
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
            _console.FormInstance(this);
            consoleTab.Appearance = TabAppearance.FlatButtons;
            consoleTab.ItemSize = new Size(0, 1);
            consoleTab.SizeMode = TabSizeMode.Fixed;
            new Thread(() => new Form2(ref _console).ShowDialog()).Start();
        }

        private void LoadConsoleLog(object sender, EventArgs e)
        {
            _console.ConsoleLog.ListChanged += this.SetBottomConsole;
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
            var residents = new BindingList<Resident>(_console.Reservations);
            residentsTable.DataSource = residents;
        }

        private void LoadInOut(object sender, EventArgs e)
        {
            var vehicles = new BindingList<Vehicle>(_console.MockedVehiclesInOut);
            _console.MockedVehiclesInOut.ListChanged += LoadInOut;
            inout_jornal.AutoGenerateColumns = true;
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(100);
                this.Invoke((MethodInvoker) delegate { inout_jornal.DataSource = vehicles; });
            });
        }

        private void LoadGates(object sender, EventArgs e)
        {
            gatesList.DataSource = _console.Gates;
        }

        private void menu_SelectedIndexChanged(object sender, EventArgs e)
        {
            int popupNumber = -1;

            switch (menu.SelectedIndex)
            {
                case 0:
                    consoleTab.SelectedIndex = 1;
                    break;
                case 1:
                    popupNumber = 1;
                    break;
                case 2:
                    popupNumber = 2;
                    break;
                case 3:
                    consoleTab.SelectedIndex = 0;
                    break;
                case 4:
                    consoleTab.SelectedIndex = 5;
                    break;
                case 5:
                    popupNumber = 3;
                    break;
                case 6:
                    consoleTab.SelectedIndex = 7;
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
            _console.ConsoleLog.Add("Vardai " + item.Id + " " + (item.State ? "atidaromi" : "uždaromi"));
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
            if (_console.ResidentsList.Count + 1 <= _console.ParkingLot.ParkingSpaces.Count * 0.2)
            {
                label7.Text = @"Per daug rezervuotų vietų";
                return;
            }
            if ((textBox2.Text == "") && (textBox3.Text == "") && (textBox4.Text == "") && (textBox5.Text == "") && (textBox6.Text == ""))
            {
                label7.Text = @"Užpildykite visus laukus";
                return;
            }
            Resident resident = new Resident(textBox2.Text, textBox3.Text,textBox4.Text, textBox5.Text, textBox6.Text);
            if (_console.Reservations.Contains(resident))
            {
                label7.Text = @"Tokiam automobiliui vieta užrezervuota";
                return;
            }

            if (!_console.ResidentsList.Contains(resident))
            {
                label7.Text = @"Tokio gyventojo gyventojų sistemoje nėra";
                return;
            }
            label7.Text = @"Išsaugota";
            _console.Reservations.Add(resident);
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
            _console.ConsoleLog.Add("Pakeista " + trackBar1.Value + "%");
        }
    }
}
