using System.Collections.Generic;
using System.Threading.Tasks;
using Landmark.API.MDB;

namespace Landmark.API.Services
{
    public class MongoUserService : IMongoUserService
    {
        private readonly IMongoRepository mongoRepo;
        public MongoUserService(IMongoRepository injectedMongoRepo)
        {
            this.mongoRepo = injectedMongoRepo;
        }

        /// <summary>
        /// Creates a user location
        /// </summary>
        /// <param name="userLocation">The user location model</param>
        /// <returns></returns>
        public async Task<UserLocationModel> AddUserLocationAsync(UserLocationModel userLocation)
        {
            return await this.mongoRepo.AddUser(userLocation);
        }

        /// <summary>
        /// Retrieves all user locations by username. If username is empty, it will retrieve all locations
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<List<UserLocationModel>> GetUserLocationAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return await this.mongoRepo.GetUserLocations();
            }

            return await this.mongoRepo.GetUserLocations(username);
        }   

    }
}