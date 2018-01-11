using System.Collections.Generic;
using UBook.Structure;

namespace UBook.Interfaces
{
    public interface IUser
    {

        IList<IPurchase> Purchases { get; } 

        IList<IService> Reservations { get; }

        string Username { get; set; }

        IProfile Profile { get; set; }

        string Email { get; set; }

        bool IsAdmin { get; set; }

        string Password { set; }

        IShoppingCart ShoppingCart { get; set; }

        bool Authenticate(string aUsername, string aPassword);
        


    }
}
