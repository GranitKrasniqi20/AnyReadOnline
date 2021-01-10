using AnyReadOnline.BOL;
using AnyReadOnline.BOL.Interfaces;
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
    public class OrderDetailsDAL 
    {
        List<OrderDetails> orderDetails;
        OrderDetails orderDetail;
        public OrderDetails ConvertToObject(SqlDataReader sqlDataReader)
        {
            try
            {
                orderDetail = new OrderDetails();

                orderDetail.OrderDetailsID = (int)sqlDataReader["OrderDetailsID"];

                BookDAL bookDAL = new BookDAL();
                orderDetail.BookID = (int)sqlDataReader["BookID"];
                orderDetail.Quantity = (int)sqlDataReader["Quantity"];
                orderDetail.OrderID = (int)sqlDataReader["OrderID"];
                orderDetail.Book = bookDAL.ConvertToObject(sqlDataReader);

                return orderDetail;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public int Add(OrderDetails obj)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_InsertOrderDetail", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("BookID", obj.BookID);
                        sqlCommand.Parameters.AddWithValue("Quantity", 1);
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



        public OrderDetails Get(int id)
        {
            List<OrderDetails> OrderDetails = new List<OrderDetails>();

            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetOrderDetailsByOrderId", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("OrderId", id);
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            if (sqlDataReader.HasRows)
                            {
                                while (sqlDataReader.Read())
                                {
                                    if (ConvertToObject(sqlDataReader) == null)
                                    {
                                        throw new Exception();
                                    }
                                    orderDetails.Add(ConvertToObject(sqlDataReader));
                                }
                            }
                            return orderDetail;
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

      
    }
}
