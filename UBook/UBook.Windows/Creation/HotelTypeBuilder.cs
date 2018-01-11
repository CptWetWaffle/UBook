using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBook.Data;
using UBook.Interfaces;

namespace ServicePrototype  
{
    class HotelTypeBuilder:ITypeBuilder
    {
        public void BuildServiceType(string name, char dp)
        {
            foreach (var sTypes in DataHolder.GetInstance().ServiceTypes.Where(sTypes => sTypes.Name == name))
            {
                Type = sTypes;
                return;
            }

            Type = new DurationType {Name = name};
            IServiceProperty props = new ServiceProperty { Name = "name", Type = "string", ServiceType = Type };
            Type.ServiceProperties.Add("name", props);
            props = new ServiceProperty { Name = "location", Type = "string", ServiceType = Type };
            Type.ServiceProperties.Add("location", props);
            props = new ServiceProperty { Name = "price", Type = "double", ServiceType = Type };
            Type.ServiceProperties.Add("price", props);
            props = new ServiceProperty { Name = "description", Type = "string", ServiceType = Type };
            Type.ServiceProperties.Add("description", props);
            props = new ServiceProperty { Name = "intialdate", Type = "date", ServiceType = Type };
            Type.ServiceProperties.Add("initialdate",props);
            props = new ServiceProperty { Name = "enddate", Type = "date", ServiceType = Type };
            Type.ServiceProperties.Add("enddate", props);
            props = new ServiceProperty { Name = "n_rooms", Type = "double", ServiceType = Type };
            Type.ServiceProperties.Add("n_rooms", props);
            Type.TwoDates = true;
            DataHolder.GetInstance().ServiceTypes.Add(Type);
        }

        public IServiceType Type { get; private set; }
    }
}
