using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.BOL.Interfaces
{
    public interface IRole
    {
        int RoleID { get; set; }
        string RoleName { get; set; }
    }
}