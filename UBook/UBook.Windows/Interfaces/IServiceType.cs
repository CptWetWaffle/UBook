using System.Collections.Generic;
using ServicePrototype;

namespace UBook.Interfaces
{
    public interface IServiceType
    {
        IList<IService> Services { get; }

        IDictionary<string,IServiceProperty> ServiceProperties { get; }
        string Name { get; set; }

        IServiceProperty GetProperty(string key);

        bool CheckAvailability(IMemento aMemento, IService aService);

        string LineToString();


    }
}
