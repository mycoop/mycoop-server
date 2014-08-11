using System;
using MyCoop.Data;

namespace MyCoop.WebApi.Models.OrgUnits
{
    public class OrgUnitModel
    {
        private readonly OrgUnit _orgUnit;
        private readonly LocationModel _location;

        public OrgUnitModel(OrgUnit orgUnit)
        {
            _orgUnit = orgUnit;
            _location = new LocationModel {Lat = _orgUnit.Lat, Lng = _orgUnit.Lng};
        }

        public int Id
        {
            get { return _orgUnit.Id; }
        }

        public string Name
        {
            get { return _orgUnit.Name; }
        }

        public string Address
        {
            get { return _orgUnit.Address; }
        }

        public LocationModel Location
        {
            get { return _location; }
        }

        public DateTime CreationTime
        {
            get { return _orgUnit.CreationTime; }
        }

        public DateTime ModificationTime
        {
            get { return _orgUnit.ModificationTime; }
        }

        public int OwnerId
        {
            get { return _orgUnit.OwnerId; }
        }

        public int? ParentId
        {
            get { return _orgUnit.ParentId; }
        }
    }
}