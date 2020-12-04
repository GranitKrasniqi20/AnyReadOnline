using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnyReadOnline.Models.Interfaces;

namespace AnyReadOnline.Models
{
    public class Role : Audit, IRole
    {
        public int RoleID { get; set; }
        public string role { get; set; }
    }
}
