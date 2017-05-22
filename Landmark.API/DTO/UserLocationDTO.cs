
namespace Landmark.API.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// The user location data transfer object
    /// </summary>
    public class UserLocationDTO
    {
        /// <summary>
        /// Gets or sets the id of the user location DTO
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user id where the location belongs to
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the latitude of the location
        /// </summary>
        [Required]
        public decimal Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longtitude of the location
        /// </summary>
        [Required]
        public decimal Longtitude { get; set; }

        /// <summary>
        /// Gets or sets the creattion date of the user location
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the address of the location
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the note remarks for the location
        /// </summary>
        public string Notes { get; set; }
    }
}