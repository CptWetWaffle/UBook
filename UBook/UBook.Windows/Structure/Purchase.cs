using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicePrototype;
using UBook.Interfaces;

namespace UBook.Structure
{
    public class Purchase : IPurchase
    {
        public MbCard Card { get; set; }

        public IUser User { get; set; }

        public IService Service { get; set; }
    }
}
