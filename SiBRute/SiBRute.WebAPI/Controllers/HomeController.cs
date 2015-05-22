using System.Web.Mvc;

namespace SiBRute.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        #region Actions

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        #endregion Actions
        
    }
}