using System;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace Hotel
{
    static class OracleTools
    {
        public static void setConn()
        {
            const String connectionString = "Data Source  =  (DESCRIPTION = " +
           "(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))" +
           "(CONNECT_DATA =" +
           "  (SERVER = DEDICATED)" +
           "  (SERVICE_NAME = XE)" +
           ")" +
           ");User Id = system; password = support123;";

            m_connection.ConnectionString = connectionString;
            m_command.Connection = m_connection;
            m_command.CommandType = CommandType.Text;
        }

        public static void executeQuery(String commandText)
        {
            try
            {
                m_connection.Open();
                m_command.CommandText = commandText;

                m_reader = m_command.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n " + ex.ToString());
            }
        }

        public static void closeConn()
        {
            m_connection.Close();
        }

        public static OracleDataReader Reader { get => m_reader;}
        public static OracleCommand Command { get => m_command; }

        private static OracleConnection m_connection = new OracleConnection();
        private static OracleCommand m_command = new OracleCommand();
        private static OracleDataReader m_reader;
    }
}
