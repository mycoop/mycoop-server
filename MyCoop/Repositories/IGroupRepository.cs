using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task<Group[]> GetGroupsByUserId(int userId);
    }
}