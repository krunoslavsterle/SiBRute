using SiBRute.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiBRute.WebAPI.Controllers
{
    public class RoutesController : Controller
    {
        #region Properties

        /// <summary>
        /// Gets the repository
        /// </summary>
        protected IRoutesRepository repository { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Gets the repository by DI and set it to the private propertie
        /// </summary>
        /// <param name="repository"></param>
        public RoutesController(IRoutesRepository repository)
        {
            this.repository = repository;
        }

        #endregion Constructors

        #region Actions

        [HttpGet]
        public ActionResult List()
        {
            return View(repository.GetAllRoutes());
        }

        #endregion Actions
        
    }
}