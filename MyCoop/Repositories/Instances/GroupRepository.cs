using System.Data.Entity;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class GroupRepository : RepositoryBase<Group>, IGroupRepository
    {
        public GroupRepository(CoopEntities context) : base(context)
        {
        }

        protected override DbSet<Group> ObjectSet
        {
            get { return Context.Groups; }
        }
    }
}