using Landmark.API.DTO;
using Landmark.API.MDB;
using Landmark.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Landmark.API.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IUserServices userService;

        private IMongoUserService mongoService;

        public UserController(IUserServices injectedUserService, IMongoUserService injectedMongoUserService)
        {
            this.userService = injectedUserService;
            this.mongoService = injectedMongoUserService;
        }

        /// <summary>
        /// Controller to add user location
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<IHttpActionResult> AddUserLocation([FromBody]UserLocationModel user)
        {
            try
            {
                var createdUser = await this.mongoService.AddUserLocationAsync(user);
                return this.Ok(new { userLocation = createdUser });

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return await Task.FromResult(this.BadRequest("Unable to process your request."));
            }
        }

        /// <summary>
        /// Controller to retrieve all user locations
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetUserLocations()
        {
            try
            {
                var currentUser = await this.mongoService.GetUserLocationAsync(string.Empty);
                return this.Ok(new { location = currentUser });
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return await Task.FromResult(this.BadRequest("Unable to process your request."));
            }
        }
    }
}