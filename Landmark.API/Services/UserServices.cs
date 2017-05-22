using Landmark.API.DTO;
using Landmark.API.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Landmark.API.MDB;
using MongoDB.Bson.Serialization;

namespace Landmark.API.Services
{
    public class UserServices : IUserServices
    {
        public UserServices()
        {
        }

        /// <summary>
        /// Retrieves an existing user given a username. When successfully retrieved, the last accessed date is updated
        /// </summary>
        /// <param name="username">The user username</param>
        /// <returns>User DTO</returns>
        public async Task<UserDTO> GetUser(string username)
        {
            using (var db = new LandmarkDataAccess())
            {
                var user = db.Users.FirstOrDefault(u => u.Username == username);
                if (user == null) { throw new KeyNotFoundException($"Unable to find user with username {username}"); }

                var locations = await (from l in db.UserLocations.AsNoTracking()
                                       where l.UserId == user.Id
                                       select new UserLocationDTO
                                       {
                                           Id = l.Id,
                                           UserId = l.UserId,
                                           Latitude = l.Latitude,
                                           Longtitude = l.Longtitude,
                                           DateCreated = l.DateCreated
                                       }).ToListAsync();

                user.LastAccessed = DateTime.Now;
                await db.SaveChangesAsync();

                return new UserDTO
                {
                    Id = user.Id.ToString(),
                    Username = user.Username,
                    LastAccessed = user.LastAccessed,
                    UserLocations = locations
                };
            }
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user">The user DTO</param>
        /// <returns>User DTO</returns>
        public async Task<UserDTO> AddUser(UserDTO user)
        {
            var newUser = new User
            {
                LastAccessed = DateTime.Now,
                Username = user.Username
            };

            using (var db = new LandmarkDataAccess())
            {
                db.Users.Add(newUser);
                await db.SaveChangesAsync();

                user.Id = newUser.Id.ToString();
            }

            return user;
        }

        /// <summary>
        /// Retrieves Mongo Db user
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<List<UserLocationModel>> GetMdbUserAsync(string username)
        {
            var repo = new MongoRepository();
            return await repo.GetUserLocations(username);
        }

    }
}