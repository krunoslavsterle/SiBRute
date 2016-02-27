using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(SiBRute.WebAPI.App_Start.Startup))]
namespace SiBRute.WebAPI.App_Start
{
   
   public class Startup
   {
      public void Configuration(IAppBuilder app)
      {
         app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
               AuthenticationType = "ApplicationCookie",
               LoginPath = new Microsoft.Owin.PathString("/auth/login")
            });
      }
   }
}