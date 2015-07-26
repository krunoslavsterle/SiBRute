using System;

namespace SiBRute.Model.Common
{
   /// <summary>
   /// Bike routes model class.
   /// </summary>
    public interface IBikeRoute
    {
        #region Properties

        /// <summary>
        /// Gets or sets the indentifier.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the route.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the author name.
        /// </summary>
        string Author { get; set; }

        /// <summary>
        /// Gets or sets the places on route.
        /// </summary>
        string Places { get; set; }

        /// <summary>
        /// Gets or sets the distance of the route.
        /// </summary>
        int Distance { get; set; }

        /// <summary>
        /// Gets or sets the date of the route creation.
        /// </summary>
        DateTime DateCreated { get; set; }        

        #endregion Properties        
    }
}
