using System;
using System.Linq;
using System.Threading.Tasks;
using MyCoop.Data;
using MyCoop.Helpers;
using MyCoop.Repositories;
using MyCoop.WebApi.Models.Users;
using MyCoop.WebApi.Models.Groups;

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
                    tcs.SetResult(users.Select(user => new UserModel(user)).ToArray());

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
                    tcs.SetResult(new UserModel(user));

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
                    //user.Email = model.Email;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.PermissionLevelId = model.PermissionLevelId;
                    Repository.SaveChanges();
                    tcs.SetResult(0);
                }
            });
            return tcs.Task;
        }

        public Task<UserGroupModel[]> GetUserGroups(int userId)
        {
            var tcs = new TaskCompletionSource<UserGroupModel[]>();
            Repository.GetWithContext<IUserGroupRepository>().GetUserGroups(userId, null).ContinueWith(_ =>
            {
                if (_.Exception != null)
                {
                    tcs.SetException(_.Exception);
                }
                else
                {
                    var userGroups = _.Result;
                    tcs.SetResult(userGroups.Select(ug => new UserGroupModel(ug)).ToArray());

                }
            });
            return tcs.Task;
        }

        public Task DeleteUser(int id)
        {
            return Repository.GetWithContext<IUserRepository>().Delete(id);
        }

        public Task<GroupModel[]> GetGroups()
        {
            var tcs = new TaskCompletionSource<GroupModel[]>();
            Repository.GetWithContext<IGroupRepository>().GetGroups().ContinueWith(_ =>
            {
                if (_.Exception != null)
                {
                    tcs.SetException(_.Exception);
                }
                else
                {
                    var goups = _.Result;
                    tcs.SetResult(goups.Select(group => new GroupModel(group)).ToArray());

                }
            });
            return tcs.Task;
        }

        public Task<GroupModel> GetGroup(int id)
        {
            var tcs = new TaskCompletionSource<GroupModel>();
            Repository.GetWithContext<IGroupRepository>().GetGroup(id).ContinueWith(_ =>
            {
                if (_.Exception != null)
                {
                    tcs.SetException(_.Exception);
                }
                else
                {
                    var group = _.Result;
                    tcs.SetResult(new GroupModel(group));

                }
            });
            return tcs.Task;
        }

        public Task<int> AddGroup(EditGroupModel model)
        {
            var tcs = new TaskCompletionSource<int>();

            var group = model.Entity;
            group.ModifiedDate = DateTime.UtcNow;
            group.CreatedDate = DateTime.UtcNow;

            var groupRepository = Repository.GetWithContext<IGroupRepository>();
            groupRepository.Add(group);

            Repository.SaveChangesAsync().ContinueWith(_ =>
            {
                if (_.Exception != null)
                {
                    tcs.SetException(_.Exception);
                }
                else
                {
                    tcs.SetResult(group.Id);
                }
            });
            return tcs.Task;
        }

        public Task UpdateGroup(int id, EditGroupModel model)
        {
            var tcs = new TaskCompletionSource<int>();
            var userRepository = Repository.GetWithContext<IGroupRepository>();
            model.Entity.ModifiedDate = DateTime.UtcNow;
            userRepository.GetGroup(id).ContinueWith(_ =>
            {
                if (_.Exception != null)
                {
                    tcs.SetException(_.Exception);
                }
                else
                {
                    var group = _.Result;
                    var entity = model.Entity;
                    group.Name = entity.Name;
                    group.Description = entity.Description;
                    //group.CreatedByUserId = entity.CreatedByUserId;
                    group.ModifiedByUserId = entity.ModifiedByUserId;
                    group.ModifiedDate = DateTime.UtcNow;
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

        public Task DeleteGroup(int id)
        {
            return Repository.GetWithContext<IGroupRepository>().Delete(id);
        }

        public Task<GroupUserModel[]> GetGroupUsers(int groupId)
        {
            var tcs = new TaskCompletionSource<GroupUserModel[]>();
            Repository.GetWithContext<IUserGroupRepository>().GetUserGroups(null, groupId).ContinueWith(_ =>
            {
                if (_.Exception != null)
                {
                    tcs.SetException(_.Exception);
                }
                else
                {
                    var userGroups = _.Result;
                    tcs.SetResult(userGroups.Select(ug => new GroupUserModel(ug)).ToArray());

                }
            });
            return tcs.Task;
        }

        public Task AddUserToGroup(int userId, int groupId)
        {
            var userGroup = new UserGroup 
            {
                UserId = userId,
                GroupId = groupId,
                CreatedDate = DateTime.UtcNow
            };

            var userGroupRepository = Repository.GetWithContext<IUserGroupRepository>();
            userGroupRepository.Add(userGroup);

            return Repository.SaveChangesAsync();
        }

        public Task RemoveUserFromGroup(int userId, int groupId)
        {
            var userGroup = new UserGroup
            {
                UserId = userId,
                GroupId = groupId
            };

            var userGroupRepository = Repository.GetWithContext<IUserGroupRepository>();
            userGroupRepository.Attach(userGroup);
            userGroupRepository.Delete(userGroup);

            return Repository.SaveChangesAsync();
        }
    }
}