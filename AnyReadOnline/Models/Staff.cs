using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnyReadOnline.Models.Interfaces;

namespace AnyReadOnline.Models
{
    public class Staff : User, IStaff
    {
        public virtual IRole Role { get; set; }
    }
}
