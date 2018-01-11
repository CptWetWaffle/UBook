using System;
using ServicePrototype;

namespace UBook.Interfaces
{
    public interface IReservationManager
    {
        bool Avaliability(IService aService, IMemento aMemento);
    }
}
