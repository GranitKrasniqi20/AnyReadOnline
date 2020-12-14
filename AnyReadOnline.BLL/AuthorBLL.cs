using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnyReadOnline.BOL;
using AnyReadOnline.BOL.Interfaces;
using AnyReadOnline.DAL;
using System.IO;
using System.Web;

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

        public string AuthorImagePath(Author author)
        {
            string fileName = Path.GetFileNameWithoutExtension(author.ImageFile.FileName);
            string extension = Path.GetExtension(author.ImageFile.FileName);
            fileName += DateTime.Now.ToString("yymmssfff") + extension;
            author.ImagePath = "~/Content/img/" + fileName;
            fileName = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/img/"), fileName);
            author.ImageFile.SaveAs(fileName);

            return author.ImagePath;
        }

        public List<Author> GetTop4EarliestAuthors()
        {
            return authorDAL.GetTop4EarliestAuthors();
        }

        public List<Author> GetTop4LatestAuthors()
        {
            return authorDAL.GetTop4LatestAuthors();
        }
    }
}
