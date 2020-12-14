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
    public class AuthorDAL : ICrud<Author>, IConvertToObject<Author>
    {
        private Author author;

        public int Add(Author obj)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_InsertAuthor", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("firstName", obj.FirstName);
                        sqlCommand.Parameters.AddWithValue("lastName", obj.LastName);
                        sqlCommand.Parameters.AddWithValue("imagePath", obj.ImagePath);
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

        public Author ConvertToObject(SqlDataReader sqlDataReader)
        {
            author = new Author();

            if (sqlDataReader["AuthorID"] != DBNull.Value)
            {
                author.AuthorID = int.Parse(sqlDataReader["AuthorID"].ToString());
            }
            if (sqlDataReader["Name"] != DBNull.Value)
            {
                author.FirstName = sqlDataReader["Name"].ToString();
            }
            if (sqlDataReader["LastName"] != DBNull.Value)
            {
                author.LastName = sqlDataReader["LastName"].ToString();
            }
            if (sqlDataReader["ImagePath"] != DBNull.Value)
            {
                author.ImagePath = sqlDataReader["ImagePath"].ToString();
            }
            if (sqlDataReader["InsBy"] != DBNull.Value)
            {
                author.InsBy = (int)sqlDataReader["InsBy"];
            }
            if (sqlDataReader["InsDate"] != DBNull.Value)
            {
                author.InsDate = (DateTime)sqlDataReader["InsDate"];
            }
            if (sqlDataReader["UpdBy"] != DBNull.Value)
            {
                author.UpdBy = (int)sqlDataReader["UpdBy"];
            }
            if (sqlDataReader["UpdDate"] != DBNull.Value)
            {
                author.UpdDate = (DateTime)sqlDataReader["UpdDate"];
            }
            if (sqlDataReader["UpdNo"] != DBNull.Value)
            {
                author.UpdNo = (int)sqlDataReader["UpdNo"];
            }
            return author;
        }

        public int Delete(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_DeleteAuthor", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("AuthorID", id);

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

        public Author Get(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetByIDAuthor", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("AuthorID", id);
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

        public List<Author> GetAll()
        {
            List<Author> Authors = new List<Author>();

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
                                    Authors.Add(ConvertToObject(sqlDataReader));
                                }
                            }
                            return Authors;
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                return Authors;
            }
        }

        public int Update(Author obj)
        {
            try
            {
                using (var sqlConnection = DbHelper.GetConnection())
                {
                    using (var sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_UpdateAuthor", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("authorID", obj.AuthorID);
                        sqlCommand.Parameters.AddWithValue("firstName", obj.FirstName);
                        sqlCommand.Parameters.AddWithValue("lastName", obj.LastName);
                        sqlCommand.Parameters.AddWithValue("imagePath", obj.ImagePath);
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

        public List<Author> GetTop4EarliestAuthors()
        {
            List<Author> topAuthors = new List<Author>();

            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetTop4EarliestAuthors", CommandType.StoredProcedure))
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
                                    topAuthors.Add(ConvertToObject(sqlDataReader));
                                }
                            }
                            return topAuthors;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public List<Author> GetTop4LatestAuthors()
        {
            List<Author> topAuthors = new List<Author>();

            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetTop4LatestAuthors", CommandType.StoredProcedure))
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
                                    topAuthors.Add(ConvertToObject(sqlDataReader));
                                }
                            }
                            return topAuthors;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}