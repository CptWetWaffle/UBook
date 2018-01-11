using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicePrototype;
using UBook.Data;
using UBook.Interfaces;

namespace UBook.Behavior
{
     public class TransportServiceType:IServiceType
    {
        private readonly IList<IService> _mServices;
        private readonly IDictionary<string, IServiceProperty> _mServiceProperties;
        public IList<IService> Services{
            get { return _mServices; }
        }

        public IDictionary<string, IServiceProperty> ServiceProperties
        {
            get { return _mServiceProperties; }
        }

        public string Name { get; set; }

        public TransportServiceType()
        {
            _mServices = new List<IService>();
            _mServiceProperties = new Dictionary<string, IServiceProperty>();
            Name = "Transport";

            IServiceProperty props = new ServiceProperty { Name = "name", Type = "string", ServiceType = this };
            ServiceProperties.Add("name", props);
            props = new ServiceProperty { Name = "location", Type = "string", ServiceType = this };
            ServiceProperties.Add("location", props);
            props = new ServiceProperty { Name = "price", Type = "double", ServiceType = this };
            ServiceProperties.Add("price", props);
            props = new ServiceProperty { Name = "description", Type = "string", ServiceType = this };
            ServiceProperties.Add("description", props);
            props = new ServiceProperty { Name = "quantity", Type = "double", ServiceType = this };
            ServiceProperties.Add("quantity", props);
            DataHolder.GetInstance().ServiceTypes.Add(this);
        }

         public IServiceProperty GetProperty(string key)
         {
             return ServiceProperties.ContainsKey(key) ? ServiceProperties[key] : null;
         }

         public bool CheckAvailability(IMemento aParam, IService aService)
        {
            var wQt = 0;
            var tQt = 0;
            foreach (var a in aService.ServiceValues.Where(a => a.Property.Name == "quantity"))
            {
                wQt = Convert.ToInt32(a.Value);
            }
            foreach (var v in DataHolder.GetInstance().Services.Where(a => a.Id == aService.Id).SelectMany(a => a.ServiceValues.Where(v => v.Property.Name == "quantity")))
            {
                tQt = Convert.ToInt32(v.Value);
            }
            return Convert.ToInt32(aParam.Get("qt")) + wQt <= tQt;
        }

        public override string ToString()
        {
            return "Service Type: " + Name + "\n";
        }

        public string LineToString()
        {
            return "Service Type: " + Name + "\n";
        }
    }
}
