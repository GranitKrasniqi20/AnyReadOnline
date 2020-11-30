using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnyReadOnline.Models;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace AnyReadOnline.DAL
{
    class CountryDAL
    {
        private Country country;

        public int Add(Country country)
        {
            int isInserted;
            try
            {
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    using (SqlCommand command = DbHelper.Command(conn, "usp_Subscribers_Insert", CommandType.StoredProcedure))
                    {

                        command.Parameters.AddWithValue("insBy", country.InsBy);

                        isInserted = command.ExecuteNonQuery();
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
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }
    }
}
