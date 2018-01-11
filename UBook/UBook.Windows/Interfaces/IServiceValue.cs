using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBook.Interfaces;

namespace ServicePrototype
{
    public interface IServiceValue
    {
        IService Service { get; set; }
        IServiceProperty Property { get; set; }
        string Value { get; set; }

        string ToString();

        string LineToString();

        void Clone(IServiceValue value);
    }
}
