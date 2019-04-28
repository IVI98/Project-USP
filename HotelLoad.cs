using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class HotelLoad : Form
    {
        public HotelLoad()
        {
            InitializeComponent();
        }

        private void HotelLoad_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            selectLabel.Location = new Point(24, 50);
            selectLabel.ForeColor = Color.FromArgb(26, 6, 74);
            selectLabel.Font = new Font(new FontFamily("Times New Roman"), 30, FontStyle.Regular);
            selectLabel.TextAlign = ContentAlignment.MiddleCenter;
            selectLabel.Text = "Select month: ";

            buttonOK.TabStop = false;
            buttonOK.Location = new Point(324, 184);
            buttonOK.Font = new Font(new FontFamily("Times New Roman"), 30, FontStyle.Italic);
            buttonOK.ForeColor = Color.FromArgb(26, 6, 74);
            buttonOK.TextAlign = ContentAlignment.MiddleCenter;
            buttonOK.Size = new Size(180, 60);
            buttonOK.Text = "Submit";
            buttonOK.TabStop = false;

            monthsComboBox.Location = new Point(272, 50);
            monthsComboBox.ForeColor = Color.FromArgb(26, 6, 74);
            monthsComboBox.BackColor = Color.FromArgb(255, 252, 132);
            monthsComboBox.Font = new Font(new FontFamily("Times New Roman"), 30, FontStyle.Italic);
            monthsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            monthsComboBox.Items.Clear();

            String[] arrMonths = new String[]{"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};

            for (int i = 0; i < arrMonths.Length; ++i)
            {
                monthsComboBox.Items.Add(arrMonths[i]);
            }

            monthsComboBox.SelectedIndex = 0;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int selectedMonth = monthsComboBox.SelectedIndex + 1;
            Reservations.Month = selectedMonth < 10 ? "0" + selectedMonth : selectedMonth.ToString();
            this.Close();
        }

        private void signGoBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
