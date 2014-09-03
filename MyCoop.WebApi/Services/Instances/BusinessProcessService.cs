using MyCoop.Repositories;

namespace MyCoop.WebApi.Services.Instances
{
    public class BusinessProcessService : ServiceBase, IBusinessProcessService
    {
        public BusinessProcessService(IRepositoryManager repository) : base(repository)
        {
        }
    }
}