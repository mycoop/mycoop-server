using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCoop.Data;
using MyCoop.Repositories;
using MyCoop.Repositories.Instances;

namespace MyCoop.WebApi.Services
{
    public class RepositoryManager : IRepositoryManager
    {
        private static readonly Dictionary<Type, Type> _mapTypes = new Dictionary<Type, Type>();

        static RepositoryManager()
        {
            _mapTypes.Add(typeof(IUserRepository), typeof(UserRepository));
            _mapTypes.Add(typeof(IGroupRepository), typeof(GroupRepository));
            _mapTypes.Add(typeof(IPermissionLevelRepository), typeof(PermissionLevelRepository));
        }

        private CoopEntities _context;

        private readonly List<CoopEntities> _contexts = new List<CoopEntities>();

        public T Get<T>()
        {
            return (T)Activator.CreateInstance(_mapTypes[typeof(T)]);
        }

        public T GetWithContext<T>()
        {
            if (_context == null)
            {
                _context = new CoopEntities();
                _contexts.Add(_context);
            }
            return (T)Activator.CreateInstance(_mapTypes[typeof(T)], _context);
        }

        public T GetWithNewContext<T>()
        {
            var context = new CoopEntities();
            _contexts.Add(context);
            return (T)Activator.CreateInstance(_mapTypes[typeof(T)], context);
        }

        public void SaveChanges()
        {
            foreach (var context in _contexts)
            {
                context.SaveChanges();
            }
        }

        public Task<int[]> SaveChangesAsync()
        {
            return Task.WhenAll(_contexts.Select(context => context.SaveChangesAsync()));
        }

        public void Dispose()
        {
            foreach (var context in _contexts)
            {
                context.Dispose();
            }
        }
    }
}