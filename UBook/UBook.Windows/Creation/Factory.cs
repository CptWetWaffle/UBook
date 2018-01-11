using System;
using ServicePrototype;
using UBook.Interfaces;
using UBook.Structure;

namespace UBook.Creation
{
    public class Factory: IFactory
    {
        #region Singleton
        private static Factory _factory;
        private static readonly Object RootSync = new Object();

        private Factory()
        {
        }

        public static Factory GetInstance()
        {
            if(_factory==null)
                lock (RootSync)
                {
                    if(_factory==null)
                        _factory = new Factory();

                }
            return _factory;
        }
        #endregion

        public IUser MakeUser()
        {
            var p = MakeProfile();
            IUser h = new User {Profile = p};
            h.Profile.User = h;
            h.ShoppingCart = MakeShoppingCart();
            h.ShoppingCart.User = h;
            return h;
        }

        private IProfile MakeProfile()
        {
            return new Profile();
        }

        private IShoppingCart MakeShoppingCart()
        {
            return new ShoppingCart();
        }

        public IService MakeService()
        {
            return new Service();
        }

        public IServiceValue MakeServiceValue()
        {
            return new ServiceValue();
        }

        public IPurchase MakePurchase()
        {
            return new Purchase();
        }

       
    }
}
