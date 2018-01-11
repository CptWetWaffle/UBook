using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using ServicePrototype;
using UBook.Creation;
using UBook.Data;
using UBook.Interfaces;

namespace UBook.Structure
{

    public class ShoppingCart : IShoppingCart
    {
        private readonly IList<IService> _preReses;
        private readonly IList<IObserver> _observers;
        public IList<IService> Items { get { return _preReses; } }
        public IUser User { private get; set; }
        public int Num { get; private set; }
        public IMemento Parameters { get; set; }

        public ShoppingCart()
        {
            Parameters = new Memento();
            _preReses = new List<IService>();
            _observers = new List<IObserver>();
            Num = 0;
        }

        public void AddToCart(IService service)
        {
            _preReses.Add(service);
            Num++;
            Notify();
        }

        public void Purchase()
        {
            foreach (var pre in _preReses)
            {
                var s = pre;
                if (!ReservationManager.GetInstance().Avaliability(pre, Parameters))
                {
                    var m = new MessageDialog("Ja n dá");
                    m.ShowAsync();
                    continue;
                }

                var p = Factory.GetInstance().MakePurchase();
                p.Service = s;
                p.User = User;
                DataHolder.GetInstance().Purchases.Add(p);
                DataHolder.GetInstance().Reservations.Add(s);
                User.Purchases.Add(p);
                User.Reservations.Add(s);
                
            }
            _preReses.Clear();
            Num = 0;
        }

        public void Notify()
        {
            foreach (var a in _observers)
                a.Update();
        }

        public void Subscribe(IObserver obs)
        {
            _observers.Add(obs);
        }

        public void Unsubscribe(IObserver obs)
        {
            _observers.Remove(obs);
        }

        
    }
}
