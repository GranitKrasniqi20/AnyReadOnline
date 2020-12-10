using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.BOL.Interfaces
{
    public interface IRead<T>
    {
        T Get(int id);
        List<T> GetAll();
    }
}
