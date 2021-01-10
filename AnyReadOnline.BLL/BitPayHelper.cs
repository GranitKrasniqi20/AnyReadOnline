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
            return "H78Yiu78uh78Gjht6g67gjh6767ghj";
        }


        public BitPay GetBitPay()
        {
            return bitpay;
        }
    }
}
