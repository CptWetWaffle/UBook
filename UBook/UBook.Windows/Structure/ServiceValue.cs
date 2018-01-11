using ServicePrototype;
using UBook.Interfaces;

namespace UBook.Structure
{
    public class ServiceValue:IServiceValue
    {
        public IService Service { get; set; }
        public IServiceProperty Property { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return Property.ToString() + Value + "\n";
        }

        public string LineToString()
        {
            return Property.ToString() + Value + "\t";
        }

        public void Clone(IServiceValue value)
        {
            Service = value.Service;
            Property = value.Property;
            Value = value.Value;
        }
    }
}
