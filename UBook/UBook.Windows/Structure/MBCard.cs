using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;
using Windows.Security.Authentication.OnlineId;

namespace UBook.Structure
{
    public class MbCard
    {
        public User user;
        public long cardNumber { get; set; }
        public string cardHolder { get; set; }

        public int ccv { get; set; }

        public DateTime expDate;
        public MbCard(User user, string cardHolder, long cardNumber, int ccv, DateTime expDate)
        {
            this.user = user;
            this.cardNumber = cardNumber;
            this.cardHolder = cardHolder;
            this.expDate = expDate;
            this.ccv = ccv;
        }
    }
}
