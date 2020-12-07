using AnyReadOnline.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace AnyReadOnline.DAL
{
    public class ClientDAL
    {
        public int Create(IClient obj)
        {
            int isInserted;
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.Command(sqlConnection, "usp_ClientRegister", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("FirstName", obj.FirstName);
                        sqlCommand.Parameters.AddWithValue("LastName", obj.LastName);
                        sqlCommand.Parameters.AddWithValue("Email", obj.Email);
                        sqlCommand.Parameters.AddWithValue("Gender", obj.Gender);


                        isInserted = sqlCommand.ExecuteNonQuery();

                        if (isInserted > 0)
                        {
                            return 1;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                return -1;
            }
        }
        public IClient GetById(IClient obj)
        {
            return null;
        }
        public IEnumerable<IClient> GetAll(IClient obj)
        {
            return null;
        }

        public int Update(IClient obj)
        {
            return 0;
        }
        public int Delete(int id)
        {
            return 0;
        }
    }
}