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
    public class StaffDAL : ICrud<Staff>, IReadByEmail<Staff>, IConvertToObject<Staff>
    {
        private Staff staff;

        public int Add(Staff obj)
        {
            staff = new Staff();

            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_ClientRegister", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("Username", obj.UserName);
                        sqlCommand.Parameters.AddWithValue("Name", obj.FirstName);
                        sqlCommand.Parameters.AddWithValue("LastName", obj.LastName);
                        sqlCommand.Parameters.AddWithValue("Email", obj.Email);
                        sqlCommand.Parameters.AddWithValue("InsBy", 1);
                        sqlCommand.Parameters.AddWithValue("RoleId", obj.Role.RoleID);
                        sqlCommand.Parameters.AddWithValue("CountryId", obj.Country.CountryID);
                        sqlCommand.Parameters.AddWithValue("Address", obj.Address);
                        sqlCommand.Parameters.AddWithValue("City", obj.City);
                        sqlCommand.Parameters.AddWithValue("PostalCode", obj.PostalCode);
                        sqlCommand.Parameters.AddWithValue("PhoneNumber", obj.PhoneNumber);

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

        public int Update(Staff obj)
        {
            try
            {
                using (var sqlConnection = DbHelper.GetConnection())
                {
                    using (var sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_UpdateUser", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("@email", obj.Email);
                        sqlCommand.Parameters.AddWithValue("@name", obj.FirstName);
                        sqlCommand.Parameters.AddWithValue("@lastname", obj.LastName);
                        sqlCommand.Parameters.AddWithValue("@updby", 1);

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

        public Staff Get(string email)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetUserByEmail", CommandType.StoredProcedure))
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

        public Staff Get(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetUserById", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("UserID", id);

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

        public List<Staff> GetAll()
        {
            List<Staff> staffs = new List<Staff>();

            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetAllUsers", CommandType.StoredProcedure))
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
                                    staffs.Add(ConvertToObject(sqlDataReader));
                                }
                            }
                            return staffs;
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
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_DeleteUser", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("UserID", id);

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

        public Staff ConvertToObject(SqlDataReader sqlDataReader)
        {
            staff = new Staff();

            if (sqlDataReader["UserID"] != DBNull.Value)
            {
                staff.UserID = int.Parse(sqlDataReader["UserID"].ToString());
            }
            if (sqlDataReader["RoleId"] != DBNull.Value)
            {
                staff.Role.RoleID = int.Parse(sqlDataReader["RoleId"].ToString());
                staff.Role.RoleName = sqlDataReader["Role"].ToString();
            }
            if (sqlDataReader["Username"] != DBNull.Value)
            {
                staff.UserName = sqlDataReader["Username"].ToString();
            }
            if (sqlDataReader["Name"] != DBNull.Value)
            {
                staff.FirstName = sqlDataReader["Name"].ToString();
            }
            if (sqlDataReader["LastName"] != DBNull.Value)
            {
                staff.LastName = sqlDataReader["LastName"].ToString();
            }
            if (sqlDataReader["Email"] != DBNull.Value)
            {
                staff.Email = sqlDataReader["Email"].ToString();
                staff.ConfirmEmail = sqlDataReader["Email"].ToString();
            }
            if (sqlDataReader["InsBy"] != DBNull.Value)
            {
                staff.InsBy = (int)sqlDataReader["InsBy"];
            }
            if (sqlDataReader["InsDate"] != DBNull.Value)
            {
                staff.InsDate = (DateTime)sqlDataReader["InsDate"];
            }
            if (sqlDataReader["UpdBy"] != DBNull.Value)
            {
                staff.UpdBy = (int)sqlDataReader["UpdBy"];
            }
            if (sqlDataReader["UpdDate"] != DBNull.Value)
            {
                staff.UpdDate = (DateTime)sqlDataReader["UpdDate"];
            }
            if (sqlDataReader["UpdNo"] != DBNull.Value)
            {
                staff.UpdNo = (int)sqlDataReader["UpdNo"];
            }

            return staff;
        }
    }
}
