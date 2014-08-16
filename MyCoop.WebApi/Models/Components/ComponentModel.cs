using MyCoop.Data;

namespace MyCoop.WebApi.Models.Components
{
    public class ComponentModel
    {
        private readonly Component _component;

        public ComponentModel(Component component)
        {
            _component = component;
        }

        public int Id
        {
            get { return _component.Id; }
        }
        public string Name
        {
            get { return _component.Name; }
        }
    }
}