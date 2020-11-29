using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANYREAD.Models.Interfaces
{
    public interface IMeasure
    {
        double Weight { get; set; }
        double Width { get; set; }
        double Height { get; set; }
        double Length { get; set; }
    }
}
