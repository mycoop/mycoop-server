using System;
using System.Linq;
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
            var tcs = new TaskCompletionSource<OrgUnitModel[]>();
            Repository.GetWithContext<IOrgUnitRepository>().GeOrgUnits().ContinueWith(_ =>
            {
                if (_.Exception != null)
                {
                    tcs.SetException(_.Exception);
                }
                else
                {
                    var orgUnits = _.Result;
                    tcs.SetResult(orgUnits.Select(orgUnit => new OrgUnitModel(orgUnit)).ToArray());

                }
            });
            return tcs.Task;
        }

        public Task<OrgUnitModel> GeOrgUnit(int id)
        {
            var tcs = new TaskCompletionSource<OrgUnitModel>();
            Repository.GetWithContext<IOrgUnitRepository>().GeOrgUnit(id).ContinueWith(_ =>
            {
                if (_.Exception != null)
                {
                    tcs.SetException(_.Exception);
                }
                else
                {
                    var orgUnit = _.Result;
                    tcs.SetResult(new OrgUnitModel(orgUnit));

                }
            });
            return tcs.Task;
        }

        public Task<int> AddOrgUnit(EditOrgUnitModel model)
        {
            var tcs = new TaskCompletionSource<int>();
            var entity = model.GetEntity();
            var orgUnit = new OrgUnit
            {
                Name = entity.Name,
                Address = entity.Address,
                Lat = entity.Lat,
                Lng = entity.Lng,
                ParentId = entity.ParentId,
                OwnerId = entity.OwnerId,
                CreationTime = DateTime.UtcNow,
                ModificationTime = DateTime.UtcNow
            };

            var userRepository = Repository.GetWithContext<IOrgUnitRepository>();
            userRepository.Add(orgUnit);

            Repository.SaveChangesAsync().ContinueWith(_ =>
            {
                if (_.Exception != null)
                {
                    tcs.SetException(_.Exception);
                }
                else
                {
                    tcs.SetResult(orgUnit.Id);
                }
            });
            return tcs.Task;
        }

        public Task UpdateOrgUnit(int id, EditOrgUnitModel model)
        {
            var tcs = new TaskCompletionSource<int>();
            var userRepository = Repository.GetWithContext<IOrgUnitRepository>();
            userRepository.GeOrgUnit(id).ContinueWith(_ =>
            {
                if (_.Exception != null)
                {
                    tcs.SetException(_.Exception);
                }
                else
                {
                    var orgUnit = _.Result;
                    var entity = model.GetEntity();
                    orgUnit.Name = entity.Name;
                    orgUnit.Address = entity.Address;
                    orgUnit.OwnerId = entity.OwnerId;
                    orgUnit.ParentId = entity.ParentId;
                    orgUnit.ModificationTime = DateTime.UtcNow;

                    if (model.Location != null)
                    {
                        orgUnit.Lat = entity.Lat;
                        orgUnit.Lng = entity.Lng;
                    }

                    Repository.SaveChangesAsync().ContinueWith(__ =>
                    {
                        if (__.Exception != null)
                        {
                            tcs.SetException(__.Exception);
                        }
                        else
                        {
                            tcs.SetResult(0);
                        }
                    });
                }
            });
            return tcs.Task;
        }

        public Task DeleteOrgUnit(int id)
        {
            var tcs = new TaskCompletionSource<int>();
            var userRepository = Repository.GetWithContext<IOrgUnitRepository>();
            userRepository.GeOrgUnit(id).ContinueWith(_ =>
            {
                if (_.Exception != null)
                {
                    tcs.SetException(_.Exception);
                }
                else
                {
                    var orgUnit = _.Result;
                    userRepository.Delete(orgUnit);
                    Repository.SaveChangesAsync().ContinueWith(__ =>
                    {
                        if (__.Exception != null)
                        {
                            tcs.SetException(__.Exception);
                        }
                        else
                        {
                            tcs.SetResult(0);
                        }
                    });
                }
            });
            return tcs.Task;
        }
    }
}