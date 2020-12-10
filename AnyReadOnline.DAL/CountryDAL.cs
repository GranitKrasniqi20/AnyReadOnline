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
    public class CountryDAL : ICrud<Country>, IConvertToObject<Country>
    {
        private Country country;

        public int Add(Country obj)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_InsertCountry", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("country", obj.CountryName);
                        sqlCommand.Parameters.AddWithValue("insBy", 1);

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

        public int Delete(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_DeleteCountry", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("countryID", id);

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

        public Country Get(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetCountryByID", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("countryID", id);
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

        public List<Country> GetAll()
        {
            List<Country> countries = new List<Country>();

            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetAllCountries", CommandType.StoredProcedure))
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
                                    countries.Add(ConvertToObject(sqlDataReader));
                                }
                            }
                            return countries;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public int Update(Country obj)
        {
            try
            {
                using (var sqlConnection = DbHelper.GetConnection())
                {
                    using (var sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_UpdateCountry", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("countryID", obj.CountryID);
                        sqlCommand.Parameters.AddWithValue("country", obj.CountryName);
                        sqlCommand.Parameters.AddWithValue("updby", 1);

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

        public Country ConvertToObject(SqlDataReader sqlDataReader)
        {
            country = new Country();

            if (sqlDataReader["CountryID"] != DBNull.Value)
            {
                country.CountryID = int.Parse(sqlDataReader["CountryID"].ToString());
            }
            if (sqlDataReader["Country"] != DBNull.Value)
            {
                country.CountryName = sqlDataReader["Country"].ToString();
            }
            if (sqlDataReader["InsBy"] != DBNull.Value)
            {
                country.InsBy = (int)sqlDataReader["InsBy"];
            }
            if (sqlDataReader["InsDate"] != DBNull.Value)
            {
                country.InsDate = (DateTime)sqlDataReader["InsDate"];
            }
            if (sqlDataReader["UpdBy"] != DBNull.Value)
            {
                country.UpdBy = (int)sqlDataReader["UpdBy"];
            }
            if (sqlDataReader["UpdDate"] != DBNull.Value)
            {
                country.UpdDate = (DateTime)sqlDataReader["UpdDate"];
            }
            if (sqlDataReader["UpdNo"] != DBNull.Value)
            {
                country.UpdNo = (int)sqlDataReader["UpdNo"];
            }

            return country;
        }
    }
}
