using System.Collections.Generic;
using ServicePrototype;

namespace UBook.Interfaces
{
    public interface IService
    {
        int Id { get;  }
        IServiceType Type { get; set; }
        IList<IServiceValue> ServiceValues { get;  }
        string ToString();
        bool CheckAvailablility(IMemento aMemento);
        string LineToString();
        void AddValues(string name, string value);

        void Clone(IService var);
    }
}
