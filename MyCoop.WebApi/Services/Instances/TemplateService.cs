using MyCoop.Repositories;

namespace MyCoop.WebApi.Services.Instances
{
    public class TemplateService : ServiceBase, ITemplateService
    {
        public TemplateService(IRepositoryManager repository) : base(repository)
        {

        }
    }
}