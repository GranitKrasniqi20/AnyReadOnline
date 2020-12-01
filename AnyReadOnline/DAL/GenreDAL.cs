using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnyReadOnline.Models;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace AnyReadOnline.DAL
{
    class GenreDAL
    {
        private Genre genre;

        public int Add(Genre genre)
        {
            int isInserted;
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.Command(sqlConnection, "usp_CreateGenre", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("genreName", genre.GenreName);
                        //sqlCommand.Parameters.AddWithValue("insBy", genre.InsBy);
                        //sqlCommand.Parameters.AddWithValue("insDate", genre.InsDate);
                        //sqlCommand.Parameters.AddWithValue("updBy", genre.UpdBy);
                        //sqlCommand.Parameters.AddWithValue("updDate", genre.UpdDate);
                        //sqlCommand.Parameters.AddWithValue("updNo", genre.UpdNo);

                        isInserted = sqlCommand.ExecuteNonQuery();

                        if (isInserted > 0)
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
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                return -1;
            }
        } 

        public int Delete(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.Command(sqlConnection, "usp_DeleteGenre", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("GenreID", id);
                        int Affected = sqlCommand.ExecuteNonQuery();

                        if (Affected > 0)
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
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                return -1;
            }
        }

        public Genre GetByID(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.Command(sqlConnection, "usp_GetByIDGenre", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("GenreID", id);
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            if (sqlDataReader.Read())
                            {
                                genre = new Genre();
                                genre=ConvertToObject(sqlDataReader);
                                return genre;

                                //or only: return ConvertToObject(sqlDataReader);
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

            using (SqlConnection sqlConnection = DbHelper.GetConnection())
            {
                using (SqlCommand sqlCommand = DbHelper.Command(sqlConnection, "usp_GetAllGenre", CommandType.StoredProcedure))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                                genre = new Genre();
                                genre = ConvertToObject(sqlDataReader);

                                if (genre == null)
                                {
                                    throw new Exception();
                                }

                                Genres.Add(genre);
                            }
                        }
                        return Genres;
                    }
                }
            }
        }

        public int Update(Genre genre)
        {
            int rowsAffected;
            try
            {
                using (var sqlConnection = DbHelper.GetConnection())
                {
                    using (var sqlCommand = DbHelper.Command(sqlConnection, "usp_UpdateGenre", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("genreID", genre.GenreID);
                        sqlCommand.Parameters.AddWithValue("genreName", genre.GenreName);
                        rowsAffected = sqlCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
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

        public Genre ConvertToObject(SqlDataReader reader)
        {
            genre = new Genre();

            genre.GenreID = int.Parse(reader["GenreID"].ToString());
            genre.GenreName = reader["Genre"].ToString();

            //genre.InsBy = int.Parse(sqlDataReader["InsBy"].ToString());
            //genre.InsDate = (DateTime)sqlDataReader["InsDate"];

            //if (sqlDataReader["UpdBy"] != DBNull.Value)
            //{
            //genre.UpdBy = int.Parse(sqlDataReader["UpdBy"].ToString());
            //}
            //if (sqlDataReader["UpdDate"] != DBNull.Value)
            //{
            //genre.UpdDate = DateTime.Parse(sqlDataReader["UpdDate"].ToString());
            //}

            //genre.UpdNo = int.Parse(sqlDataReader["UpdNo"].ToString());

            return genre;
        }
    }
}
