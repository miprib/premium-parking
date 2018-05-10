namespace PremiumParking
{
    partial class Popup
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
            this.popupList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // popupList
            // 
            this.popupList.FormattingEnabled = true;
            this.popupList.ItemHeight = 16;
            this.popupList.Location = new System.Drawing.Point(12, 12);
            this.popupList.Name = "popupList";
            this.popupList.Size = new System.Drawing.Size(496, 276);
            this.popupList.TabIndex = 0;
            this.popupList.SelectedIndexChanged += new System.EventHandler(this.popupList_SelectedIndexChanged);
            // 
            // Popup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 312);
            this.Controls.Add(this.popupList);
            this.Name = "Popup";
            this.Text = "Popup";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox popupList;
    }
}