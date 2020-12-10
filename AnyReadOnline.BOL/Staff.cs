using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnyReadOnline.BOL.Interfaces;

namespace AnyReadOnline.BOL
{
    public class Staff : User, IStaff
    {
        public virtual IRole Role { get; set; }
    }
}
