using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AnyReadOnline.BOL.Interfaces;

namespace AnyReadOnline.BOL
{
    public class Genre : Audit, IGenre
    {
        public int GenreID { get; set; }

        [Required]
        public string GenreName { get; set; }
    }
}
