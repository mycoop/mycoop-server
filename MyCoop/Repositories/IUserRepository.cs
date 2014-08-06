﻿using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUser(string email, string password);

        Task<User> GetUser(int id);

        User GetUser(string email);

        bool HasUser(string email);

        Task<User[]> GetUsers();

        Task<User[]> GetUsersByGroupId(int groupId);

        Task Delete(int id);
    }
}