﻿using SiBRute.Repository.Common;
using SiBRute.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiBRute.Model.Common;
using SiBRute.Model;
using System.Threading.Tasks;

namespace SiBRute.WebAPI.Controllers
{
   /// <summary>
   /// todo: comment:
   /// </summary>
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
      public async Task<ActionResult> ListAsync()
      {
         return View("List", await routesService.GetAllRoutesAsync());
         //return View("List", await routesService.GetRoutesWithMaxDistanceAsync(85));     
      }

      [HttpGet]
      public async Task<ActionResult> DetailsAsync(int routeId)
      {
         return View("Details", await routesService.GetRouteAsync(routeId));
      }

      [HttpGet]
      public ActionResult NewAsync()
      {
         return View("New");
      }

      [HttpPost]
      public async Task<RedirectToRouteResult> NewAsync(BikeRoute route)
      {
         await routesService.AddRouteAsync(route);
         return RedirectToAction("ListAsync");
      }

      [HttpGet]
      public ActionResult Planer()
      {
         return View("Planer");
      }

      #endregion Actions

      protected override void Dispose(bool disposing)
      {
         routesService.Dispose();
         base.Dispose(disposing);
      }
   }
}