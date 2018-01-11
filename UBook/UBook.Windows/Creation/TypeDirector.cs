using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBook.Interfaces;

namespace ServicePrototype
{
    class TypeDirector:ITypeDirector
    {
        private ITypeBuilder TypeBuilder { get; set; }

        public TypeDirector(ITypeBuilder type)
        {
            TypeBuilder = type;
        }

        public IServiceType MakeType(string name, char dp)
        {
            TypeBuilder.BuildServiceType(name, dp);
            return TypeBuilder.Type;
        }
    }
}
