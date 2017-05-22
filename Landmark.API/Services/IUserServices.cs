
namespace Landmark.API.Services
{
    using Landmark.API.DTO;
    using Landmark.API.Models;
    using MDB;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserServices
    {
        Task<UserDTO> AddUser(UserDTO user);
        Task<UserDTO> GetUser(string username);
        Task<List<UserLocationModel>> GetMdbUserAsync(string username);

    }
}