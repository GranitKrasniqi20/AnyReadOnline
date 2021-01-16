using AnyReadOnline.BLL;
using AnyReadOnline.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace AnyReadOnline.Controllers
{
    public class AddressesController : Controller
    {
        public AddressesController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public AddressesController()
        {

        }

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;


        private AddressBLL addressBLL = new AddressBLL();
        private CountryBLL countryBLL = new CountryBLL();


        // GET: Addresses
        public ActionResult Index()
        {
            return View(addressBLL.GetByClientID(GetCurrenctClient().UserID).ToList());
        }

        // GET: Addresses/Details/5
        public ActionResult Details(int id)
        {
            return View(addressBLL.Get(id));
        }

        // GET: Addresses/Create
        public ActionResult Create()
        {
            ViewBag.Countries = countryBLL.GetAll();
            Address address = new Address();

            return View(address);
        }

        // POST: Addresses/Create
        [HttpPost]
        public ActionResult Create(Address address)
        {
            ViewBag.Countries = countryBLL.GetAll();
            address.Client = GetCurrenctClient();
            address.ClientID = GetCurrenctClient().UserID;

            try
            {
                foreach (var item in countryBLL.GetAll())
                {
                    if (item.CountryID == address.Country.CountryID)
                    {
                        address.CountryID = item.CountryID;
                        break;
                    }
                }

                if (addressBLL.Add(address) > 0)
                {
                    return RedirectToAction("Index");
                }
                return Content("Error while Creating Address!");
            }
            /*return View(address);*/
            catch
            {
                return View(address);
            }
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Countries = countryBLL.GetAll();
            ViewBag.MyCountry = addressBLL.Get(id).CountryID;

            return View(addressBLL.Get(id));
        }

        // POST: Addresses/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Address address)
        {
            ViewBag.Countries = countryBLL.GetAll();
            ViewBag.MyCountry = addressBLL.Get(id).CountryID;
            address.Country = addressBLL.Get(id).Country;
            address.CountryID = addressBLL.Get(id).CountryID;
            address.AddressID = id;
            address.Client = GetCurrenctClient();
            address.ClientID = GetCurrenctClient().UserID;

            try
            {
                if (addressBLL.Update(address) > 0)
                {
                    return RedirectToAction("Index");
                }

                return Content("Error while Editing Address!");
            }
            catch
            {
                return View(address);
            }
        }

        // GET: Addresses/Delete/5
        public ActionResult Delete(int id)
        {
            return View(addressBLL.Get(id));
        }

        // POST: Addresses/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Address address)
        {
            try
            {
                if (addressBLL.Delete(id) > 0)
                {
                    return RedirectToAction("Index");
                }
                return Content("Error while Deleting Address!");
            }
            catch
            {
                return View(address);
            }
        }

        
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

    }
}
