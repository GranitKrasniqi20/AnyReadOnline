using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnyReadOnline.BOL;
using AnyReadOnline.BOL.Interfaces;
using AnyReadOnline.DAL;

namespace AnyReadOnline.BLL
{
    public class GenreBLL 
    {
        private readonly GenreDAL genreDAL = new GenreDAL();

        public int Add(Genre obj)
        {
            return genreDAL.Add(obj);
        }

        public int Delete(int id)
        {
            return genreDAL.Delete(id);
        }

        public Genre Get(int id)
        {
            return genreDAL.Get(id);
        }

        public List<Genre> GetAll()
        {
            return genreDAL.GetAll();
        }

        public int Update(Genre obj)
        {
            return genreDAL.Update(obj);
        }

        public Genre UpdateObj(int id, Genre obj)
        {
            var GetItem = Get(id);

            GetItem.GenreName = obj.GenreName;

            return GetItem;
        }
    }
}
