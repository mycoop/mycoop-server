using MyCoop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCoop.WebApi.Models.Groups
{
    public class EditGroupModel
    {
        private readonly Group _group = new Group();

        public string Name
        {
            get { return _group.Name; }
            set { _group.Name = value; }
        }
        public string Description
        {
            get { return _group.Description; }
            set { _group.Description = value; }
        }
        public int CreatedBy
        {
            get { return _group.CreatedByUserId; }
            set { _group.CreatedByUserId = value; }
        }
        public int ModifiedBy
        {
            get { return _group.ModifiedByUserId; }
            set { _group.ModifiedByUserId = value; }
        }

        public Group Entity
        {
            get { return _group; }
        }
    }
}