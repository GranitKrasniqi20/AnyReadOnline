using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.Models.Interfaces
{
    public interface IGenre
    {
        int GenreID { get; set; }
        string GenreName { get; set; }
    }
}