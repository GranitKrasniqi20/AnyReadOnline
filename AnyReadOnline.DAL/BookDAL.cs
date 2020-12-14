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
    public class BookDAL : ICrud<Book>, IConvertToObject<Book>
    {
        private Book book;

        public int Add(Book obj)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_InsertBook", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("genreID", obj.GenreID);
                        sqlCommand.Parameters.AddWithValue("languageID", obj.LanguageID);
                        sqlCommand.Parameters.AddWithValue("publishHouseID", obj.PublishHouseID);
                        sqlCommand.Parameters.AddWithValue("authorID", obj.AuthorID);
                        sqlCommand.Parameters.AddWithValue("title", obj.Title);
                        sqlCommand.Parameters.AddWithValue("description", obj.Description);
                        sqlCommand.Parameters.AddWithValue("publishYear", obj.PublishYear);
                        sqlCommand.Parameters.AddWithValue("publishPlace", obj.PublishPlace);
                        sqlCommand.Parameters.AddWithValue("iSBN", obj.ISBN);
                        sqlCommand.Parameters.AddWithValue("quantity", obj.Quantity);
                        sqlCommand.Parameters.AddWithValue("pageNumber", obj.PageNumber);
                        sqlCommand.Parameters.AddWithValue("bookCover", obj.BookCover);
                        sqlCommand.Parameters.AddWithValue("price", obj.Price);
                        sqlCommand.Parameters.AddWithValue("weight", obj.Weight);
                        sqlCommand.Parameters.AddWithValue("length", obj.Length);
                        sqlCommand.Parameters.AddWithValue("width", obj.Width);
                        sqlCommand.Parameters.AddWithValue("height", obj.Height);
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

        public Book ConvertToObject(SqlDataReader sqlDataReader)
        {
            book = new Book();

            if (sqlDataReader["BookID"] != DBNull.Value)
            {
                book.BookID = (int)sqlDataReader["BookID"];
            }
            if (sqlDataReader["GenreID"] != DBNull.Value)
            {
                book.GenreID = (int)sqlDataReader["GenreID"];
                book.Genre.GenreID = (int)sqlDataReader["GenreID"];
                book.Genre.GenreName = (string)sqlDataReader["Genre"];
            }
            if (sqlDataReader["LanguageId"] != DBNull.Value)
            {
                book.LanguageID = (int)sqlDataReader["LanguageID"];
                book.Language.LanguageID = (int)sqlDataReader["LanguageID"];
                book.Language.LanguageName = (string)sqlDataReader["Language"];
            }
            if (sqlDataReader["PublishHouseId"] != DBNull.Value)
            {
                book.PublishHouseID = (int)sqlDataReader["PublishHouseID"];
                book.PublishHouse.PublishHouseID = (int)sqlDataReader["PublishHouseID"];
                book.PublishHouse.PublishHouseName = (string)sqlDataReader["PublishHouse"];
            }
            if (sqlDataReader["AuthorId"] != DBNull.Value)
            {
                book.AuthorID = (int)sqlDataReader["AuthorID"];
                book.Author.AuthorID = (int)sqlDataReader["AuthorID"];
                book.Author.FirstName = (string)sqlDataReader["Name"];
                book.Author.LastName = (string)sqlDataReader["LastName"];
            }
            if (sqlDataReader["Title"] != DBNull.Value)
            {
                book.Title = (string)sqlDataReader["Title"];
            }
            if (sqlDataReader["Description"] != DBNull.Value)
            {
                book.Description = (string)sqlDataReader["Description"];
            }
            if (sqlDataReader["Year"] != DBNull.Value)
            {
                book.PublishYear = (DateTime)sqlDataReader["Year"];
            }
            if (sqlDataReader["PublishPlace"] != DBNull.Value)
            {
                book.PublishPlace = (string)sqlDataReader["PublishPlace"];
            }
            if (sqlDataReader["ISBN"] != DBNull.Value)
            {
                book.ISBN = (string)sqlDataReader["ISBN"];
            }
            if (sqlDataReader["Quantity"] != DBNull.Value)
            {
                book.Quantity = (int)sqlDataReader["Quantity"];
            }
            if (sqlDataReader["PageNo"] != DBNull.Value)
            {
                book.PageNumber = (int)sqlDataReader["PageNo"];
            }
            if (sqlDataReader["BookCover"] != DBNull.Value)
            {
                book.BookCover = (string)sqlDataReader["BookCover"];
            }
            if (sqlDataReader["Price"] != DBNull.Value)
            {
                book.Price = (decimal)sqlDataReader["Price"];
            }
            if (sqlDataReader["Weight"] != DBNull.Value)
            {
                book.Weight = (decimal)sqlDataReader["Weight"];
            }
            if (sqlDataReader["Length"] != DBNull.Value)
            {
                book.Length = (decimal)sqlDataReader["Length"];
            }
            if (sqlDataReader["Width"] != DBNull.Value)
            {
                book.Width = (decimal)sqlDataReader["Width"];
            }
            if (sqlDataReader["Height"] != DBNull.Value)
            {
                book.Height = (decimal)sqlDataReader["Height"];
            }
            if (sqlDataReader["InsBy"] != DBNull.Value)
            {
                book.InsBy = (int)sqlDataReader["InsBy"];
            }
            if (sqlDataReader["InsDate"] != DBNull.Value)
            {
                book.InsDate = (DateTime)sqlDataReader["InsDate"];
            }
            if (sqlDataReader["UpdBy"] != DBNull.Value)
            {
                book.UpdBy = (int)sqlDataReader["UpdBy"];
            }
            if (sqlDataReader["UpdDate"] != DBNull.Value)
            {
                book.UpdDate = (DateTime)sqlDataReader["UpdDate"];
            }
            if (sqlDataReader["UpdNo"] != DBNull.Value)
            {
                book.UpdNo = (int)sqlDataReader["UpdNo"];
            }
            return book;
        }

        public int Delete(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_DeleteBook", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("bookID", id);

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

        public Book Get(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetByIDBook", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("bookID", id);
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

        public List<Book> GetAll()
        {
            List<Book> Books = new List<Book>();

            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetAllBook", CommandType.StoredProcedure))
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
                                    Books.Add(ConvertToObject(sqlDataReader));
                                }
                            }
                            return Books;
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                return Books;
            }
        }

        public int Update(Book obj)
        {
            try
            {
                using (var sqlConnection = DbHelper.GetConnection())
                {
                    using (var sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_UpdateBook", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("bookID", obj.BookID);
                        sqlCommand.Parameters.AddWithValue("genreID", obj.GenreID);
                        sqlCommand.Parameters.AddWithValue("languageID", obj.LanguageID);
                        sqlCommand.Parameters.AddWithValue("publishHouseID", obj.PublishHouseID);
                        sqlCommand.Parameters.AddWithValue("authorID", obj.AuthorID);
                        sqlCommand.Parameters.AddWithValue("title", obj.Title);
                        sqlCommand.Parameters.AddWithValue("description", obj.Description);
                        sqlCommand.Parameters.AddWithValue("publishYear", obj.PublishYear);
                        sqlCommand.Parameters.AddWithValue("publishPlace", obj.PublishPlace);
                        sqlCommand.Parameters.AddWithValue("iSBN", obj.ISBN);
                        sqlCommand.Parameters.AddWithValue("quantity", obj.Quantity);
                        sqlCommand.Parameters.AddWithValue("pageNumber", obj.PageNumber);
                        sqlCommand.Parameters.AddWithValue("bookCover", obj.BookCover);
                        sqlCommand.Parameters.AddWithValue("price", obj.Price);
                        sqlCommand.Parameters.AddWithValue("weight", obj.Weight);
                        sqlCommand.Parameters.AddWithValue("length", obj.Length);
                        sqlCommand.Parameters.AddWithValue("width", obj.Width);
                        sqlCommand.Parameters.AddWithValue("height", obj.Height);
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

        public List<Book> GetTop4EarliestBooks()
        {
            List<Book> topBooks = new List<Book>();
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetTop4EarliestBooks", CommandType.StoredProcedure))
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
                                    topBooks.Add(ConvertToObject(sqlDataReader));
                                }
                            }
                            return topBooks;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public List<Book> GetTop4LatestBooks()
        {
            List<Book> topBooks = new List<Book>();
            try
            {
                using (SqlConnection sqlConnection = DbHelper.GetConnection())
                {
                    using (SqlCommand sqlCommand = DbHelper.SqlCommand(sqlConnection, "usp_GetTop4LatestBooks", CommandType.StoredProcedure))
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
                                    topBooks.Add(ConvertToObject(sqlDataReader));
                                }
                            }
                            return topBooks;
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