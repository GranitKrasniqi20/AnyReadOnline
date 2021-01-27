using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace AnyReadOnline.DAL
{
    class DbHelper
    {
        public static string ConnectionStringName()
        {
            //string pathGranit = "PC-GRANIT";
            //string pathBeis = "BEISPRESHEV9DEA";
            //string pathEndrit = "DESKTOP-CMMTF7M";

            //if (string.Equals(Environment.MachineName, pathGranit))
            //{
            //    return "DbConnectionGranit";
            //}
            //if (string.Equals(Environment.MachineName, pathBeis))
            //{
            //    return "DbConnectionBeis";
            //}
            //if (string.Equals(Environment.MachineName, pathEndrit))
            //{
            //    return "DbConnectionEndrit";
            //}
            //else return "";//ose throw new Exception;

            return "DbConnectionEndrit";
        }

        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings[ConnectionStringName()].ConnectionString;

        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                sqlConnection.Open();
                return sqlConnection;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot connect to Data Base server, please contact your administrator" +ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static SqlCommand SqlCommand(SqlConnection sqlConnection, string cmdText, CommandType commandType)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection)
                {
                    CommandType = commandType
                };
                return sqlCommand;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

