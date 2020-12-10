using AnyReadOnline.BOL;
using AnyReadOnline.BOL.Interfaces;
using AnyReadOnline.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.BLL
{
    public class ClientBLL : ICrud<Client>, IReadByEmail<Client>
    {
        private readonly ClientDAL clientDAL = new ClientDAL();

        public int Add(Client obj)
        {
            return clientDAL.Add(obj);
        }

        public int Delete(int id)
        {
            return clientDAL.Delete(id);
        }

        public Client Get(int id)
        {
            return clientDAL.Get(id);
        }

        public Client Get(string email)
        {
            return clientDAL.Get(email);
        }

        public List<Client> GetAll()
        {
            return clientDAL.GetAll();
        }

        public int Update(Client obj)
        {
            return clientDAL.Update(obj);
        }
    }
}
