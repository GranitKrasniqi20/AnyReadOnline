using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnyReadOnline.Models;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using AnyReadOnline.Models.Interfaces;

namespace AnyReadOnline.DAL
{
    public class LanguageDAL : ICrud<Language>, IConvertToObject<Language>
    {
        private Language language;

        public int Add(Language obj) 
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_InsertLanguage", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("languageName", obj.LanguageName);
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

        public Language ConvertToObject(SqlDataReader sqlDataReader)
        {
            language = new Language();

            if (sqlDataReader["LanguageID"] != DBNull.Value)
            {
                language.LanguageID = int.Parse(sqlDataReader["LanguageID"].ToString());
            }
            if (sqlDataReader["Language"] != DBNull.Value)
            {
                language.LanguageName = sqlDataReader["Language"].ToString();
            }
            if (sqlDataReader["InsBy"] != DBNull.Value)
            {
                language.InsBy = (int)sqlDataReader["InsBy"];
            }
            if (sqlDataReader["InsDate"] != DBNull.Value)
            {
                language.InsDate = (DateTime)sqlDataReader["InsDate"];
            }
            if (sqlDataReader["UpdBy"] != DBNull.Value)
            {
                language.UpdBy = (int)sqlDataReader["UpdBy"];
            }
            if (sqlDataReader["UpdDate"] != DBNull.Value)
            {
                language.UpdDate = (DateTime)sqlDataReader["UpdDate"];
            }
            if (sqlDataReader["UpdNo"] != DBNull.Value)
            {
                language.UpdNo = (int)sqlDataReader["UpdNo"];
            }
            return language;
        }

        public int Delete(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_DeleteGenre", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("LanguageID", id);

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
        
        public Language Get(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetByIDLanguage", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("LanguageID", id);

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

        public List<Language> GetAll()
        {
            List<Language> Languages = new List<Language>();

            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetAllGenre", CommandType.StoredProcedure))
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
                                    Languages.Add(ConvertToObject(sqlDataReader));
                                }
                            }
                            return Languages;
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                return Languages;
            }
        }

        public int Update(Language obj)
        {
            try
            {
                using (var sqlConnection = DbHelper.GetConnection())
                {
                    using (var sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_UpdateLanguage", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("languageID", obj.LanguageID);
                        sqlCommand.Parameters.AddWithValue("languageName", obj.LanguageName);
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