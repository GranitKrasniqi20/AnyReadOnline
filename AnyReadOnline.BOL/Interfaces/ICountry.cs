using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.BOL.Interfaces
{
    public interface ICountry
    {
        int CountryID { get; set; }
        string CountryName { get; set; }
    }
}