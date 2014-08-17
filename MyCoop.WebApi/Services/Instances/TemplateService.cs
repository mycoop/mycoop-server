using System.Threading.Tasks;
using MyCoop.Data;
using MyCoop.Repositories;
using MyCoop.WebApi.Models.Components;
using MyCoop.WebApi.Models.DocumentTemplates;

namespace MyCoop.WebApi.Services.Instances
{
    public class TemplateService : ServiceBase, ITemplateService
    {
        public TemplateService(IRepositoryManager repository) : base(repository)
        {

        }

        public Task<ComponentModel[]> GetComponents()
        {
            return GetValues<ComponentModel, Component, IComponentRepository>(component => new ComponentModel(component), "DocumentTemplates");
        }

        public Task<ComponentModel> GetComponent(int id)
        {
            return GetValue<ComponentModel, Component, IComponentRepository>(id, component => new ComponentModel(component), "DocumentTemplates");
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
            return Repository.GetWithContext<IComponentRepository>().Delete(id);
        }

        public Task<DocumentTemplateModel[]> GetDocumentTemplates()
        {
            return GetValues<DocumentTemplateModel, DocumentTemplate, IDocumentTemplateRepository>(template => new DocumentTemplateModel(template));
        }

        public Task<DocumentTemplateModel> GetDocumentTemplate(int id)
        {
            return GetValue<DocumentTemplateModel, DocumentTemplate, IDocumentTemplateRepository>(id, template => new DocumentTemplateModel(template));
        }

        public Task<int> AddDocumentTemplate(EditDocumentTemplateModel model)
        {
            return Add<DocumentTemplate, IDocumentTemplateRepository>(template => template.Id, model.GetEntity);
        }

        public Task UpdateDocumentTemplate(int id, EditDocumentTemplateModel model)
        {
            return Update<DocumentTemplate, IDocumentTemplateRepository>(id, template =>
            {
                var entity = model.GetEntity();
                template.Name = entity.Name;
                template.Reference = entity.Reference;
                template.Purpose = entity.Purpose;
                template.ComponentId = entity.ComponentId;
            });
        }

        public Task DeleteDocumentTemplate(int id)
        {
            return Delete<DocumentTemplate, IDocumentTemplateRepository>(id);
        }
    }
}