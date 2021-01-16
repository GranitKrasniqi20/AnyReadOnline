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
    public class RoleBLL:IRead<Role>
    {
        RoleDAL roleDAL;

        Role IRead<Role>.Get(int id)
        {
            roleDAL = new RoleDAL();
            return roleDAL.Get(id);
        }
        public List<Role> GetAll()
        {
            roleDAL = new RoleDAL();
            return roleDAL.GetAll();
        }
    }
}
