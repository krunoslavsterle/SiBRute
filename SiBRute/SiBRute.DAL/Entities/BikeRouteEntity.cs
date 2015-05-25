using SiBRute.Model.Common;
using System;

namespace SiBRute.DAL.Entities
{
    public class BikeRouteEntity : IBikeRoute
    {
        /// <summary>
        /// Gets or sets the indentifier
        /// </summary>
        public int Id { get; set; }

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
    }
}
