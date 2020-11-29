using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANYREAD.Models
{
    public class Role : IRole
    {
        public int RoleID { get; set; }
        public string role { get; set; }
    }
}
