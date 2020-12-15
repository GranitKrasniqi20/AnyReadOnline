using AnyReadOnline.BLL;
using AnyReadOnline.BOL;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AnyReadOnline.Controllers
{
    public class AdminsController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AdminsController()
        {
        }

        public AdminsController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
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
        // GET: Admins



        public ActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
        public ActionResult Login()
        {

            return View(new AdminLoginViewModel());
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(AdminLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {

                case SignInStatus.Success:
                    return View("Index");
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }
        public ActionResult Register()
        {
            CountryBLL countryBll = new CountryBLL();
            List<Country> countries = new List<Country>();
            countries.Add(new Country { CountryID = 1, CountryName = "Albania" });
            countries.Add(new Country { CountryID = 2, CountryName = "Kosovo" });
            countries.Add(new Country { CountryID = 3, CountryName = "Germany" });

            List<Role> roles = new List<Role>();

            roles.Add(new Role { RoleID = 1, RoleName = "Admin" });
            roles.Add(new Role { RoleID = 1, RoleName = "Super Admin" });


            ViewBag.roles = new SelectList(roles, "RoleID", "RoleName");
            ViewBag.Countries = new SelectList(countries, "CountryID", "CountryName");
            return View(new Staff());

        }



        // POST: Client/Create
        [HttpPost]
        public async Task<ActionResult> Register(Staff staff)
        {

            RegisterViewModel registerClient = new RegisterViewModel();


            registerClient.Email = staff.Email;

            registerClient.Password = staff.Password;
            registerClient.ConfirmPassword = staff.Password;

            try
            {

                var user = new ApplicationUser { UserName = staff.UserName, Email = staff.Email };
                var result = await UserManager.CreateAsync(user, staff.Password);
                if (result.Succeeded)
                {
                    StaffBLL clientbll = new StaffBLL();

                    if (clientbll.Add(staff) == 1)
                    {
                        return RedirectToAction("Index", "Admins");
                    }
                    else
                    {
                        throw new Exception();
                    }

                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}