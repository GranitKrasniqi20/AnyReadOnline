using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnyReadOnline.BOL;
using BitPayLight;
using BitPayLight.Models;
using BitPayLight.Models.Bill;
using BitPayLight.Models.Invoice;

namespace AnyReadOnline.BLL
{
    class BitPayPayment
    {

        public string SentPayment(Address BillingAddress, double price)
        {
            return CreateInvoice(BillingAddress, price);
        }




       string CreateInvoice(Address BillingAddress, double price)
        {
            BitPayHelper bitPayHelper = new BitPayHelper();

            BitPay bitpay = bitPayHelper.GetBitPay();
            Buyer buyerData = new Buyer();
            buyerData.Name = $"{BillingAddress.FirstName} {BillingAddress.LastName}";
            
            buyerData.Address1 = BillingAddress.Address1;
            buyerData.Address2 = BillingAddress.Address2;
            buyerData.Locality = BillingAddress.City;
            buyerData.PostalCode = BillingAddress.PostalCode;
            buyerData.Country = BillingAddress.Country.CountryName;
            buyerData.Notify = true;
            buyerData.Email = BillingAddress.Client.Email;

            Invoice invoice = new Invoice(price, Currency.EUR)
            {
                Buyer = buyerData,
                PosData = $"{BillingAddress.Client.UserID}",
                PaymentCurrencies = new List<string> {
                   Currency.BTC,
                    Currency.BCH,
                    Currency.ETH
                }
            };



            return bitpay.CreateInvoice(invoice).Result.Url;
        }






    }



}

    

