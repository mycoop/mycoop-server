using System.Collections.Generic;

namespace MyCoop.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T value);

        void Attach(T value);

        void Delete(T value);

        IEnumerable<T> GetValues(params string[] includes);
    } 
}