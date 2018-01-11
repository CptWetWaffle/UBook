using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicePrototype;
using UBook.Interfaces;

namespace UBook.Behavior
{
    public abstract class DecoratorServiceType:IServiceType
    {
        protected readonly IServiceType _darthVader;
        protected readonly IList<IService> _mServices;
        protected readonly IDictionary<string, IServiceProperty> _mServiceProperties;

        public IList<IService> Services
        {
            get { return _mServices; }
        }
        public IDictionary<string, IServiceProperty> ServiceProperties {
            get { return _mServiceProperties; }
        }

        public string Name
        {
            get { return _darthVader.Name; }
            set { }
        }

        protected DecoratorServiceType(IServiceType aServiceType)
        {
            _darthVader = aServiceType;
            _mServices = new List<IService>();
            _mServiceProperties = new Dictionary<string, IServiceProperty>();
        }

        public IServiceProperty GetProperty(string key)
        {
            return ServiceProperties.ContainsKey(key) ? ServiceProperties[key] : _darthVader.GetProperty(key);
        }

        public abstract bool CheckAvailability(IMemento aParam, IService aService);

        public override string ToString()
        {
            return _darthVader.ToString();
        }

        public  string LineToString()
        {
            throw new NotImplementedException();
        }
    }
}
