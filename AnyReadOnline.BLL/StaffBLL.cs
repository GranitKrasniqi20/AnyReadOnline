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
    public class StaffBLL : ICrud<Staff>, IReadByEmail<Staff>
    {
        private readonly StaffDAL staffDAL = new StaffDAL();

        public int Add(Staff obj)
        {
            return staffDAL.Add(obj);
        }

        public int Delete(int id)
        {
            return staffDAL.Delete(id);
        }

        public Staff Get(int id)
        {
            return staffDAL.Get(id);
        }

        public Staff Get(string email)
        {
            return staffDAL.Get(email);
        }

        public List<Staff> GetAll()
        {
            return staffDAL.GetAll();
        }

        public int Update(Staff obj)
        {
            return staffDAL.Update(obj);
        }
    }
}
