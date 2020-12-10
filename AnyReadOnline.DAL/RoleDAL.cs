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
    public class RoleDAL : IRead<Role>, IConvertToObject<Role>
    {
        private Role role;

        public Role Get(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetRoleByID", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("roleID", id);
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

        public List<Role> GetAll()
        {
            List<Role> roles = new List<Role>();

            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetAllRoles", CommandType.StoredProcedure))
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
                                    roles.Add(ConvertToObject(sqlDataReader));
                                }
                            }
                            return roles;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public Role ConvertToObject(SqlDataReader sqlDataReader)
        {
            role = new Role();

            if (sqlDataReader["RoleID"] != DBNull.Value)
            {
                role.RoleID = int.Parse(sqlDataReader["RoleID"].ToString());
            }
            if (sqlDataReader["Role"] != DBNull.Value)
            {
                role.RoleName = sqlDataReader["Role"].ToString();
            }
            if (sqlDataReader["InsBy"] != DBNull.Value)
            {
                role.InsBy = (int)sqlDataReader["InsBy"];
            }
            if (sqlDataReader["InsDate"] != DBNull.Value)
            {
                role.InsDate = (DateTime)sqlDataReader["InsDate"];
            }
            if (sqlDataReader["UpdBy"] != DBNull.Value)
            {
                role.UpdBy = (int)sqlDataReader["UpdBy"];
            }
            if (sqlDataReader["UpdDate"] != DBNull.Value)
            {
                role.UpdDate = (DateTime)sqlDataReader["UpdDate"];
            }
            if (sqlDataReader["UpdNo"] != DBNull.Value)
            {
                role.UpdNo = (int)sqlDataReader["UpdNo"];
            }

            return role;
        }
    }
}
