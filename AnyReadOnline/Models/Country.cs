﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANYREAD.Models
{
    public class Country : ICountry
    {
        public int CountryID { get; set; }
        public string country { get; set; }
    }
}