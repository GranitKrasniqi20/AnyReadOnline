using AnyReadOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnyReadOnline.Models
{
    public class Country : Audit, ICountry
    {
        public int CountryID { get; set; }
        public string country { get; set; }
    }
}
