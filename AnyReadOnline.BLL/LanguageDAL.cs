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
    public class LanguageDAL : ICrud<Language>
    {
        private readonly LanguageDAL languageDAL = new LanguageDAL();

        public int Add(Language obj)
        {
            return languageDAL.Add(obj);
        }

        public int Delete(int id)
        {
            return languageDAL.Delete(id);
        }

        public Language Get(int id)
        {
            return languageDAL.Get(id);
        }

        public List<Language> GetAll()
        {
            return languageDAL.GetAll();
        }

        public int Update(Language obj)
        {
            return languageDAL.Update(obj);
        }
    }
}
