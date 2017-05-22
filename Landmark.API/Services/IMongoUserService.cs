using System.Collections.Generic;
using System.Threading.Tasks;
using Landmark.API.MDB;

namespace Landmark.API.Services
{
    public interface IMongoUserService
    {
        Task<UserLocationModel> AddUserLocationAsync(UserLocationModel userLocation);
        Task<List<UserLocationModel>> GetUserLocationAsync(string username);
    }
}