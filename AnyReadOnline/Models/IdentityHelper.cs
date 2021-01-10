using AnyReadOnline.BOL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.Owin;

namespace AnyReadOnline.BLL
{
    public class IdentityHelper
    {
        ApplicationDbContext db = new ApplicationDbContext();
        ApplicationUserManager userManager;
        ApplicationSignInManager _signInManager;
        public IdentityHelper(ApplicationUserManager userManager, ApplicationSignInManager _signInManager)
        {
            this.userManager = userManager;
            this._signInManager = _signInManager;
        }

        public async Task<int> LogIn(LoginViewModel loginModel)
        {
          try
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.User, loginModel.Password, loginModel.RememberMe, shouldLockout: false);


                switch (result)
                {

                    case SignInStatus.Success:
                        return 1;
                    case SignInStatus.LockedOut:
                        return -1;
                    case SignInStatus.Failure:
                    default:
                        return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }

        }


        public  string GetRole(string user)
        {

            string uid = db.Users.Where(x => x.UserName == user).FirstOrDefault().Id;
            return userManager.GetRoles(uid).FirstOrDefault();
        }

        public async Task<string> Register(RegisterViewModel model)
        {

            try
            {
                ApplicationUser user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);
                string uid = user.Id;

                if (result.Succeeded)
                {
                    StaffBLL clientbll = new StaffBLL();
                    await AddRole(uid, model.Role, userManager);
                    return uid;

                }
            }
            catch (Exception)
            {
                return "";
            }
            return "";
        }



        async Task<bool> AddRole(string uid, string role, ApplicationUserManager userManager)
        {

                await userManager.AddToRoleAsync(uid, role);

            return  await userManager.IsInRoleAsync(uid, role);

        }
    }
}
