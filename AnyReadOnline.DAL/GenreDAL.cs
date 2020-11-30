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
                    using (SqlCommand sqlCommand = DbHelper.Command(sqlConnection, "", CommandType.StoredProcedure))
                    {
                        sqlCommand.Parameters.AddWithValue("genreName", genre._GenreName);
                        sqlCommand.Parameters.AddWithValue("insBy", genre.InsBy);
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
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }
    }
}
