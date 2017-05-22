namespace Landmark.API.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// User DTO object
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// Gets or sets the id of user
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the username of the user
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the last access date for the user
        /// </summary>
        public DateTime? LastAccessed { get; set; }

        /// <summary>
        /// Gets or sets a collection of user locations
        /// </summary>
        public List<UserLocationDTO> UserLocations { get; set; }
    }
}