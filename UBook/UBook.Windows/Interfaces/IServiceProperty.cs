using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBook.Interfaces;

namespace ServicePrototype
{
    public interface IServiceProperty
    {
        IServiceType ServiceType { get; set; }
        IList<IServiceValue> ServiceValues { get; }
        string Name { get; set; }
        string Type { get; set; }
        string Default { get; }
        string ToString();
    }
}
