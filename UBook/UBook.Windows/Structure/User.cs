using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.ComponentModel.DataAnnotations;
using UBook.Interfaces;

namespace UBook.Structure
{
   
    public class User:IUser
    {
        private int Id { get; set; }
        private static int _uId = 0;
        public IShoppingCart ShoppingCart { get; set; }
        public IProfile Profile { get; set; }
        private readonly IList<MbCard> _creditCards;
        private readonly IList<IPurchase> _purchases;

        private readonly IList<IService> _reservations;
        
        public string Password { private get; set; }
        public bool IsAdmin { get; set; }

        public string Email { get; set; }

        public User()
        {
            Id = _uId++;
            _creditCards = new List<MbCard>();
            _purchases = new List<IPurchase>();
            _reservations = new List<IService>();
        }

        public IList<IPurchase> Purchases
        {
            get { return  _purchases; }
        }

        public IList<IService> Reservations
        {
            get { return _reservations; }
        }


        public string Username { get; set; }


        public bool Authenticate(string aUsername, string aPassword)
        {
            return this.Username == aUsername && this.Password == aPassword;
        }
    }
}
