﻿using System.Data.Entity;
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

        public Task<OrgUnit> GetValue(int id, params string[] includes)
        {
            return GetEntities(includes).SingleAsync(entity => entity.Id == id);
        }

        public Task Delete(int id)
        {
            return Task.Run(() => Context.DeleteOrgUnit(id));
        }
    }
}
