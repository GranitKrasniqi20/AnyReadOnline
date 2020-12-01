using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.Models.Interfaces
{
    interface IRead<T>
    {
        T GetByID(int Id);
        List<T> GetAll();
    }
}
