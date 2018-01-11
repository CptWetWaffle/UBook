using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicePrototype;
using UBook.Structure;

namespace UBook.Interfaces
{
    public interface IFactory
    {
        IUser MakeUser();

        IService MakeService();

        IServiceValue MakeServiceValue();

        IPurchase MakePurchase();

       
    }
}
