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
    public class AuthorBLL : ICrud<Author>
    {
        private readonly AuthorDAL authorDAL = new AuthorDAL();

        public int Add(Author obj)
        {
            return authorDAL.Add(obj);
        }

        public int Delete(int id)
        {
            return authorDAL.Delete(id);
        }

        public Author Get(int id)
        {
            return authorDAL.Get(id);
        }

        public List<Author> GetAll()
        {
            return authorDAL.GetAll();
        }

        public int Update(Author obj)
        {
            return authorDAL.Update(obj);
        }
    }
}
