using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using Tozepty.Models;
using TozeptyDAL.Interfaces;

namespace Tozepty.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAdminRepository adminRepository;
        private readonly ICustomerRepository customerRepository;

       
        public AccountController(
            IAdminRepository adminRepository,
            ICustomerRepository customerRepository
        )
        {
            this.adminRepository = adminRepository;
            this.customerRepository = customerRepository;
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(LoginViewModel loginView)
        {
            //var isAdmin = Authentication.VerifyAdminCredentials(loginView.UserName, loginView.Password);
            var isAdmin = true;


            if (isAdmin)
            {
                var user = adminRepository.GetAdminByUserName(loginView.UserName);
                Session["UserId"] = user.Id;
                Session["userInRole"] = user.RoleId;
                Session["UserName"] = user.UserName;
                FormsAuthentication.SetAuthCookie(loginView.UserName, false);
                return RedirectToAction("Contact", "Home");
            }
            else
            {
                // If authentication fails, you may want to show an error message.
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return View(loginView);
            }
        }
    }
}
