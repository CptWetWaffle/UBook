using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBook.Interfaces;

namespace ServicePrototype
{
    public class ServiceProperty:IServiceProperty
    {
        private readonly IList<IServiceValue> _serviceValues = new List<IServiceValue>();
        public IServiceType ServiceType { get; set; }
        public IList<IServiceValue> ServiceValues { get { return _serviceValues; } }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Default { get; private set; }

        public ServiceProperty()
        {
            Default = "Property";
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Name) ? Default + ": " : Name + ": ";
        }
    }
}
