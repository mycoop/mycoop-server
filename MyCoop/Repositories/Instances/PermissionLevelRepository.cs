using System.Data.Entity;
using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class PermissionLevelRepository : RepositoryBase<PermissionLevel>, IPermissionLevelRepository
    {
        public PermissionLevelRepository(CoopEntities context) : base(context)
        {
        }

        protected override DbSet<PermissionLevel> ObjectSet
        {
            get { return Context.PermissionLevels; }
        }

        public Task<PermissionLevel> GetValue(int id, params string[] includes)
        {
            return GetEntities(includes).SingleAsync(entity => entity.Id == id);
        }
    }
}