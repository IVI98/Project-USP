namespace Hotel
{
    partial class Reservations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reservations));
            this.buttonShowAll = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.reservationsDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.reservationsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonShowAll
            // 
            this.buttonShowAll.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonShowAll.Location = new System.Drawing.Point(38, 213);
            this.buttonShowAll.Name = "buttonShowAll";
            this.buttonShowAll.Size = new System.Drawing.Size(160, 47);
            this.buttonShowAll.TabIndex = 36;
            this.buttonShowAll.Text = "Show All Reservations";
            this.buttonShowAll.UseVisualStyleBackColor = false;
            this.buttonShowAll.Click += new System.EventHandler(this.buttonShowAll_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonLoad.Location = new System.Drawing.Point(460, 398);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(160, 47);
            this.buttonLoad.TabIndex = 37;
            this.buttonLoad.Text = "Hotel Load For Month";
            this.buttonLoad.UseVisualStyleBackColor = false;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonInsert
            // 
            this.buttonInsert.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonInsert.Location = new System.Drawing.Point(206, 398);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(160, 47);
            this.buttonInsert.TabIndex = 35;
            this.buttonInsert.Text = "Add";
            this.buttonInsert.UseVisualStyleBackColor = false;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(48, 24);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(35, 13);
            this.titleLabel.TabIndex = 34;
            this.titleLabel.Text = "label1";
            // 
            // reservationsDataGridView
            // 
            this.reservationsDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.reservationsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reservationsDataGridView.Location = new System.Drawing.Point(161, 65);
            this.reservationsDataGridView.Name = "reservationsDataGridView";
            this.reservationsDataGridView.Size = new System.Drawing.Size(504, 327);
            this.reservationsDataGridView.TabIndex = 33;
            // 
            // Reservations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(810, 465);
            this.Controls.Add(this.buttonShowAll);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.reservationsDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Reservations";
            this.Text = "Reservations";
            this.Load += new System.EventHandler(this.Reservations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reservationsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonShowAll;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.DataGridView reservationsDataGridView;
    }
}

