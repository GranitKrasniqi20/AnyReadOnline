using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using AnyReadOnline.BOL;
using AnyReadOnline.BOL.Interfaces;

namespace AnyReadOnline.DAL
{
    public class GenreDAL : ICrud<Genre>, IConvertToObject<Genre>
    {
        private Genre genre;

        public int Add(Genre obj)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_InsertGenre", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("genreName", obj.GenreName);
                        sqlCommand.Parameters.AddWithValue("insBy", 1);// obj.InsBy);//Dergojme 3 derisa te krijojme User

                        //SqlParameter sqlParameter = new SqlParameter();
                        //sqlParameter.ParameterName = "GenreID";
                        //sqlParameter.SqlDbType = SqlDbType.Int;
                        //sqlParameter.Direction = ParameterDirection.Output;
                        //sqlCommand.Parameters.Add(sqlParameter);
                        //int GenreID = (int)sqlParameter.Value; 

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

        public Genre ConvertToObject(SqlDataReader sqlDataReader)
        {
            genre = new Genre();

            if (sqlDataReader["GenreID"] != DBNull.Value)
            {
                genre.GenreID = int.Parse(sqlDataReader["GenreID"].ToString());
            }
            if (sqlDataReader["Genre"] != DBNull.Value)
            {
                genre.GenreName = sqlDataReader["Genre"].ToString();
            }
            if (sqlDataReader["InsBy"] != DBNull.Value)
            {
                genre.InsBy = (int)sqlDataReader["InsBy"];
            }
            if (sqlDataReader["InsDate"] != DBNull.Value)
            {
                genre.InsDate = (DateTime)sqlDataReader["InsDate"];
            }
            if (sqlDataReader["UpdBy"] != DBNull.Value)
            {
                genre.UpdBy = (int)sqlDataReader["UpdBy"];
            }
            if (sqlDataReader["UpdDate"] != DBNull.Value)
            {
                genre.UpdDate = (DateTime)sqlDataReader["UpdDate"];
            }
            if (sqlDataReader["UpdNo"] != DBNull.Value)
            {
                genre.UpdNo = (int)sqlDataReader["UpdNo"];
            }
            return genre;
        }

        public int Delete(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_DeleteGenre", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("genreID", id);

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

        public Genre Get(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetByIDGenre", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("genreID", id);
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

        public List<Genre> GetAll()
        {
            List<Genre> Genres = new List<Genre>();

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
                                    Genres.Add(ConvertToObject(sqlDataReader));
                                }
                            }
                            return Genres;
                        }
                    }
                }
            }
            catch(SqlException e)
            {
                MessageBox.Show(e.Message);
                return Genres;
            }
        }

        public int Update(Genre obj)
        {
            try
            {
                using (var sqlConnection = DbHelper.GetConnection())
                {
                    using (var sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_UpdateGenre", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("genreID", obj.GenreID);
                        sqlCommand.Parameters.AddWithValue("genreName", obj.GenreName);
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

        public List<Genre> GetTop4Genres()
        {
            List<Genre> Genres = new List<Genre>();

            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetTop4Genres", CommandType.StoredProcedure))
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
                                    Genres.Add(ConvertToObject(sqlDataReader));
                                }
                            }
                            return Genres;
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                return Genres;
            }
        }
    }
}
