using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landmark.API.Models
{
    public class UserLocation
    {
        /// <summary>
        /// Gets or sets the id of the user location DTO
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user id where the location belongs to
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the latitude of the location
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longtitude of the location
        /// </summary>
        public decimal Longtitude { get; set; }

        /// <summary>
        /// Gets or sets the notes of the user location.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the creattion date of the user location
        /// </summary>
        public DateTime DateCreated { get; set; }
    }
}