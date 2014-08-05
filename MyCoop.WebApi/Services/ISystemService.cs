using System;
using System.Threading.Tasks;
using MyCoop.WebApi.Models.Users;

namespace MyCoop.WebApi.Services
{
    public interface ISystemService
    {
        Task<int> Connect(string email, string password);

        Task<UserModel[]> GetUsers();

        Task<UserModel> GetUser(int id);

        Task DeleteUser(int id);

        Task<int> AddUser(AddUserModel model);

        Task UpdateUser(int id, UpdateUserModel model);

        Task<GroupModel[]> GetUserGroups(int id);
    }
}