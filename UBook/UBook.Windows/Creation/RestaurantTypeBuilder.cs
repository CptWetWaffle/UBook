using System.Linq;
using ServicePrototype;
using UBook.Data;
using UBook.Interfaces;

namespace UBook.Creation
{
    class RestaurantTypeBuilder:ITypeBuilder
    {
        public void BuildServiceType(string name, char dp)
        {
            foreach (var sTypes in DataHolder.GetInstance().ServiceTypes.Where(sTypes => sTypes.Name == name))
            {
                Type = sTypes;
                return;
            }

            Type = new DurationType { Name = name };
            IServiceProperty props = new ServiceProperty { Name = "name", Type = "string", ServiceType = Type };
            Type.ServiceProperties.Add("name", props);
            props = new ServiceProperty { Name = "location", Type = "string", ServiceType = Type };
            Type.ServiceProperties.Add("location", props);
            props = new ServiceProperty { Name = "price", Type = "double", ServiceType = Type };
            Type.ServiceProperties.Add("price", props);
            props = new ServiceProperty { Name = "description", Type = "string", ServiceType = Type };
            Type.ServiceProperties.Add("description", props);
            props = new ServiceProperty { Name = "date", Type = "date", ServiceType = Type };
            Type.ServiceProperties.Add("date" ,props);
            props = new ServiceProperty { Name = "time", Type = "time", ServiceType = Type };
            Type.ServiceProperties.Add("time", props);
            props = new ServiceProperty { Name = "n_tables", Type = "double", ServiceType = Type };
            Type.ServiceProperties.Add("n_tables",props);
            Type.TwoDates = false;
            DataHolder.GetInstance().ServiceTypes.Add(Type);
        }

        public IServiceType Type { get; private set; }
    }
}
