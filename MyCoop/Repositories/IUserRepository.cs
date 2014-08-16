using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories
{
    public interface IUserRepository : IStdRepository<User>
    {
        Task<User> GetUser(string email, string password);

        Task<User[]> GetUsersByGroupId(int groupId);

        Task Delete(int id);
    }
}