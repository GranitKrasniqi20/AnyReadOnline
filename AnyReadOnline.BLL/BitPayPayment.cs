﻿using System;
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
   public class BitPayPayment
    {

        public string SentPayment(Address BillingAddress, double price, string returnUrl)
        {
            return CreateInvoice(BillingAddress, price, returnUrl);
        }




       string CreateInvoice(Address BillingAddress, double price, string returnUrl)
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
                },//,
                RedirectUrl = returnUrl,
               // NotificationUrl = "http://localhost:44325/Home/Index"
            };

          Invoice inv=   bitpay.CreateInvoice(invoice).Result;

            return inv.Url;
        }






    }



}

    

