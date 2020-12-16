using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.BOL
{
    public class NumberValidation : ValidationAttribute
    {
        public override bool IsValid(object value) 
        {
            int n = DateTime.Now.Year;

            int intValue = Convert.ToInt32(value);

            return intValue <= n;

        }
    }
}
