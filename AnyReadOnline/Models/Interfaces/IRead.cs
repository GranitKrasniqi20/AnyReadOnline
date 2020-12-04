using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.Models.Interfaces
{
    interface IRead<T>
    {
        T Get(int id);
        List<T> GetAll();
    }
}
