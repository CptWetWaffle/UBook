using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBook.Data;
using UBook.Interfaces;

namespace UBook.Structure
{
    public class PlainLogin:ILogin
    {
        #region Singleton
        private static PlainLogin instance = new PlainLogin();

        private PlainLogin()
        {
        }

        public static PlainLogin GetInstance()
        {
            return instance;
        }
        #endregion


        public bool Authenticate(string aUsername, string aPassword)
        {
            foreach (var user in DataHolder.GetInstance().Users)
            {
                if ( user.Authenticate( aUsername, aPassword ) ) return true;
            }
            return false;
        }
    }
}
