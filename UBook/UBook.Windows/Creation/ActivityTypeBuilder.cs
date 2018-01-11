using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBook.Data;
using UBook.Interfaces;
using UBook.Structure;

namespace ServicePrototype
{
    class ActivityTypeBuilder : ITypeBuilder
    {
        public void BuildServiceType(string name, char dp)
        {
            foreach (var sTypes in DataHolder.GetInstance().ServiceTypes.Where(sTypes => sTypes.Name == name))
            {
                Type = sTypes;
                return;
            }

            if (dp != 'p')
                Type = new DurationType { Name = name };
            else
                Type = new PunctualType { Name = name };
            
            IServiceProperty props = new ServiceProperty { Name = "name", Type = "string", ServiceType = Type };
            Type.ServiceProperties.Add("name",props);
            props = new ServiceProperty { Name = "location", Type = "string", ServiceType = Type };
            Type.ServiceProperties.Add("location",props);
            props = new ServiceProperty { Name = "price", Type = "double", ServiceType = Type };
            Type.ServiceProperties.Add("price",props);
            props = new ServiceProperty { Name = "description", Type = "string", ServiceType = Type };
            Type.ServiceProperties.Add("description", props);
            props = new ServiceProperty { Name = "n_people", Type = "double", ServiceType = Type };
            Type.ServiceProperties.Add("n_people",props);
            DataHolder.GetInstance().ServiceTypes.Add(Type);

            if (dp != 'p')
            {
                props = new ServiceProperty { Name = "intialdate", Type = "date", ServiceType = Type };
                Type.ServiceProperties.Add("initialdate",props);
                props = new ServiceProperty { Name = "enddate", Type = "time", ServiceType = Type };
                Type.ServiceProperties.Add("enddate",props);
                Type.TwoDates = true;
            }
            else
            {
                props = new ServiceProperty { Name = "date", Type = "date", ServiceType = Type };
                Type.ServiceProperties.Add("date", props);
                props = new ServiceProperty { Name = "time", Type = "time", ServiceType = Type };
                Type.ServiceProperties.Add("time", props);
                Type.TwoDates = false;
            }
        }

        public IServiceType Type { get; private set; }
    }
}
