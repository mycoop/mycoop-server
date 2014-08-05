using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(CoopEntities context)
            : base(context)
        {
        }

        protected override DbSet<User> ObjectSet
        {
            get { return Context.Users; }
        }

        public Task<User> GetUser(string email, string password)
        {
            return ObjectSet.SingleOrDefaultAsync(user => user.Email == email && user.Password == password);
        }

        public User GetUser(int id)
        {
            return ObjectSet.Single(user => user.Id == id);
        }

        public User GetUser(string email)
        {
            return ObjectSet.SingleOrDefault(user => user.Email == email);
        }

        public bool HasUser(string email)
        {
            return ObjectSet.Any(user => user.Email == email);
        }

        public Task<User[]> GetUsers()
        {
            return GetEntities("PermissionLevel").ToArrayAsync();
        }
    }
}