using System;
using System.Windows.Forms;

namespace PremiumParking
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.ListBox();
            this.console = new System.Windows.Forms.ListBox();
            this.backButton = new System.Windows.Forms.Button();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.archivationList = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.Delete = new System.Windows.Forms.Button();
            this.residentsTable = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.inout_jornal = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gatesList = new System.Windows.Forms.ListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.infoBox = new System.Windows.Forms.ListBox();
            this.consoleTab = new System.Windows.Forms.TabControl();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button5 = new System.Windows.Forms.Button();
            this.tabPage8.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.archivationList)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.residentsTable)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inout_jornal)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.consoleTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.FormattingEnabled = true;
            this.menu.ItemHeight = 16;
            this.menu.Items.AddRange(new object[] {
            "Vartų kontrolė",
            "Peržiūrėti informaciją",
            "Rezervacijos",
            "Keisti stovėjimo kainą",
            "Archyvavimas",
            "Dashboard kontrolė",
            "Lempučių ryškumas"});
            this.menu.Location = new System.Drawing.Point(12, 12);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(276, 116);
            this.menu.TabIndex = 0;
            this.menu.DoubleClick += new System.EventHandler(this.menu_SelectedIndexChanged);
            // 
            // console
            // 
            this.console.FormattingEnabled = true;
            this.console.ItemHeight = 16;
            this.console.Location = new System.Drawing.Point(13, 149);
            this.console.Name = "console";
            this.console.Size = new System.Drawing.Size(275, 340);
            this.console.TabIndex = 1;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(308, 491);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 3;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.button5);
            this.tabPage8.Controls.Add(this.trackBar1);
            this.tabPage8.Location = new System.Drawing.Point(4, 25);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(571, 448);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "tabPage8";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.button4);
            this.tabPage7.Controls.Add(this.label9);
            this.tabPage7.Controls.Add(this.label8);
            this.tabPage7.Controls.Add(this.textBox8);
            this.tabPage7.Controls.Add(this.textBox7);
            this.tabPage7.Location = new System.Drawing.Point(4, 25);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(571, 448);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "tabPage7";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(10, 67);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Išsaugoti";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 17);
            this.label9.TabIndex = 3;
            this.label9.Text = "Būsimas";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "Pradinis";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(111, 36);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 22);
            this.textBox8.TabIndex = 1;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(111, 7);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(100, 22);
            this.textBox7.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.archivationList);
            this.tabPage6.Controls.Add(this.button3);
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(571, 448);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            this.tabPage6.VisibleChanged += new EventHandler(this.LoadArchivation);
            // 
            // archivationList
            // 
            this.archivationList.AllowUserToAddRows = false;
            this.archivationList.AllowUserToDeleteRows = false;
            this.archivationList.AllowUserToResizeColumns = false;
            this.archivationList.AllowUserToResizeRows = false;
            this.archivationList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.archivationList.Location = new System.Drawing.Point(7, 7);
            this.archivationList.MultiSelect = false;
            this.archivationList.Name = "archivationList";
            this.archivationList.RowTemplate.Height = 24;
            this.archivationList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.archivationList.Size = new System.Drawing.Size(558, 406);
            this.archivationList.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 419);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Archyvuoti";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.Delete);
            this.tabPage5.Controls.Add(this.residentsTable);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(571, 448);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(6, 419);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 1;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // residentsTable
            // 
            this.residentsTable.AllowUserToAddRows = false;
            this.residentsTable.AllowUserToDeleteRows = false;
            this.residentsTable.AllowUserToResizeColumns = false;
            this.residentsTable.AllowUserToResizeRows = false;
            this.residentsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.residentsTable.Location = new System.Drawing.Point(6, 3);
            this.residentsTable.MultiSelect = false;
            this.residentsTable.Name = "residentsTable";
            this.residentsTable.ReadOnly = true;
            this.residentsTable.RowTemplate.Height = 24;
            this.residentsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.residentsTable.Size = new System.Drawing.Size(559, 410);
            this.residentsTable.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.textBox6);
            this.tabPage4.Controls.Add(this.textBox5);
            this.tabPage4.Controls.Add(this.textBox4);
            this.tabPage4.Controls.Add(this.textBox3);
            this.tabPage4.Controls.Add(this.textBox2);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.button2);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(571, 448);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 17);
            this.label7.TabIndex = 11;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(164, 118);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 22);
            this.textBox6.TabIndex = 10;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(164, 90);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 9;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(164, 62);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 8;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(164, 34);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(164, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Buto numeris";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Telefonas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Valstybinis numeris";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pavardė";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vardas";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(32, 192);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Išsaugoti";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.inout_jornal);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(571, 448);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // inout_jornal
            // 
            this.inout_jornal.AllowUserToResizeColumns = false;
            this.inout_jornal.AllowUserToResizeRows = false;
            this.inout_jornal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inout_jornal.Location = new System.Drawing.Point(9, 7);
            this.inout_jornal.MultiSelect = false;
            this.inout_jornal.Name = "inout_jornal";
            this.inout_jornal.ReadOnly = true;
            this.inout_jornal.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.inout_jornal.RowTemplate.Height = 24;
            this.inout_jornal.Size = new System.Drawing.Size(556, 403);
            this.inout_jornal.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 420);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Valstybinis numeris";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(141, 417);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(247, 416);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Filtruoti";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gatesList);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(571, 448);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gatesList
            // 
            this.gatesList.FormattingEnabled = true;
            this.gatesList.ItemHeight = 16;
            this.gatesList.Location = new System.Drawing.Point(7, 7);
            this.gatesList.Name = "gatesList";
            this.gatesList.Size = new System.Drawing.Size(558, 436);
            this.gatesList.TabIndex = 0;
            this.gatesList.DoubleClick += new System.EventHandler(this.gatesList_DoubleClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.infoBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(571, 448);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // infoBox
            // 
            this.infoBox.FormattingEnabled = true;
            this.infoBox.ItemHeight = 16;
            this.infoBox.Location = new System.Drawing.Point(7, 7);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(558, 436);
            this.infoBox.TabIndex = 0;
            // 
            // consoleTab
            // 
            this.consoleTab.Controls.Add(this.tabPage1);
            this.consoleTab.Controls.Add(this.tabPage2);
            this.consoleTab.Controls.Add(this.tabPage3);
            this.consoleTab.Controls.Add(this.tabPage4);
            this.consoleTab.Controls.Add(this.tabPage5);
            this.consoleTab.Controls.Add(this.tabPage6);
            this.consoleTab.Controls.Add(this.tabPage7);
            this.consoleTab.Controls.Add(this.tabPage8);
            this.consoleTab.Location = new System.Drawing.Point(304, 12);
            this.consoleTab.Name = "consoleTab";
            this.consoleTab.SelectedIndex = 0;
            this.consoleTab.Size = new System.Drawing.Size(579, 477);
            this.consoleTab.TabIndex = 2;
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(6, 6);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(559, 56);
            this.trackBar1.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(7, 67);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 1;
            this.button5.Text = "Išsaugoti";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 520);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.consoleTab);
            this.Controls.Add(this.console);
            this.Controls.Add(this.menu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.archivationList)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.residentsTable)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inout_jornal)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.consoleTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox menu;
        private System.Windows.Forms.ListBox console;
        private System.Windows.Forms.Button backButton;
        private TabPage tabPage8;
        private TabPage tabPage7;
        private TabPage tabPage6;
        private DataGridView archivationList;
        private Button button3;
        private TabPage tabPage5;
        private Button Delete;
        private DataGridView residentsTable;
        private TabPage tabPage4;
        private Label label7;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button button2;
        private TabPage tabPage3;
        private DataGridView inout_jornal;
        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private TabPage tabPage2;
        private ListBox gatesList;
        private TabPage tabPage1;
        private ListBox infoBox;
        private TabControl consoleTab;
        private Button button4;
        private Label label9;
        private Label label8;
        private TextBox textBox8;
        private TextBox textBox7;
        private Button button5;
        private TrackBar trackBar1;
    }
}

