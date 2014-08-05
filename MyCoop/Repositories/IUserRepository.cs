using System.Collections.Generic;
using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUser(string email, string password);

        User GetUser(int id);

        User GetUser(string email);

        bool HasUser(string email);

        Task<User[]> GetUsers();
    }
}