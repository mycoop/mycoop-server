using System.Data.Entity;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class OrgUnitUserPermissionRepository : RepositoryBase<OrgUnitUserPermission>, IOrgUnitUserPermissionRepository
    {
        public OrgUnitUserPermissionRepository(CoopEntities context) : base(context)
        {
        }

        protected override DbSet<OrgUnitUserPermission> ObjectSet
        {
            get { return Context.OrgUnitUserPermissions; }
        }
    }
}