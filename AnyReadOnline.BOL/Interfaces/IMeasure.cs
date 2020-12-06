using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.BOL.Interfaces
{
    public interface IMeasure
    {
        double Weight { get; set; }
        double Width { get; set; }
        double Height { get; set; }
        double Length { get; set; }
    }
}
