using AnyReadOnline.BOL;
using AnyReadOnline.BOL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.DAL
{
    public class ClientDAL : ICrud<Client>, IReadByEmail<Client>, IConvertToObject<Client>
    {
        private Client client;

        public int Add(Client obj)
        {
            client = new Client();

            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_ClientRegister", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("FirstName", obj.FirstName);
                        sqlCommand.Parameters.AddWithValue("LastName", obj.LastName);
                        sqlCommand.Parameters.AddWithValue("Email", obj.Email);
                        sqlCommand.Parameters.AddWithValue("Gender", obj.Gender);
                        sqlCommand.Parameters.AddWithValue("PhoneNumber", obj.PhoneNo);

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

        public int Update(Client obj)
                        {
            try
            {
                using (var sqlConnection = DbHelper.GetConnection())
                {
                    using (var sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_UpdateClient", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("firstname", obj.FirstName);
                        sqlCommand.Parameters.AddWithValue("lastname", obj.LastName);
                        sqlCommand.Parameters.AddWithValue("email", obj.Email);
                        sqlCommand.Parameters.AddWithValue("gender", obj.Gender);
                        sqlCommand.Parameters.AddWithValue("PhoneNumber", obj.PhoneNo);

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

        public Client Get(string email)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetClientByEmail", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("email", email);

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

        public Client Get(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetClientById", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("ClientID", id);

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

        public List<Client> GetAll()
        {
            List<Client> clients = new List<Client>();

            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetAllClients", CommandType.StoredProcedure))
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
                                    clients.Add(ConvertToObject(sqlDataReader));
                                }
                            }
                            return clients;
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
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_DeleteClient", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("ClientID", id);

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

        public Client ConvertToObject(SqlDataReader sqlDataReader)
        {
            client = new Client();

            if (sqlDataReader["ClientID"] != DBNull.Value)
            {
                client.UserID = int.Parse(sqlDataReader["ClientID"].ToString());
            }
            if (sqlDataReader["FIrstName"] != DBNull.Value)
            {
                client.FirstName = sqlDataReader["FIrstName"].ToString();
            }
            if (sqlDataReader["LastName"] != DBNull.Value)
            {
                client.LastName = sqlDataReader["LastName"].ToString();
            }
            if (sqlDataReader["Email"] != DBNull.Value)
            {
                client.Email = sqlDataReader["Email"].ToString();
                client.ConfirmEmail = sqlDataReader["Email"].ToString();
            }

            if (sqlDataReader["PhoneNo"] != DBNull.Value)
            {
                client.PhoneNo = sqlDataReader["PhoneNo"].ToString();
            }
            if (sqlDataReader["InsDate"] != DBNull.Value)
            {
                client.InsDate = (DateTime)sqlDataReader["InsDate"];
            }
            if (sqlDataReader["UpdDate"] != DBNull.Value)
            {
                client.UpdDate = (DateTime)sqlDataReader["UpdDate"];
            }
            if (sqlDataReader["UpdNo"] != DBNull.Value)
            {
                client.UpdNo = (int)sqlDataReader["UpdNo"];
            }

            return client;
        }
    }
}