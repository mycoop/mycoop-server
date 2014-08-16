using System;
using System.Linq;
using System.Threading.Tasks;
using MyCoop.Repositories;

namespace MyCoop.WebApi.Services.Instances
{
    public abstract class ServiceBase
    {
        private readonly IRepositoryManager _repository;

        protected ServiceBase(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public IRepositoryManager Repository
        {
            get { return _repository; }
        }

        protected Task<TResult[]> GetValues<TResult, TEntity, TRepository>(Func<TEntity, TResult> mapper, params string[] includes)
            where TRepository : IRepository<TEntity>
        {
            var tcs = new TaskCompletionSource<TResult[]>();
            Repository.GetWithContext<TRepository>().GetValues(includes).ContinueWith(_ =>
            {
                if (_.Exception != null)
                {
                    tcs.SetException(_.Exception);
                }
                else
                {
                    tcs.SetResult(_.Result.Select(mapper).ToArray());
                }
            });
            return tcs.Task;
        }

        protected Task<TResult> GetValue<TResult, TEntity, TRepository>(int id, Func<TEntity, TResult> mapper, params string[] includes)
            where TRepository : IStdRepository<TEntity>
        {
            var tcs = new TaskCompletionSource<TResult>();
            Repository.GetWithContext<TRepository>().GetValue(id, includes).ContinueWith(_ =>
            {
                if (_.Exception != null)
                {
                    tcs.SetException(_.Exception);
                }
                else
                {
                    tcs.SetResult(mapper(_.Result));
                }
            });
            return tcs.Task;
        }

        protected Task<int> Add<TEntity, TRepository>( Func<TEntity, int> getId, Func<TEntity> getEntity)
            where TRepository : IRepository<TEntity>
        {
            var tcs = new TaskCompletionSource<int>();
            var entity = getEntity();
            var repository = Repository.GetWithContext<TRepository>();
            repository.Add(entity);
            Repository.SaveChangesAsync().ContinueWith(_ =>
            {
                if (_.Exception != null)
                {
                    tcs.SetException(_.Exception);
                }
                else
                {
                    tcs.SetResult(getId(entity));
                }
            });
            return tcs.Task;
        }

        protected Task Update<TEntity, TRepository>(int id, Action<TEntity> setter)
             where TRepository : IStdRepository<TEntity>
        {
            var tcs = new TaskCompletionSource<int>();
            var repository = Repository.GetWithContext<TRepository>();
            repository.GetValue(id).ContinueWith(_ =>
            {
                if (_.Exception != null)
                {
                    tcs.SetException(_.Exception);
                }
                else
                {
                    setter(_.Result);
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

        protected Task Delete<TEntity, TRepository>(int id)
            where TRepository : IStdRepository<TEntity>
        {
            var tcs = new TaskCompletionSource<int>();
            var repository = Repository.GetWithContext<TRepository>();
            repository.GetValue(id).ContinueWith(_ =>
            {
                if (_.Exception != null)
                {
                    tcs.SetException(_.Exception);
                }
                else
                {
                    repository.Delete(_.Result);
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