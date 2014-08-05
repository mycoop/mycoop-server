using System;
using System.Threading.Tasks;

namespace MyCoop.WebApi.Services
{
    public interface ISystemService
    {
        Task<int> Connect(string email, string password);


    }
}