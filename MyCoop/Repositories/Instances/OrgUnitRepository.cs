using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class OrgUnitRepository : RepositoryBase<OrgUnit>, IOrgUnitRepository
    {
        public OrgUnitRepository(CoopEntities context) : base(context)
        {
        }

        protected override DbSet<OrgUnit> ObjectSet
        {
            get { return Context.OrgUnits; }
        }

        public Task<OrgUnit[]> GeOrgUnits()
        {
            return GetEntities().ToArrayAsync();
        }

        public Task<OrgUnit> GeOrgUnit(int id)
        {
            return GetEntities().SingleAsync(orgUnit => orgUnit.Id == id);
        }
    }
}
