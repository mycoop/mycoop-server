using System.Data.Entity;
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
    }
}