using SiBRute.Repository.Common;
using SiBRute.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiBRute.Model.Common;
using SiBRute.Model;

namespace SiBRute.WebAPI.Controllers
{
    public class RoutesController : Controller
    {
        #region Properties

        /// <summary>
        /// Gets the repository
        /// </summary>
        protected IRoutesService routesService { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Gets the repository by DI and set it to the private propertie
        /// </summary>
        /// <param name="repository"></param>
        public RoutesController(IRoutesService routesService)
        {
            this.routesService = routesService;
        }

        #endregion Constructors

        #region Actions

        [HttpGet]
        public ActionResult List()
        {            
            return View(routesService.GetAllRoutes());
            //return View(routesService.GetRoutesWithMaxDistance(75));
            //return View(routesService.GetRoutesNearPlace("Bilje"));
        }

        [HttpGet]
        public ActionResult Details(int routeId)
        {
            return View(routesService.GetRoute(routeId));
        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost] 
        public RedirectToRouteResult New(BikeRoute route)
        {            
            routesService.AddRoute(route);
            return RedirectToAction("List");
        }

        #endregion Actions
        
    }
}