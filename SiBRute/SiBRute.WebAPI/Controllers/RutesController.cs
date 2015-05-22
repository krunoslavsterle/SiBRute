using System.Web.Mvc;

namespace SiBRute.WebAPI.Controllers
{
    public class RutesController : Controller
    {
        [HttpGet]
        public ActionResult RutesList()
        {
            return View();
        }
    }
}