using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBook.Structure;

namespace UBook.Interfaces
{
    public interface IShoppingCart : ISubject
    {
        IList<IService> Items { get; }

        IUser User { set; }

        void Purchase();

        int Num { get; }

        IMemento Parameters { get; set; }

        void AddToCart(IService aService);
    }
}
