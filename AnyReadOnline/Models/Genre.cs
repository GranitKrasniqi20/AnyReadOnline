using AnyReadOnline.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnyReadOnline.Models
{
    public class Genre : Audit, IGenre
    {
        public int GenreID { get; set; }
        public int _GenreName { get; set; }
    }
}
