using System;
using System.Linq;
using System.Threading.Tasks;
using MyCoop.Data;
using MyCoop.Helpers;
using MyCoop.Repositories;
using MyCoop.WebApi.Models.Users;

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

        public Task<UserModel[]> GetUsers()
        {
            var tcs = new TaskCompletionSource<UserModel[]>();
            Repository.GetWithContext<IUserRepository>().GetUsers().ContinueWith(_ =>
            {
                if (_.Exception != null)
                {
                    tcs.SetException(_.Exception);
                }
                else
                {
                    var users = _.Result;
                    tcs.SetResult(users.Select(u => new UserModel
                    {
                        Id = u.Id,
                        Email = u.Email,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        LastAcitve = u.LastAcitve,
                        PermissionLevelId = u.PermissionLevelId
                    }).ToArray());

                }
            });
            return tcs.Task;
        }

        public Task<UserModel> GetUser(int id)
        {
            var tcs = new TaskCompletionSource<UserModel>();
            Repository.GetWithContext<IUserRepository>().GetUser(id).ContinueWith(_ =>
            {
                if (_.Exception != null)
                {
                    tcs.SetException(_.Exception);
                }
                else
                {
                    var user = _.Result;
                    tcs.SetResult(new UserModel
                    {
                        Id = user.Id,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        LastAcitve = user.LastAcitve,
                        PermissionLevelId = user.PermissionLevelId
                    });

                }
            });
            return tcs.Task;
        }

        public Task<int> AddUser(AddUserModel model)
        {
            var tcs = new TaskCompletionSource<int>();
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PermissionLevelId = model.PermissionLevelId,
                Email = model.Email,
                Password = SecurityHelper.GetHash(String.Concat(model.Email, model.Password))
            };

            var userRepository = Repository.GetWithContext<IUserRepository>();
            userRepository.Add(user);

            Repository.SaveChangesAsync().ContinueWith(_ =>
            {
                if (_.Exception != null)
                {
                    tcs.SetException(_.Exception);
                }
                else
                {
                    tcs.SetResult(user.Id);
                }
            });
            return tcs.Task;
        }

        public Task UpdateUser(int id, UpdateUserModel model)
        {
            var tcs = new TaskCompletionSource<int>();
            var userRepository = Repository.GetWithContext<IUserRepository>();
            userRepository.GetUser(id).ContinueWith(_ =>
            {
                if (_.Exception != null)
                {
                    tcs.SetException(_.Exception);
                }
                else
                {
                    var user = _.Result;
                    user.Email = model.Email;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.PermissionLevelId = model.PermissionLevelId;
                    Repository.SaveChanges();
                    tcs.SetResult(0);
                }
            });
            return tcs.Task;
        }

        public Task<GroupModel[]> GetUserGroups(int id)
        {
            var tcs = new TaskCompletionSource<GroupModel[]>();
            Repository.GetWithContext<IGroupRepository>().GetGroupsByUserId(id).ContinueWith(_ =>
            {
                if (_.Exception != null)
                {
                    tcs.SetException(_.Exception);
                }
                else
                {
                    var users = _.Result;
                    tcs.SetResult(users.Select(group => new GroupModel
                    {
                        Name = group.Name,
                        Description = group.Description,
                        CreationTime = group.CreatedDate,
                        ModificationTime = group.ModifiedDate,
                        CreatedBy = group.CreatedByUserId,
                        ModifiedBy = group.ModifiedByUserId
                    }).ToArray());

                }
            });
            return tcs.Task;
        }

        public Task DeleteUser(int id)
        {
            var user = new User
            {
                Id = id
            };
            var userRepository = Repository.GetWithContext<IUserRepository>();
            userRepository.Attach(user);
            userRepository.Delete(user);
            return Repository.SaveChangesAsync();
        }
    }
}