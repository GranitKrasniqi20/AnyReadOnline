using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANYREAD.Models
{
    public class Genre : IGenre
    {
        public int GenreID { get; set; }
        public int _GenreName { get; set; }
    }
}
