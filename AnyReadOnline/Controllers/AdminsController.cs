using AnyReadOnline.BLL;
using AnyReadOnline.BOL;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
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
        List<Role> roles;
        public AdminsController()
        {

            roles = new List<Role>();
            roles.Add(new Role { RoleID = 2, RoleName = "Admin" });
            roles.Add(new Role { RoleID = 3, RoleName = "SuperAdmin" });
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


        [Authorize(Roles = "Admin,SuperAdmin")]
        public ActionResult Index()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            dataPoints.Add(new DataPoint("Albert", 10));
            dataPoints.Add(new DataPoint("Tim", 30));
            dataPoints.Add(new DataPoint("Wilson", 17));
            dataPoints.Add(new DataPoint("Joseph", 39));
            dataPoints.Add(new DataPoint("Robert", 30));
            dataPoints.Add(new DataPoint("Sophia", 25));
            dataPoints.Add(new DataPoint("Emma", 15));

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

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
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Register()
        {
            CountryBLL countryBll = new CountryBLL();
            List<Country> countries = countryBll.GetAll();







            ViewBag.roles = new SelectList(roles, "RoleID", "RoleName");
            ViewBag.Countries = new SelectList(countries, "CountryID", "CountryName");
            return View(new Staff());

        }

        string GetRole(int id)
        {
            return roles.Where(x => x.RoleID == id).FirstOrDefault().RoleName;
        }


        // POST: Client/Create
        [Authorize(Roles = "SuperAdmin")]
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
                string uid = user.Id;

                if (result.Succeeded)
                {
                    StaffBLL clientbll = new StaffBLL();

                    if (clientbll.Add(staff) == 1)
                    {
                        if (staff.RoleId == 2)
                        {
                            await UserManager.AddToRoleAsync(uid, "Admin");
                        }
                        else if (staff.RoleId == 3)
                        {
                            await UserManager.AddToRoleAsync(uid, "SuperAdmin");
                        }
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

                CountryBLL countryBll = new CountryBLL();
                List<Country> countries = countryBll.GetAll();
                ViewBag.roles = new SelectList(roles, "RoleID", "RoleName");
                ViewBag.Countries = new SelectList(countries, "CountryID", "CountryName");

                return View(new Staff());
            }
        }
    }
}