using AnyReadOnline.BOL;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using AnyReadOnline.BLL;
using AnyReadOnline.BOL.FedExRates;

namespace AnyReadOnline.Controllers
{
    public class CheckoutController : Controller
    {

        public CheckoutController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public CheckoutController()
        {
        }

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Checkout


        Client GetCurrenctClient()
        {
            if (User.Identity.IsAuthenticated)
            {
                string userId = User.Identity.GetUserId();
                if (User.IsInRole("Client"))
                {
                    ApplicationUser user = UserManager.FindById(userId);
                    ClientBLL clientbll = new ClientBLL();
                    Client client = clientbll.Get(user.UserName);


                    if (client != null)
                    {
                        return client;
                    }

                    return null;
                }
                return null;
            }
            return null;



        }

        public ActionResult BillingAddress()
        {

            
            
            
            AddressBLL addressBLL = new AddressBLL();

            List<Address> addresses = addressBLL.GetAll().Where(x => x.ClientID == GetCurrenctClient().UserID).ToList();
            if (addresses.Count >0)
            {
                ViewBag.HasAddresses = true;
            }
            else
            {
                ViewBag.HasAddresses = false;
            }
            ViewBag.BillingAddresses = addresses;
            CountryBLL countryBLL = new CountryBLL();
            List<Country> countries = countryBLL.GetAll();
            ViewBag.Countries = new SelectList(countries, "CountryID", "CountryName");

            return View(new Address());
        }

        public ActionResult BillingAddresO(int AddressId)
        {


            Client client = GetCurrenctClient();
            Payment payment = new Payment();

            AddressBLL addressBLL = new AddressBLL();
            payment.BillingAddres = addressBLL.Get(AddressId);
            payment.Order = new Order();
            CountryBLL countryBLL = new CountryBLL();
            Country country = countryBLL.Get(payment.BillingAddres.CountryID);
            payment.BillingAddres.Country = country;

            payment.Order.Client = client;

            payment.BillingAddres.ClientID = client.UserID;
            payment.BillingAddres.Client = client;
            payment.Order.OrderDetails = CartItemToOrderDetails(getCardItems(client.UserID));

            Session[$"Orders{client.UserID}"] = payment;
            return RedirectToAction("ShippingAddress");
        }



        [HttpPost]
        public ActionResult BillingAddress(Address model)
        {





            Client client = GetCurrenctClient();
            AddressBLL addressBLL = new AddressBLL();

            CountryBLL countryBLL = new CountryBLL();
            Country country = countryBLL.Get(model.CountryID);
            model.Country = country;

            model.ClientID = client.UserID;
            model.Client = client;
            addressBLL.Add(model);
            Payment payment = new Payment();
            payment.Order = new Order();
            payment.Order.Client = client;
            payment.BillingAddres = model;
            payment.Order.OrderDetails = CartItemToOrderDetails(getCardItems(client.UserID));

            Session[$"Orders{client.UserID}"] = payment;
            return RedirectToAction("ShippingAddress");
        }

        List<OrderDetails> CartItemToOrderDetails(List<CartItemModel> CardItems)
        {
            OrderDetails orderDetail;
            List<OrderDetails> orderDetails = new List<OrderDetails>();
            foreach (CartItemModel item in CardItems)
            {
                orderDetail = new OrderDetails();
                orderDetail.Quantity = item.Quantity;
                orderDetail.Book = item.book;
                orderDetails.Add(orderDetail);
            }

            return orderDetails;
        }
        List<CartItemModel> getCardItems(int Cleintid)
        {
            List<CartItemModel> cart = (List<CartItemModel>)Session["cart"];
          return  cart.Where(x => x.ClientID == Cleintid).ToList();
        }

        // GET: Checkout/Details/5
        public ActionResult ShippingAddress()
        {

            AddressBLL addressBLL = new AddressBLL();

            List<Address> addresses = addressBLL.GetAll().Where(x => x.ClientID == GetCurrenctClient().UserID).ToList();
            if (addresses.Count > 0)
            {
                ViewBag.HasAddresses = true;
            }
            else
            {
                ViewBag.HasAddresses = false;
            }
            ViewBag.BillingAddresses = addresses;
            CountryBLL countryBLL = new CountryBLL();
            List<Country> countries = countryBLL.GetAll();
            ViewBag.Countries = new SelectList(countries, "CountryID", "CountryName");

            return View(new Address());
        }


        public ActionResult ShippingAddressO(int AddressId)
        {

            CountryBLL countryBLL = new CountryBLL();
            AddressBLL addressBLL = new AddressBLL();
            Address address = addressBLL.Get(AddressId);
            Country country = countryBLL.Get(address.CountryID);
            Client client = GetCurrenctClient();
            address.ClientID = client.UserID;
            address.Client = client;
            address.Country = country;
            addressBLL.Add(address);

            Payment payment = Session[$"Orders{client.UserID}"] as Payment;
            payment.Order.ShippingAddress = address;
            FedExRates fedExRates = new FedExRates();
            RateReplyDetails ratedShipmentDetails = fedExRates.GetRate(payment.Order);
            if (ratedShipmentDetails.RateReplies[0].RatedShipmentDetails[0].TotalBillingAmount > 0)
            {
                payment.ratedShipmentDetails = ratedShipmentDetails;
                Session[$"Orders{client.UserID}"] = payment;
            }
            return RedirectToAction("OrderConfirmation");
        }

        [HttpPost]
        public ActionResult ShippingAddress(Address address)
        {





            CountryBLL countryBLL = new CountryBLL();

            Country country = countryBLL.Get(address.CountryID);
            Client client = GetCurrenctClient();
            AddressBLL addressBLL = new AddressBLL();
            address.ClientID = client.UserID;
            address.Client = client;
            address.Country = country;
            addressBLL.Add(address);

            Payment payment = Session[$"Orders{client.UserID}"] as Payment ;
            payment.Order.ShippingAddress = address;
            FedExRates fedExRates = new FedExRates();
            RateReplyDetails ratedShipmentDetails = fedExRates.GetRate(payment.Order);
            if (ratedShipmentDetails.RateReplies[0].RatedShipmentDetails[0].TotalBillingAmount > 0)
            {
                payment.ratedShipmentDetails = ratedShipmentDetails;
                Session[$"Orders{client.UserID}"] = payment;
            }
            return RedirectToAction("OrderConfirmation");
        }

        

        public ActionResult OrderConfirmation()
        {
            Client client = GetCurrenctClient();
            PaymentBLL paymentBLL = new PaymentBLL();
            Payment payment = Session[$"Orders{client.UserID}"] as Payment;
            payment.Subtotal = paymentBLL.CalculateSubtotal(payment.Order.OrderDetails);
            payment.TotalPrice = paymentBLL.CalculatePrice(payment.Order.OrderDetails, payment.ratedShipmentDetails.RateReplies[0].RatedShipmentDetails[0].TotalBillingAmount);
            Session[$"Orders{client.UserID}"] = payment;
            return View(payment);
        }



        [HttpPost]
        public ActionResult OrderConfirmation(Payment payment)
        {

            //if (payment.clientConfirmation)
            //{
                Client client = GetCurrenctClient();
            // Payment payment = Session[$"Orders{client.UserID}"] as Payment;
             payment = Session[$"Orders{client.UserID}"] as Payment;
            BitPayPayment bitPay = new BitPayPayment();
                PaymentBLL paymentBLL = new PaymentBLL();
            // FedExRates fedExRates = new FedExRates();
            //RateReplyDetails ratedShipmentDetails= fedExRates.GetRate(payment.Order);




            // }
            string confirmationLink = $"{Request.Url.Scheme}://{Request.Url.Host}:{Request.Url.Port}{this.Url.Action("Payment", "Checkout")}";
            return RedirectToAction("Payment");

           // return Redirect(bitPay.SentPayment(payment.BillingAddres, 20, confirmationLink)) ;
        }


        // GET: Checkout/Create
        public ActionResult Payment()
        {
            Client client = GetCurrenctClient();

            Payment payment;
            payment = Session[$"Orders{client.UserID}"] as Payment;
            OrderBLL orderBLL = new OrderBLL();
            payment.Order.Client = client;
            payment.Order.Client.UserID = client.UserID;
            orderBLL.Add(payment);
            return View();
        }


        // POST: Checkout/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Checkout/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Checkout/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Checkout/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Checkout/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
