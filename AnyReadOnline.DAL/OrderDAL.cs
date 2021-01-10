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
    public class OrderDAL : ICrud<Order>
    {
        Order order;


        public Order ConvertToObject(SqlDataReader sqlDataReader)
        {
            try
            {
                order = new Order();


                order.OrderID = (int)sqlDataReader["OrderID"];

                ClientDAL clientDAL = new ClientDAL();
                order.ClientID = (int)sqlDataReader["ClientID"];
                order.Client = clientDAL.ConvertToObject(sqlDataReader);
                AddressDAL address = new AddressDAL();
                order.ShippingAddress = address.ConvertToObject(sqlDataReader);
                order.ShippingAddressID = (int)sqlDataReader["ShippingAddress"];
                order.ShippingFee = (double)sqlDataReader["ShippingFee"];
                order.ArrivalDate = (DateTime)sqlDataReader["ArrivalDate"];
                order.ShippingCompanyID = (int)sqlDataReader["ShippingCompanyID"];

                order.ShippingCompany.ShippingCompanyID = (int)sqlDataReader["ShippingCompanyID"];
                order.ShippingCompany.ShippingCompanyID = (int)sqlDataReader["ShippingCompanyName"];

                return order;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public int Add(Order obj)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_CreateOrder", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("ClientID", obj.ClientID);
                        sqlCommand.Parameters.AddWithValue("ShippingAddressID", obj.ShippingAddressID);
                        sqlCommand.Parameters.AddWithValue("ShippingFee", obj.ShippingFee);
                        sqlCommand.Parameters.AddWithValue("ArrivalDate", obj.ArrivalDate);
                        sqlCommand.Parameters.AddWithValue("ShippingCompanyID", obj.ShippingCompanyID);
                        sqlCommand.Parameters.AddWithValue("ShippingOrderId", obj.ShippingOrderId);

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

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Order Get(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetByIDAuthor", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("OrderId", id);
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            if (sqlDataReader.Read())
                            {
                                Order order = ConvertToObject(sqlDataReader);
                                if (order != null)
                                {
                                    return order;
                                }
                                else
                                {
                                    throw new NotImplementedException();
                                }
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Order> GetAll()
        {
            List<Order> Orders = new List<Order>();

            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetAllAuthor", CommandType.StoredProcedure))
                    {
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
                                    Orders.Add(ConvertToObject(sqlDataReader));
                                }
                            }
                            return Orders;
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

        public int Update(Order obj)
        {
            throw new NotImplementedException();
        }

        //public int Update(Order obj)
        //{
        //    try
        //    {
        //        using (var sqlConnection = DbHelper.GetConnection())
        //        {
        //            using (var sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_UpdateAuthor", CommandType.StoredProcedure))
        //            {
        //                sqlCommand.Parameters.AddWithValue("OrderID", obj.OrderID);
        //                sqlCommand.Parameters.AddWithValue("ClientID", obj.ClientID);
        //                sqlCommand.Parameters.AddWithValue("ShippingAddressID", obj.ShippingAddressID);
        //                sqlCommand.Parameters.AddWithValue("ShippingFee", obj.ShippingFee);
        //                sqlCommand.Parameters.AddWithValue("ArrivalDate", obj.ArrivalDate);
        //                sqlCommand.Parameters.AddWithValue("ShippingCompanyID", obj.ShippingCompanyID);
        //                sqlCommand.Parameters.AddWithValue("updBy", 1);//obj.UpdBy);//Dergojme 1 derisa te krijojme User

        //                if (sqlCommand.ExecuteNonQuery() > 0)
        //                {
        //                    return 1;
        //                }
        //                else
        //                {
        //                    throw new Exception();
        //                }
        //            }
        //        }
        //    }
        //    catch (SqlException e)
        //    {
        //        MessageBox.Show(e.Message);
        //        return -1;
        //    }
        //}
    }
}
