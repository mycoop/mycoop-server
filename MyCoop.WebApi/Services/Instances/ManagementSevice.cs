using System.Threading.Tasks;
using MyCoop.Data;
using MyCoop.Repositories;
using MyCoop.WebApi.Models.OrgUnits;

namespace MyCoop.WebApi.Services.Instances
{
    public class ManagementSevice : ServiceBase, IManagementSevice
    {
        public ManagementSevice(IRepositoryManager repository)
            : base(repository)
        {
        }

        public Task<OrgUnitModel[]> GeOrgUnits()
        {
            return GetValues<OrgUnitModel, OrgUnit, IOrgUnitRepository>(orgUnit => new OrgUnitModel(orgUnit));
        }

        public Task<OrgUnitModel> GeOrgUnit(int id)
        {
            return GetValue<OrgUnitModel, OrgUnit, IOrgUnitRepository>(id, orgUnit => new OrgUnitModel(orgUnit));
        }

        public Task<int> AddOrgUnit(EditOrgUnitModel model)
        {
            return Add<OrgUnit, IOrgUnitRepository>(orgUnit => orgUnit.Id, model.GetEntity);
        }

        public Task UpdateOrgUnit(int id, EditOrgUnitModel model)
        {
            return Update<OrgUnit, IOrgUnitRepository>(id, orgUnit =>
            {
                var entity = model.GetEntity();
                orgUnit.Name = entity.Name;
                orgUnit.Address = entity.Address;
                orgUnit.OwnerId = entity.OwnerId;
                orgUnit.ParentId = entity.ParentId;
                orgUnit.ModificationTime = entity.ModificationTime;
                orgUnit.WorkspaceTemplateId = entity.WorkspaceTemplateId;
            });
        }

        public Task DeleteOrgUnit(int id)
        {
            return Delete<OrgUnit, IOrgUnitRepository>(id);
        }
    }
}