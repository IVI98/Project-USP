namespace Hotel
{
    partial class HotelLoad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HotelLoad));
            this.signGoBack = new System.Windows.Forms.PictureBox();
            this.monthsComboBox = new System.Windows.Forms.ComboBox();
            this.selectLabel = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.signGoBack)).BeginInit();
            this.SuspendLayout();
            // 
            // signGoBack
            // 
            this.signGoBack.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.signGoBack.Image = ((System.Drawing.Image)(resources.GetObject("signGoBack.Image")));
            this.signGoBack.Location = new System.Drawing.Point(12, 180);
            this.signGoBack.Name = "signGoBack";
            this.signGoBack.Size = new System.Drawing.Size(138, 69);
            this.signGoBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.signGoBack.TabIndex = 17;
            this.signGoBack.TabStop = false;
            this.signGoBack.Click += new System.EventHandler(this.signGoBack_Click);
            // 
            // monthsComboBox
            // 
            this.monthsComboBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.monthsComboBox.FormattingEnabled = true;
            this.monthsComboBox.Location = new System.Drawing.Point(230, 69);
            this.monthsComboBox.Name = "monthsComboBox";
            this.monthsComboBox.Size = new System.Drawing.Size(212, 21);
            this.monthsComboBox.TabIndex = 18;
            // 
            // selectLabel
            // 
            this.selectLabel.AutoSize = true;
            this.selectLabel.Location = new System.Drawing.Point(81, 77);
            this.selectLabel.Name = "selectLabel";
            this.selectLabel.Size = new System.Drawing.Size(35, 13);
            this.selectLabel.TabIndex = 19;
            this.selectLabel.Text = "label1";
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonOK.Location = new System.Drawing.Point(367, 195);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 20;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // HotelLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(516, 261);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.selectLabel);
            this.Controls.Add(this.monthsComboBox);
            this.Controls.Add(this.signGoBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HotelLoad";
            this.Text = "HotelLoad";
            this.Load += new System.EventHandler(this.HotelLoad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.signGoBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox signGoBack;
        private System.Windows.Forms.ComboBox monthsComboBox;
        private System.Windows.Forms.Label selectLabel;
        private System.Windows.Forms.Button buttonOK;
    }
}