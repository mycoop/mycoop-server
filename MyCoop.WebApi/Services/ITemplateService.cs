using System.Threading.Tasks;
using MyCoop.WebApi.Models.Components;
using MyCoop.WebApi.Models.DocumentTemplates;

namespace MyCoop.WebApi.Services
{
    public interface ITemplateService
    {
        Task<ComponentModel[]> GetComponents();

        Task<ComponentModel> GetComponent(int id);

        Task<int> AddComponent(EditComponentModel model);

        Task UpdateComponent(int id, EditComponentModel model);

        Task DeleteComponent(int id);

        Task<DocumentTemplateModel[]> GetDocumentTemplates();

        Task<DocumentTemplateModel> GetDocumentTemplate(int id);

        Task<int> AddDocumentTemplate(EditDocumentTemplateModel model);

        Task UpdateDocumentTemplate(int id, EditDocumentTemplateModel model);

        Task DeleteDocumentTemplate(int id);
    }
}