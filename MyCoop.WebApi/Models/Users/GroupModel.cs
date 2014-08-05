using System;

namespace MyCoop.WebApi.Models.Users
{
    public class GroupModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModificationTime { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    }
}