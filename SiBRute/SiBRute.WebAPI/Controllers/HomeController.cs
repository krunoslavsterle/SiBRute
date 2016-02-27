
using System.Web.Mvc;

namespace SiBRute.WebAPI.Controllers
{
   /// <summary>
   /// todo: comment
   /// </summary>
   [AllowAnonymous]
   public class HomeController : Controller
   {
      #region Actions

      [HttpGet]
      public ActionResult Index()
      {
         return View();
      }

      [HttpGet]
      public ActionResult Login()
      {
         return View("Login");
      }
     
      [HttpGet]
      public ActionResult UnderConstruction()
      {
         return View("UnderConstruction");
      }

      #endregion Actions

   }
}