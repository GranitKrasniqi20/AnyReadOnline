using AnyReadOnline.BLL;
using AnyReadOnline.BOL;
using Microsoft.AspNet.Identity;
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

        ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        List<Role> roles;
        public AdminsController()
        {

            roles = new List<Role>();
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

    }
}