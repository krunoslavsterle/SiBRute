using SiBRute.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace SiBRute.WebAPI.Controllers
{
   [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult LogIn(string returnUrl)
        {
           var model = new LogInModel
           {
              ReturnUrl = returnUrl
           };

            return View(model);
        }

         [HttpPost]
        public ActionResult LogIn(LogInModel model)
        {
           if (!ModelState.IsValid)
              return View();


           if (model.Email == "admin@admin.com" && model.Password == "password")
           {
              var identity = new ClaimsIdentity(new[] {
                 new Claim(ClaimTypes.Name, "Kruno"),
                 new Claim(ClaimTypes.Email, "a@b.com"),
                 new Claim(ClaimTypes.Country, "England")
              },
              "ApplicationCookie");

              var ctx = Request.GetOwinContext();
              var authManager = ctx.Authentication;

              authManager.SignIn(identity);

              return Redirect(GetRedirectUrl(model.ReturnUrl));
           }

           ModelState.AddModelError("", "Invalid email or password");
           return View();
        }

         public ActionResult LogOut()
         {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
         }

         
        private string GetRedirectUrl(string returnUrl)
        {
           if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
           {
              return Url.Action("Index", "Home");
           }

           return returnUrl;

        }


    }
}