using System;
using MyCoop.Data;
using MyCoop.WebApi.Models.Users;

namespace MyCoop.WebApi.Models.Groups
{
    public class GroupModel
    {
        private readonly Group _group;
        private readonly UserModel _createdBy;
        private readonly UserModel _modifiedBy;

        public GroupModel(Group group)
        {
            _group = group;
            _createdBy = new UserModel(_group.CreatedBy);
            _modifiedBy = new UserModel(_group.ModifiedBy);
        }
        public int Id
        {
            get { return _group.Id; }
        }
        public string Name
        {
            get { return _group.Name; }
        }
        public string Description
        {
            get { return _group.Description; }
        }
        public DateTime CreationTime
        {
            get { return _group.CreatedDate; }
        }
        public DateTime ModificationTime
        {
            get { return _group.ModifiedDate; }
        }
        public UserModel CreatedBy
        {
            get { return _createdBy; }
        }
        public UserModel ModifiedBy
        {
            get { return _modifiedBy; }
        }
    }
}