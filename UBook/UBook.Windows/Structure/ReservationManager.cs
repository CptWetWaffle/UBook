using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using ServicePrototype;
using UBook.Data;
using UBook.Interfaces;

namespace UBook.Structure
{
    public class ReservationManager:IReservationManager
    {
        public IMemento Memento { get; set; }

        #region singleton
        private static ReservationManager _instance;
        private static readonly Object RootSync = new Object();
        private ReservationManager()
        {

        }

        public static ReservationManager GetInstance()
        {
            if (_instance == null)
            {
                lock (RootSync)
                {
                    if(_instance== null)
                        _instance = new ReservationManager();
                }
            }
            return _instance;
        }
        #endregion
        public bool Avaliability(IService aService, IMemento aMemento)
        {
            return aService.CheckAvailablility(aMemento);
        }

    }
}
