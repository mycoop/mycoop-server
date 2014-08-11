using System;
using System.Collections.Generic;
using MyCoop.WebApi.Services.Instances;

namespace MyCoop.WebApi.Services
{
    public class ServiceManager : IServiceManager
    {
        private static readonly Dictionary<Type, Type> _mapTypes = new Dictionary<Type, Type>();

        static ServiceManager()
        {
            _mapTypes.Add(typeof(ISystemService), typeof(SystemService));
            _mapTypes.Add(typeof(IManagementSevice), typeof(ManagementSevice));
        }

        private readonly RepositoryManager _repositoryManager = new RepositoryManager();

        public void Dispose()
        {
            _repositoryManager.Dispose();
        }

        public T Get<T>()
        {
            return (T)Activator.CreateInstance(_mapTypes[typeof(T)], _repositoryManager);
        }
    }
}