using SiBRute.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiBRute.WebAPI.Models
{
    // TODO: Delete after database implementation
    /// <summary>
    /// Class used in a mocking the repository to preserve loosely coupled architecture
    /// </summary>
    public class MockBikeRoute : IBikeRoute
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name of the route
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the author name
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the places on route
        /// </summary>
        public string Places { get; set; }

        /// <summary>
        /// Gets or sets the distance of the route
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// Gets or sets the date of the route creation
        /// </summary>
        public DateTime DateCreated { get; set; }   

        #endregion Properties
       
    }
}