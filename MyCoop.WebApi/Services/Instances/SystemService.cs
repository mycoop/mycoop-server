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
            return GetValues<UserModel, User, IUserRepository>(user => new UserModel(user));
        }

        public Task<UserModel> GetUser(int id)
        {
            return GetValue<UserModel, User, IUserRepository>(id, user => new UserModel(user));
        }

        public Task<int> AddUser(AddUserModel model)
        {
            return Add<User, IUserRepository>(user => user.Id, () => new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PermissionLevelId = model.PermissionLevelId,
                Email = model.Email,
                Password = SecurityHelper.GetHash(String.Concat(model.Email, model.Password))
            });
        }

        public Task UpdateUser(int id, UpdateUserModel model)
        {
            return Update<User, IUserRepository>(id, user =>
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.PermissionLevelId = model.PermissionLevelId;
            });
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
            return GetValues<GroupModel, Group, IGroupRepository>(group => new GroupModel(group), "ModifiedBy", "CreatedBy");
        }

        public Task<GroupModel> GetGroup(int id)
        {
            return GetValue<GroupModel, Group, IGroupRepository>(id, group => new GroupModel(group));
        }

        public Task<int> AddGroup(EditGroupModel model)
        {
            return Add<Group, IGroupRepository>(group => group.Id, model.GetEntity);
        }

        public Task UpdateGroup(int id, EditGroupModel model)
        {
            return Update<Group, IGroupRepository>(id, group =>
            {
                var entity = model.GetEntity();
                group.Name = entity.Name;
                group.Description = entity.Description;
                group.ModifiedByUserId = entity.ModifiedByUserId;
                group.ModifiedDate = DateTime.UtcNow;
            });
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