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
    public class AddressDAL : ICrud<Address>, IConvertToObject<Address>
    {
        private Address address;

        public int Add(Address obj)
        {
            address = new Address();

            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_InsertAddress", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("ClientID", obj.ClientID);
                        sqlCommand.Parameters.AddWithValue("Name", obj.FirstName);
                        sqlCommand.Parameters.AddWithValue("LastName", obj.LastName);
                        sqlCommand.Parameters.AddWithValue("Address1", obj.Address1);

                        sqlCommand.Parameters.AddWithValue("PhoneNo", obj.PhoneNumber);
                        sqlCommand.Parameters.AddWithValue("PostalCode", obj.PostalCode);
                        sqlCommand.Parameters.AddWithValue("City", obj.City);
                        sqlCommand.Parameters.AddWithValue("CountryID", obj.CountryID);

                        sqlCommand.Parameters.AddWithValue("InsBy", 1);
                        sqlCommand.Parameters.AddWithValue("Email", obj.Email);



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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public int Update(Address obj)
        {
            try
            {
                using (var sqlConnection = DbHelper.GetConnection())
                {
                    using (var sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_UpdateAddress", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("AddressID", obj.AddressID);
                        sqlCommand.Parameters.AddWithValue("ClientID", obj.ClientID);
                        sqlCommand.Parameters.AddWithValue("Name", obj.FirstName);
                        sqlCommand.Parameters.AddWithValue("LastName", obj.LastName);
                        sqlCommand.Parameters.AddWithValue("Address1", obj.Address1);
                        sqlCommand.Parameters.AddWithValue("Address2", obj.Address2);
                        sqlCommand.Parameters.AddWithValue("Email", obj.Email);
                        sqlCommand.Parameters.AddWithValue("PhoneNo", obj.PhoneNumber);
                        sqlCommand.Parameters.AddWithValue("PostalCode", obj.PostalCode);
                        sqlCommand.Parameters.AddWithValue("City", obj.City);
                        sqlCommand.Parameters.AddWithValue("CountryID", obj.CountryID);
                        sqlCommand.Parameters.AddWithValue("updby", 1);
                        sqlCommand.Parameters.AddWithValue("Email", obj.Email);

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
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public Address Get(int id)
        {
            address = new Address();

            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetAddressById", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("AddressID", id);

                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            if (sqlDataReader.Read())
                            {
                                return ConvertToObject(sqlDataReader);
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
                throw new Exception();
            }
        }

        public List<Address> GetByClientID(int clientID)
        {
            List<Address> addresses = new List<Address>();

            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetAddressByClientId", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("@ClientID", clientID);

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
                                    addresses.Add(ConvertToObject(sqlDataReader));
                                }
                            }
                            return addresses;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public List<Address> GetAll()
        {
            List<Address> addresses = new List<Address>();

            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetAllAddresses", CommandType.StoredProcedure))
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
                                    addresses.Add(ConvertToObject(sqlDataReader));
                                }
                            }
                            return addresses;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public int Delete(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_DeleteAddress", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("AddressID", id);

                        if (sqlCommand.ExecuteNonQuery() > 0)
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
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public Address ConvertToObject(SqlDataReader sqlDataReader)
        {
            address = new Address();
            address.Client = new Client();
            address.Country = new Country();

            if (sqlDataReader["AddressId"] != DBNull.Value)
            {
                address.AddressID = int.Parse(sqlDataReader["AddressId"].ToString());
            }
            if (sqlDataReader["ClientID"] != DBNull.Value)
            {
                address.ClientID = (int)sqlDataReader["ClientID"];
                address.Client.UserID = (int)sqlDataReader["ClientID"];
                address.Client.FirstName = sqlDataReader["FIrstName"].ToString();
                address.Client.LastName = sqlDataReader["LastName"].ToString();
                address.Client.Email = sqlDataReader["Email"].ToString();
            }
            if (sqlDataReader["AddressFirstName"] != DBNull.Value)
            {
                address.FirstName = sqlDataReader["AddressFirstName"].ToString();
            }
            if (sqlDataReader["AddressLastName"] != DBNull.Value)
            {
                address.LastName = sqlDataReader["AddressLastName"].ToString();
            }
            if (sqlDataReader["Address1"] != DBNull.Value)
            {
                address.Address1 = sqlDataReader["Address1"].ToString();
            }
            if (sqlDataReader["AddressPhoneNumber"] != DBNull.Value)
            {
                address.PhoneNumber = sqlDataReader["AddressPhoneNumber"].ToString();
            }

            if (sqlDataReader["AddressEmail"] != DBNull.Value)
            {
                address.Email = sqlDataReader["AddressEmail"].ToString();
            }
            if (sqlDataReader["PostalCode"] != DBNull.Value)
            {
                address.PostalCode = sqlDataReader["PostalCode"].ToString();
            }
            if (sqlDataReader["City"] != DBNull.Value)
            {
                address.City = sqlDataReader["City"].ToString();
            }
            if (sqlDataReader["CountryID"] != DBNull.Value)
            {
                address.CountryID = int.Parse(sqlDataReader["CountryID"].ToString());
                address.Country.CountryID = int.Parse(sqlDataReader["CountryID"].ToString());
                address.Country.CountryName = sqlDataReader["CountryName"].ToString();
            }
            if (sqlDataReader["InsBy"] != DBNull.Value)
            {
                address.InsBy = (int)sqlDataReader["InsBy"];
            }
            if (sqlDataReader["InsDate"] != DBNull.Value)
            {
                address.InsDate = (DateTime)sqlDataReader["InsDate"];
            }
            if (sqlDataReader["UpdBy"] != DBNull.Value)
            {
                address.UpdBy = (int)sqlDataReader["UpdBy"];
            }
            if (sqlDataReader["UpdDate"] != DBNull.Value)
            {
                address.UpdDate = (DateTime)sqlDataReader["UpdDate"];
            }
            if (sqlDataReader["UpdNo"] != DBNull.Value)
            {
                address.UpdNo = (int)sqlDataReader["UpdNo"];
            }
            if (true)
            {

            }
            return address;
        }
    }
}
