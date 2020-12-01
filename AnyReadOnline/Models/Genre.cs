using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnyReadOnline.Models.Interfaces;

namespace AnyReadOnline.Models
{
    public class Genre : Audit, IGenre
    {
        public int GenreID { get; set; }
        public string GenreName { get; set; }
    }
}
