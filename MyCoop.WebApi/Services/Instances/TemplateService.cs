using System.Threading.Tasks;
using MyCoop.Data;
using MyCoop.Repositories;
using MyCoop.WebApi.Models.Components;

namespace MyCoop.WebApi.Services.Instances
{
    public class TemplateService : ServiceBase, ITemplateService
    {
        public TemplateService(IRepositoryManager repository) : base(repository)
        {

        }

        public Task<ComponentModel[]> GetComponents()
        {
            return GetValues<ComponentModel, Component, IComponentRepository>(component => new ComponentModel(component));
        }

        public Task<ComponentModel> GetComponent(int id)
        {
            return GetValue<ComponentModel, Component, IComponentRepository>(id, component => new ComponentModel(component));
        }

        public Task<int> AddComponent(EditComponentModel model)
        {
            return Add<Component, IComponentRepository>(component => component.Id, model.GetEntity);
        }

        public Task UpdateComponent(int id, EditComponentModel model)
        {
            return Update<Component, IComponentRepository>(id, component =>
            {
                var entity = model.GetEntity();
                component.Name = entity.Name;
            });
        }

        public Task DeleteComponent(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}