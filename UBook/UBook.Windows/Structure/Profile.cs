using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using UBook.Interfaces;

namespace UBook.Structure
{
    public class Profile : IProfile
    {
        public IUser User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long PhoneNumber { get; set; }

        public Profile()
        {
            
        }


    }
}
