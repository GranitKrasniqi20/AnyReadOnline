using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using AnyReadOnline.BOL;
using AnyReadOnline.BOL.Interfaces;

namespace AnyReadOnline.DAL
{
    public class PublishHouseDAL : ICrud<PublishHouse>, IConvertToObject<PublishHouse>
    {
        private PublishHouse publishHouse;

        public int Add(PublishHouse obj)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_InsertPublishHouse", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("publishHouseName", obj.PublishHouseName);
                        sqlCommand.Parameters.AddWithValue("insBy", 1);// obj.InsBy);//Dergojme 1 derisa te krijojme User

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

        public PublishHouse ConvertToObject(SqlDataReader sqlDataReader)
        {
            publishHouse = new PublishHouse();

            if (sqlDataReader["PublishHouseID"] != DBNull.Value)
            {
                publishHouse.PublishHouseID = (int)sqlDataReader["PublishHouseID"];
            }
            if (sqlDataReader["PublishHouse"] != DBNull.Value)
            {
                publishHouse.PublishHouseName = sqlDataReader["publishHouse"].ToString();
            }
            if (sqlDataReader["InsBy"] != DBNull.Value)
            {
                publishHouse.InsBy = (int)sqlDataReader["InsBy"];
            }
            if (sqlDataReader["InsDate"] != DBNull.Value)
            {
                publishHouse.InsDate = (DateTime)sqlDataReader["InsDate"];
            }
            if (sqlDataReader["UpdBy"] != DBNull.Value)
            {
                publishHouse.UpdBy = (int)sqlDataReader["UpdBy"];
            }
            if (sqlDataReader["UpdDate"] != DBNull.Value)
            {
                publishHouse.UpdDate = (DateTime)sqlDataReader["UpdDate"];
            }
            if (sqlDataReader["UpdNo"] != DBNull.Value)
            {
                publishHouse.UpdNo = (int)sqlDataReader["UpdNo"];
            }
            return publishHouse;
        }

        public int Delete(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_DeletePublishHouse", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("PublishHouseID", id);

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

        public PublishHouse Get(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetByIDPublishHouse", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("PublishHouseID", id);
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
                return null;
            }
        }

        public List<PublishHouse> GetAll()
        {
            List<PublishHouse> publishHouses = new List<PublishHouse>();

            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetAllPublishHouse", CommandType.StoredProcedure))
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
                                    publishHouses.Add(ConvertToObject(sqlDataReader));
                                }
                            }
                            return publishHouses;
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                return publishHouses;
            }
        }

        public int Update(PublishHouse obj)
        {
            try
            {
                using (var sqlConnection = DbHelper.GetConnection())
                {
                    using (var sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_UpdatePublishHouse", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("publishHouseID", obj.PublishHouseID);
                        sqlCommand.Parameters.AddWithValue("publishHouseName", obj.PublishHouseName);
                        sqlCommand.Parameters.AddWithValue("updBy", 1);//obj.UpdBy);//Dergojme 1 derisa te krijojme User

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