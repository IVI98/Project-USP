using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;


namespace Hotel
{
    public partial class Reservations : Form
    {
        public Reservations()
        {
            InitializeComponent();
            m_openInsert = new ReservationsInsert();
            m_openLoad = new HotelLoad();
            reservationsDataGridView.Visible = false;
            reservationsDataGridView.AllowUserToAddRows = false;
            OracleTools.setConn();
        }

        private void Reservations_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            titleLabel.Location = new Point(174, 0);
            titleLabel.ForeColor = Color.FromArgb(69, 23, 74);
            titleLabel.Font = new Font(new FontFamily("Times New Roman"), 40, FontStyle.Bold);
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.Text = "Table Reservations";

            buttonShowAll.TabStop = false;
            buttonShowAll.ForeColor = Color.FromArgb(26, 6, 74);
            buttonShowAll.Location = new Point(0, 199);

            buttonInsert.TabStop = false;
            buttonInsert.ForeColor = Color.FromArgb(26, 6, 74);
            buttonInsert.Visible = false;

            buttonLoad.TabStop = false;
            buttonLoad.ForeColor = Color.FromArgb(26, 6, 74);
            buttonLoad.Visible = false;
        }

        private void buttonShowAll_Click(object sender, EventArgs e)
        {
            m_dataTable = new DataTable();
       
            changeAttributesStatus();
            String query = "SELECT \"Date\", PERIOD, \"Number\" AS Room, c.\"NAME\" AS CLIENT, e.\"NAME\" AS EMPLOYEE FROM RESERVATIONS res JOIN CLIENTS c ON(res.CLIENTS_CLIENT_ID = c.CLIENT_ID) JOIN EMPLOYEES e ON(res.EMPLOYEES_EMPLOYEE_ID = e.EMPLOYEE_ID) JOIN ROOMS r ON (res.ROOMS_ROOM_ID = r.ROOM_ID) WHERE TO_DATE(\"Date\", 'mm/dd/yyyy') >= TRUNC(TO_DATE(TO_CHAR(SYSDATE, 'mm/dd/yyyy'), 'mm/dd/yyyy') - PERIOD)";
            OracleTools.executeQuery(query);
            
            m_dataTable.Load(OracleTools.Reader);

            OracleTools.closeConn();

            reservationsDataGridView.DataSource = m_dataTable;
            reservationsDataGridView.RowHeadersVisible = false;
            reservationsDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            reservationsDataGridView.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;           
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            this.Hide();
            m_openInsert.ShowDialog();            
            changeAttributesStatus();
            buttonShowAll_Click(sender, e);
            this.Show();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            this.Hide();
            m_sMonth = "";
            m_openLoad.ShowDialog();
            m_dataTable = new DataTable();

            changeAttributesStatus();
            if (m_sMonth.CompareTo("") == 0)
            {
                this.Show();
                return;
            }
            String query = "SELECT \"Date\", PERIOD, \"Number\" AS Room, c.\"NAME\" AS CLIENT, e.\"NAME\" AS EMPLOYEE FROM RESERVATIONS res JOIN CLIENTS c ON(res.CLIENTS_CLIENT_ID = c.CLIENT_ID) JOIN EMPLOYEES e ON(res.EMPLOYEES_EMPLOYEE_ID = e.EMPLOYEE_ID) JOIN ROOMS r ON (res.ROOMS_ROOM_ID = r.ROOM_ID) WHERE TO_CHAR(TO_DATE(\"Date\", 'mm/dd/yyyy'), 'mm') = " + m_sMonth + " OR TO_CHAR(TO_DATE(\"Date\", 'mm/dd/yyyy') + Period, 'mm') = " + m_sMonth;
            OracleTools.executeQuery(query);

            m_dataTable.Load(OracleTools.Reader);

            OracleTools.closeConn();

            reservationsDataGridView.DataSource = m_dataTable;
            reservationsDataGridView.RowHeadersVisible = false;
            reservationsDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            reservationsDataGridView.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            buttonShowAll.Text = "Hide Table";
            this.Show();
        }
        
        private void changeAttributesStatus()
        {
            reservationsDataGridView.Visible = !reservationsDataGridView.Visible;
            buttonInsert.Visible = !buttonInsert.Visible;
            buttonLoad.Visible = !buttonLoad.Visible;

            if (reservationsDataGridView.Visible == false)
            {
                buttonShowAll.Text = "Show All Reservations";
            }

            else
            {
                buttonShowAll.Text = "Hide Table";               
            }
        }

        public static String Month { set => m_sMonth = value; }

        private static DataTable m_dataTable;
        private ReservationsInsert m_openInsert;
        private HotelLoad m_openLoad;
      

        private static String m_sMonth;
    }
}

