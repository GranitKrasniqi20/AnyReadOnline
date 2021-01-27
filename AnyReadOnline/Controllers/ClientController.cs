using AnyReadOnline.BLL;
using AnyReadOnline.BOL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AnyReadOnline.Controllers
{
    public class ClientController : Controller
    {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        List<Role> roles;

        public ClientController()
        {
            RoleBLL roleBLL = new RoleBLL();
            roles = roleBLL.GetAll();
        }

        public ClientController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            RoleBLL roleBLL = new RoleBLL();
            roles = roleBLL.GetAll();
            UserManager = userManager;
            SignInManager = signInManager;
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

        // GET: Client
      /*  [Authorize(Roles = "SuperAdmin,Admin")]*/
        public ActionResult Index()
        {
            return View();
        }

        // GET: Client/Details/5
        [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Client/Create
        //[AllowAnonymous]
        //public ActionResult Register()
        //{

        //    return View(new Client());
        //}

        //// POST: Client/Create
        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<ActionResult> Register(Client client)
        //{

        //    RegisterViewModel registerClient = new RegisterViewModel();
            

        //    registerClient.Email = client.Email;
        //    registerClient.Password = client.Password;
        //    registerClient.ConfirmPassword = client.Password;
            
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var user = new ApplicationUser { UserName = client.Email, Email = client.Email };
        //            var result = await UserManager.CreateAsync(user, client.Password);
        //            string uid = user.Id;
        //            if (result.Succeeded)
        //            {

        //                ClientBLL clientbll = new ClientBLL();
        //                clientbll.Add(client);
        //                await UserManager.AddToRoleAsync(uid, "Client");
        //                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

        //                //return RedirectToAction("Index", "Home");
        //                return Redirect("~/Home/Index");
        //            }
        //        }

        //        //return RedirectToAction("Index");
        //        return Redirect("~/Home/Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ApplicationDbContext db = new ApplicationDbContext();


        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]

        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            try
            {
                IdentityHelper identityHelper = new IdentityHelper(UserManager, SignInManager);
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, change to shouldLockout: true


                if (identityHelper.GetRole(model.User) == "Client")
                {
                    int isLoggedIn = await identityHelper.LogIn(model);

                    switch (isLoggedIn)
                    {

                        case 1:
                            return RedirectToAction("Index","Home");
                        case -1:
                            return View("Lockout");
                        case 0:
                        default:
                            ModelState.AddModelError("", "Invalid login attempt.");
                            return View(model);
                    }
                }





            }
            catch (Exception)
            {
                return View(model);
            }
            return View(model);
        }


       

        // GET: Client/Edit/5
        [Authorize(Roles = "Client")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Client/Edit/5
        [Authorize(Roles = "Client")]
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

        // GET: Client/Delete/5

        [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Client/Delete/5
        [HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")]
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

        public ActionResult MyProfile()
        {
            return View();
        }
    }
}
