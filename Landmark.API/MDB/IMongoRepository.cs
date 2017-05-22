using System.Collections.Generic;
using System.Threading.Tasks;

namespace Landmark.API.MDB
{
    public interface IMongoRepository
    {
        Task<UserLocationModel> AddUser(UserLocationModel user);
        Task<List<UserLocationModel>> GetUserLocations(string username);

        Task<List<UserLocationModel>> GetUserLocations();
    }
}