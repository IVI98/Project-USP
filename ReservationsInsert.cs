using Oracle.DataAccess.Client;
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
    public partial class ReservationsInsert : Form
    {
        public ReservationsInsert()
        {
            InitializeComponent();
        }

        private void ReservationsInsert_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            titleLabel.Location = new Point(45, 0);
            titleLabel.ForeColor = Color.FromArgb(69, 23, 74);
            titleLabel.Font = new Font(new FontFamily("Times New Roman"), 50, FontStyle.Bold);
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.Text = "Insert a reservation: ";

            dateLabel.Text = "Date: ";
            dateLabel.Location = new Point(24, 110);
            dateLabel.ForeColor = Color.FromArgb(26, 6, 74);
            dateLabel.Font = new Font(new FontFamily("Times New Roman"), 30, FontStyle.Regular);
            dateLabel.TextAlign = ContentAlignment.MiddleCenter;

            periodLabel.Text = "Period: ";
            periodLabel.Location = new Point(24, 180);
            periodLabel.ForeColor = Color.FromArgb(26, 6, 74);
            periodLabel.Font = new Font(new FontFamily("Times New Roman"), 30, FontStyle.Regular);
            periodLabel.TextAlign = ContentAlignment.MiddleCenter;

            roomLabel.Text = "Room: ";
            roomLabel.Location = new Point(24, 250);
            roomLabel.ForeColor = Color.FromArgb(26, 6, 74);
            roomLabel.Font = new Font(new FontFamily("Times New Roman"), 30, FontStyle.Regular);
            roomLabel.TextAlign = ContentAlignment.MiddleCenter;

            clientLabel.Text = "Client: ";
            clientLabel.Location = new Point(24, 320);
            clientLabel.ForeColor = Color.FromArgb(26, 6, 74);
            clientLabel.Font = new Font(new FontFamily("Times New Roman"), 30, FontStyle.Regular);
            clientLabel.TextAlign = ContentAlignment.MiddleCenter;

            employeeLabel.Text = "Employee: ";
            employeeLabel.Location = new Point(24, 390);
            employeeLabel.ForeColor = Color.FromArgb(26, 6, 74);
            employeeLabel.Font = new Font(new FontFamily("Times New Roman"), 30, FontStyle.Regular);
            employeeLabel.TextAlign = ContentAlignment.MiddleCenter;

            insertedLabel.Visible = false;
            insertedLabel.Location = new Point(176, 498);
            insertedLabel.ForeColor = Color.FromArgb(162, 13, 20);
            insertedLabel.Font = new Font(new FontFamily("Times New Roman"), 24, FontStyle.Regular);
            insertedLabel.TextAlign = ContentAlignment.MiddleCenter;
            insertedLabel.Text = "Inserted successfully! ";

            dateTextBox.Location = new Point(140, 110);
            dateTextBox.ForeColor = Color.FromArgb(26, 6, 74);
            dateTextBox.Font = new Font(new FontFamily("Times New Roman"), 30, FontStyle.Regular);
            dateTextBox.TextAlign = HorizontalAlignment.Center;

            periodTextBox.Location = new Point(170, 180);
            periodTextBox.ForeColor = Color.FromArgb(26, 6, 74);
            periodTextBox.Font = new Font(new FontFamily("Times New Roman"), 30, FontStyle.Regular);
            periodTextBox.TextAlign = HorizontalAlignment.Center;

            buttonInsert.TabStop = false;
            buttonInsert.Location = new Point(480, 490);
            buttonInsert.Font = new Font(new FontFamily("Times New Roman"), 30, FontStyle.Italic);
            buttonInsert.ForeColor = Color.FromArgb(26, 6, 74);
            buttonInsert.TextAlign = ContentAlignment.MiddleCenter;
            buttonInsert.Size = new Size(180, 60);
            buttonInsert.Text = "Insert";
            buttonInsert.TabStop = false;

            roomsComboBox.Location = new Point(170, 250);
            roomsComboBox.ForeColor = Color.FromArgb(26, 6, 74);
            roomsComboBox.BackColor = Color.FromArgb(255, 252, 132);
            roomsComboBox.Font = new Font(new FontFamily("Times New Roman"), 30, FontStyle.Italic);
            roomsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            clientsComboBox.Location = new Point(170, 320);
            clientsComboBox.ForeColor = Color.FromArgb(26, 6, 74);
            clientsComboBox.BackColor = Color.FromArgb(255, 252, 132);
            clientsComboBox.Font = new Font(new FontFamily("Times New Roman"), 30, FontStyle.Italic);
            clientsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            employeesComboBox.Location = new Point(210, 390);
            employeesComboBox.ForeColor = Color.FromArgb(26, 6, 74);
            employeesComboBox.BackColor = Color.FromArgb(255, 252, 132);
            employeesComboBox.Font = new Font(new FontFamily("Times New Roman"), 30, FontStyle.Italic);
            employeesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            roomsComboBox.Items.Clear();
            clientsComboBox.Items.Clear();
            employeesComboBox.Items.Clear();

            m_dRooms.Clear();
            m_dClients.Clear();
            m_dEmployees.Clear();

            LoadRooms();
            LoadClients();
            LoadEmployees();

            if (roomsComboBox.Items.Count > 0)
            {
                roomsComboBox.SelectedIndex = 0;             
            }

            if (clientsComboBox.Items.Count > 0)
            {
                clientsComboBox.SelectedIndex = 0;
            }

            if (employeesComboBox.Items.Count > 0)
            {
                employeesComboBox.SelectedIndex = 0;
            }
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            insertedLabel.Visible = false;
            try
            {
                String date = dateTextBox.Text;
                String errMessage = "";
                if(!validateDate(date, ref errMessage))
                {
                    throw new Exception(errMessage);
                }

                if (periodTextBox.Text == "")
                {
                    throw new Exception("Enter period! ");
                }

                int period = Int32.Parse(periodTextBox.Text);

                if(period < 1)
                {
                    throw new Exception("Invalid period! ");
                }

                string roomNumber = roomsComboBox.GetItemText(roomsComboBox.SelectedItem);
                string clientName = clientsComboBox.GetItemText(clientsComboBox.SelectedItem);
                string employeeName = employeesComboBox.GetItemText(employeesComboBox.SelectedItem);
                Decimal roomID = -1;
                Decimal clientID = -1;
                Decimal employeeID = -1;

                foreach (KeyValuePair<Decimal, string> entry in m_dRooms)
                {
                    if (entry.Value == roomNumber)
                    {
                        roomID = entry.Key;
                        break;
                    }
                }

                foreach (KeyValuePair<Decimal, string> entry in m_dClients)
                {
                    if (entry.Value == clientName)
                    {
                        clientID = entry.Key;
                        break;
                    }
                }

                foreach (KeyValuePair<Decimal, string> entry in m_dEmployees)
                {
                    if (entry.Value == employeeName)
                    {
                        employeeID = entry.Key;
                        break;
                    }
                }

                if(roomID == -1)
                {
                    throw new Exception("Room number not selected!");
                }

                if (clientID == -1)
                {
                    throw new Exception("Client not selected!");
                }

                if (employeeID == -1)
                {
                    throw new Exception("Employee not selected!");
                }
              
                String query = "INSERT INTO RESERVATIONS(\"Date\", PERIOD, ROOMS_ROOM_ID, CLIENTS_CLIENT_ID, EMPLOYEES_EMPLOYEE_ID) VALUES('" + date + "'," + period + " , " + roomID + "," + clientID + "," + employeeID + ")";
                OracleTools.executeQuery(query);
                OracleTools.closeConn();
                insertedLabel.Visible = true;
            }

            catch (Exception message)
            {
                MessageBox.Show(message.ToString());
            }
        }

        private void LoadRooms()
        {
            try
            {
                string query = "SELECT * FROM ROOMS";
                OracleTools.executeQuery(query);
                OracleDataReader dataReader = OracleTools.Command.ExecuteReader();

                while (dataReader.Read())
                {
                    int roomID = Int32.Parse(dataReader["ROOM_ID"].ToString());
                    string roomNumber = dataReader["Number"].ToString();
                    m_dRooms.Add(roomID, roomNumber);
                    roomsComboBox.Items.Add(roomNumber);
                }

                OracleTools.closeConn();
            }

            catch (Exception e)
            {
                MessageBox.Show("Error " + e);
            }
        }

        private void LoadClients()
        {
            try
            {
                string query = "SELECT * FROM CLIENTS";
                OracleTools.executeQuery(query);
                OracleDataReader dataReader = OracleTools.Command.ExecuteReader();

                while (dataReader.Read())
                {
                    int clientID = Int32.Parse(dataReader["CLIENT_ID"].ToString());
                    string clientName = dataReader["NAME"].ToString();
                    m_dClients.Add(clientID, clientName);
                    clientsComboBox.Items.Add(clientName);
                }

                OracleTools.closeConn();
            }

            catch (Exception e)
            {
                MessageBox.Show("Error " + e);
            }
        }

        private void LoadEmployees()
        {
            try
            {
                string query = "SELECT * FROM EMPLOYEES";
                OracleTools.executeQuery(query);
                OracleDataReader dataReader = OracleTools.Command.ExecuteReader();

                while (dataReader.Read())
                {
                    int employeeID = Int32.Parse(dataReader["EMPLOYEE_ID"].ToString());
                    string employeeName = dataReader["NAME"].ToString();
                    m_dEmployees.Add(employeeID, employeeName);
                    employeesComboBox.Items.Add(employeeName);
                }

                OracleTools.closeConn();
            }

            catch (Exception e)
            {
                MessageBox.Show("Error " + e);
            }
        }

        private void signGoBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool validateDate(string date, ref string errMessage)
        {
            int day;
            int month;
            int year;

            if(date.Length < 10)
            {
                errMessage = "Invalid date! Date format is: MM / DD / YYYY ";
                return false;
            }

            Int32.TryParse(date.Substring(3, 2), out day);
            Int32.TryParse(date.Substring(0, 2), out month);          
            Int32.TryParse(date.Substring(6), out year);           

            if (day < 1) 
            {
                errMessage = "Incorrect day ";
                return false;
            }

            else if (month < 1 || month > 12)
            {
                errMessage = "Incorrect month ";
                return false;
            }

            else
            {
                switch (month)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        if (day > 31)
                        {
                            errMessage = "Error! This month has too many days! ";
                            return false;
                        }

                        break;

                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        if (day > 30)
                        {
                            errMessage = "Error! This month has too many days! ";
                            return false;
                        }

                        break;

                    case 2:
                        if (year % 4 == 0)
                        {
                            if (day > 29)
                            {
                                errMessage = "Error! This month has too many days! ";
                                return false;
                            }
                        }

                        else
                        {
                            if (day > 28)
                            {
                                errMessage = "Error! This month has too many days! ";
                                return false;
                            }
                        }

                        break;
                }
            }

            return true;
        }

        private static Dictionary<Decimal, string> m_dRooms = new Dictionary<Decimal, string>();
        private static Dictionary<Decimal, string> m_dClients = new Dictionary<Decimal, string>();
        private static Dictionary<Decimal, string> m_dEmployees = new Dictionary<Decimal, string>();
    }
}
