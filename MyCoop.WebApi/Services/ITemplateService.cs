using System.Threading.Tasks;
using MyCoop.WebApi.Models.Components;

namespace MyCoop.WebApi.Services
{
    public interface ITemplateService
    {
        Task<ComponentModel[]> GetComponents();

        Task<ComponentModel> GetComponent(int id);

        Task<int> AddComponent(EditComponentModel model);

        Task UpdateComponent(int id, EditComponentModel model);

        Task DeleteComponent(int id);
    }
}