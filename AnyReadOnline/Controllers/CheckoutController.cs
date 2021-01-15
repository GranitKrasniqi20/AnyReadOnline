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
            return View();
        }

        [HttpPost]
        public ActionResult BillingAddress(Address address)
        {
            if (true)
            {

            }

            Client client = GetCurrenctClient();
            Payment payment = new Payment();
            payment.Order = new Order();
            payment.Order.Client = client;
            payment.BillingAddres = address;
            payment.Order.OrderDetails = CartItemToOrderDetails(getCardItems(client.UserID));

            Session["Orders{client.UserID}"] = payment;
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

            return View();
        }

        [HttpPost]
        public ActionResult ShippingAddress(Address address)
        {
            Client client = GetCurrenctClient();
            Payment payment = Session[$"Orders{client.UserID}"] as Payment ;
            payment.Order.ShippingAddress = address;
            FedExRates fedExRates = new FedExRates();
            RateReplyDetails ratedShipmentDetails = fedExRates.GetRate(payment.Order);
            if (ratedShipmentDetails.RateReplies[0].RatedShipmentDetails[0].TotalBillingAmount > 0)
            {
                payment.ratedShipmentDetails = ratedShipmentDetails;
                Session[$"Orders{client.UserID}"] = payment;
            }
            return View(address);
        }

        public ActionResult OrderConfirmation()
        {

            return View();
        }



        [HttpPost]
        public ActionResult OrderConfirmation(bool isConfirmed)
        {

            if (isConfirmed)
            {
                Client client = GetCurrenctClient();
                Payment payment = Session[$"Orders{client.UserID}"] as Payment;

                BitPayPayment bitPay = new BitPayPayment();
                PaymentBLL paymentBLL = new PaymentBLL();
                FedExRates fedExRates = new FedExRates();
                RateReplyDetails ratedShipmentDetails= fedExRates.GetRate(payment.Order);

                    bitPay.SentPayment(payment.BillingAddres, paymentBLL.CalculatePrice(payment.Order.OrderDetails, payment.ratedShipmentDetails.RateReplies[0].RatedShipmentDetails[0].TotalBillingAmount));
                
               
            }

            return View();
        }


        // GET: Checkout/Create
        public ActionResult Payment()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Payment(Payment payment)
        {


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
