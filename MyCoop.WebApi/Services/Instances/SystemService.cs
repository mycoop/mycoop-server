using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web;
using MyCoop.Helpers;
using MyCoop.Repositories;

namespace MyCoop.WebApi.Services.Instances
{
    public class SystemService : ServiceBase, ISystemService
    {
        public SystemService(IRepositoryManager repository)
            : base(repository)
        {
        }

        public Task<int> Connect(string email, string password)
        {
            var tcs = new TaskCompletionSource<int>();
            var hash = SecurityHelper.GetHash(String.Concat(email, password));
            Repository.GetWithContext<IUserRepository>().GetUser(email, hash).ContinueWith(_ =>
            {
                if (_.Exception != null)
                {
                    tcs.SetException(_.Exception);
                }
                else
                {
                    var user = _.Result;
                    if (user != null)
                    {
                        tcs.SetResult(user.Id);
                    }
                    else
                    {
                        tcs.SetResult(-1);
                    }
                    
                }
            });
            return tcs.Task;
        }
    }
}