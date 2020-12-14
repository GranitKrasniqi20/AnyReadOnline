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
    public class BookBLL : ICrud<Book>
    {
        private readonly BookDAL bookDAL = new BookDAL();

        public int Add(Book obj)
        {
            return bookDAL.Add(obj);
        }

        public int Delete(int id)
        {
            return bookDAL.Delete(id);
        }

        public Book Get(int id)
        {
            return bookDAL.Get(id);
        }

        public List<Book> GetAll()
        {
            return bookDAL.GetAll();
        }

        public int Update(Book obj)
        {
            return bookDAL.Update(obj);
        }

        public List<Book> GetTop4EarliestBooks()
        {
            return bookDAL.GetTop4EarliestBooks();
        }

        public List<Book> GetTop4LatestBooks()
        {
            return bookDAL.GetTop4LatestBooks();
        }
    }
}
