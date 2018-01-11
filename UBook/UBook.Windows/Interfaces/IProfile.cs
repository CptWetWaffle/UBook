using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBook.Interfaces
{
    public interface IProfile
    {
        IUser User { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        DateTime DateOfBirth { get; set; }

        long PhoneNumber { get; set; }
    }
}
