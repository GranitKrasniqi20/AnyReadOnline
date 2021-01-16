using BitPayLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.BLL
{
    public class BitPayHelper
    {
        BitPay bitpay;

        public BitPayHelper()
        {
            this.bitpay = new BitPay(token: GetApiKey(), environment: Env.Test);
        }
        string GetApiKey()
        {
            return "HiUDXPEr37k9eKysRkHi7Ub91odKphQzSA4JpwA6jLpC";
        }


        public BitPay GetBitPay()
        {
            return bitpay;
        }
    }
}
