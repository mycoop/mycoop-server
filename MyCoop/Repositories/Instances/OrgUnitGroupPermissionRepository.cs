using System.Data.Entity;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class OrgUnitGroupPermissionRepository : RepositoryBase<OrgUnitGroupPermission>, IOrgUnitGroupPermissionRepository
    {
        public OrgUnitGroupPermissionRepository(CoopEntities context) : base(context)
        {
        }

        protected override DbSet<OrgUnitGroupPermission> ObjectSet
        {
            get { return Context.OrgUnitGroupPermissions; }
        }
    }
}