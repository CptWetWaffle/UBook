using System;
using System.Collections.Generic;
using System.Linq;
using ServicePrototype;
using UBook.Interfaces;
using UBook.Structure;

namespace UBook.Data
{
    class DataHolder
    {
        private readonly IList<IService> _services = new List<IService>();
        private readonly IList<IUser> _users = new List<IUser>();
        private readonly IList<IPurchase> _purchases = new List<IPurchase>();
        private readonly IList<IService> _reservations = new List<IService>();
        private readonly IList<IServiceType> _serviceTypes = new List<IServiceType>();

        #region Singleton
        private static DataHolder _dataHolder;
        private static readonly Object RootSync = new Object();

        private DataHolder()
        {
        }

        public static DataHolder GetInstance()
        {
            if(_dataHolder==null)
                lock (RootSync)
                {
                    if(_dataHolder==null)
                        _dataHolder = new DataHolder();

                }
            return _dataHolder;
        }
        #endregion

        public IList<IService> Services { get { return _services; } }
        public IList<IPurchase> Purchases { get { return _purchases; } }
        public IList<IService> Reservations { get { return _reservations; } }
        public IList<IServiceType> ServiceTypes { get { return _serviceTypes; } }
        public IList<IUser> Users { get { return _users; } }



    }
}
