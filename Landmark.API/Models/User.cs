using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landmark.API.Models
{
    public class User
    {
        /// <summary>
        /// Gets or sets the id of user
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the username of the user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the last access date for the user
        /// </summary>
        public DateTime? LastAccessed { get; set; }
    }
}