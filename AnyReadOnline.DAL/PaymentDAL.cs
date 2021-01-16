using AnyReadOnline.BOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyReadOnline.DAL
{
    public class PaymentDAL
    {

            public int Add(Payment obj)
            {
                try
                {

                    using (SqlConnection sqlConnection = DbHelper.GetConnection())
                    {
                        using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_InsertPayment", CommandType.StoredProcedure))
                        {

                            sqlCommand.Parameters.AddWithValue("PaymentDate", DateTime.Now);
                            sqlCommand.Parameters.AddWithValue("OrderID", obj.OrderID);


                        

                        if (sqlCommand.ExecuteNonQuery() > 0)
                            {
                            return 1;
                            }
                            else
                            {
                                throw new Exception();
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
        
    }
}
