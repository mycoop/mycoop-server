using System;

namespace MyCoop.WebApi.Models.Users
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastAcitve { get; set; }
        public int PermissionLevelId { get; set; }
    }
}