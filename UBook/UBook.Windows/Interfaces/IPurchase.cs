using ServicePrototype;
using UBook.Structure;

namespace UBook.Interfaces
{
    public interface IPurchase
    {
        MbCard Card { get; set; }
        IUser User { get; set; }
        IService Service { get; set; }
    }
}
