using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnyReadOnline.BOL.Interfaces;

namespace AnyReadOnline.BOL
{
    public class Role : Audit, IRole
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
}
