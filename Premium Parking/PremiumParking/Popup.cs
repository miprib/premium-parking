﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PremiumParking
{
    public partial class Popup : Form
    {
        public int PopupReturn { get; set; }
        public Popup(int n)
        {
            List<String> selections = new List<string>();
            InitializeComponent();
            switch (n)
            {
                case 1:
                    selections.Add("Įvažiavimų/Išvažiavimų žurnalas");
                    selections.Add("Rezervuotų vietų informacija");
                    selections.Add("Užimtos vietos");
                    popupList.DataSource = selections;
                    break;
                case 2:
                    selections.Add("Pridėti rezervuotą vietą");
                    selections.Add("Pašalinti rezervuotą vietą");
                    popupList.DataSource = selections;
                    break;
                case 3:
                    selections.Add("Pakeisti laisvų vietų skaičių");
                    selections.Add("Pakeisti esamų vietų skaičių");
                    selections.Add("Pakeisti neįgaliųjų vietų skaičių");
                    selections.Add("Pakeisti motociklų vietų skaičių");
                    selections.Add("Pakeisti elektromobilių vietų skaičių");
                    popupList.DataSource = selections;
                    break;
                default:
                    selections.Add("Klaida!!!");
                    break;
            }
        }

        private void popupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (popupList.SelectedItem)
            {
                case "Įvažiavimų/Išvažiavimų žurnalas":
                    PopupReturn = 2;
                    break;
                case "Pridėti rezervuotą vietą":
                    PopupReturn = 3;
                    break;
                case "Pašalinti rezervuotą vietą":
                    PopupReturn = 4;
                    break;
                case "Pakeisti esamų vietų skaičių":
                    PopupReturn = 6;
                    break;
                default:
                    PopupReturn = 0;
                    break;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
