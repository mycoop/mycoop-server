using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task<Group[]> GetGroupsByUserId(int userId);

        Task<Group[]> GetGroups();

        Task<Group> GetGroup(int id);

        Task Delete(int id);
    }
}