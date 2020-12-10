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
<<<<<<< HEAD:AnyReadOnline/DAL/DbHelper.cs
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["DbConnectionGranit"].ConnectionString;
        
=======
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DbConnectionBeis"].ConnectionString;

>>>>>>> a290ad17163e9f056325b03b0cfd3ae4bdd834c0:AnyReadOnline.DAL/DbHelper.cs
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

