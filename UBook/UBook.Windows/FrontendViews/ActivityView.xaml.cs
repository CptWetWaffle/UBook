// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using System;
using System.Linq;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using ServicePrototype;
using UBook.Data;
using UBook.Interfaces;
using UBook.Structure;

namespace UBook.FrontendViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ActivityView : Page, IObserver
    {
        private IUser _user;
        private DataHolder data = DataHolder.GetInstance();
        public ActivityView()
        {
            this.InitializeComponent();
            if (gvSearch.Items != null) gvSearch.Items.Clear();
            foreach (var service in data.Services.Where(s => s.Type.Name.ToLower() == "activity"))
            {
                var g = new GridViewItem
                {
                    Name = "" + service.Id,
                    Content = service.ToString(),
                    Width = 300,
                    Height = 150
                };
                if (gvSearch.Items != null) gvSearch.Items.Add(g);
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var user = e.Parameter as string;
            this._user = DataHolder.GetInstance().Users.FirstOrDefault(u => u.Username == user);
            if (this._user.IsAdmin)
            {
                btnAdd.Visibility = Visibility.Visible;
                btnRem.Visibility = Visibility.Visible;
                gvSearch.Visibility = Visibility.Visible;
                btnShoppingCart.Visibility = Visibility.Collapsed;
                reservationBtn.Content = "Reservations";
            }
            else
            {
                btnShoppingCart.Visibility = Visibility.Visible;
                this._user.ShoppingCart.Subscribe(this);
            }

            if (this._user.ShoppingCart.Num != 0)
                btnShoppingCart.Label = "Shopping Cart(" + this._user.ShoppingCart.Num + ")";
            else
            {

                btnShoppingCart.Label = "Shopping Cart";
            }
        }
        private void AppBarToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            if(this._user.ShoppingCart != null)
                this._user.ShoppingCart.Unsubscribe(this);
            this.Frame.Navigate(typeof(Index));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (gvSearch.Items != null) gvSearch.Items.Clear();
            gvSearch.Visibility = Visibility.Visible;
            btnAddToCart.Visibility = Visibility.Visible;
            lblSR.Visibility = Visibility.Visible;
            foreach (var h in data.Services.Where(h => h.Type.Name.ToLower() == "activity"))
            {
                if (!h.ServiceValues.Any(namai => namai.Value.Contains(txtAct.Text))) continue;
                var g = new GridViewItem
                {
                    Name = "" + h.Id,
                    Content = h.ToString(),
                    Width = 300,
                    Height = 150
                };
                if (gvSearch.Items != null) gvSearch.Items.Add(g);
            }
        }

        private void helpBtn_Click(object sender, RoutedEventArgs e)
        {
            Leave<HelpView>();
        }

        private void reservationBtn_Click(object sender, RoutedEventArgs e)
        {
            Leave<ReservationView>();
        }

        private void activityBtn_Click(object sender, RoutedEventArgs e)
        {
            Leave<ActivityView>();
        }

        private void transportBtn_Click(object sender, RoutedEventArgs e)
        {
            Leave<TransportView>();
        }

        private void restaurantBtn_Click(object sender, RoutedEventArgs e)
        {
            Leave<RestaurantView>();
        }

        private void hotelBtn_Click(object sender, RoutedEventArgs e)
        {
            Leave<HotelView>();
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            Leave<BackendViews.NewService>();
        }

        private void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            Leave<ShoppingCartView>();
        }

        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            if (gvSearch.SelectedItem == null) return;
            var l = DataHolder.GetInstance().Services;
            var c = gvSearch.SelectedItem as GridViewItem;
            var cb = cbPeople.SelectedItem as ComboBoxItem;
            var qt = "1";
            var mem = _user.ShoppingCart.Parameters;
            if (cb != null) if (cb.Content != null) qt = cb.Content.ToString();
            foreach (var service in data.Services.Where(service => c != null && Convert.ToInt32(c.Name) == service.Id))
            {
                var s = new Service();
                s.Clone(service);

                s.AddValues("date", dpDate.Date.ToString());
                s.AddValues("initialtime", tpTime.Time.ToString());
                foreach (var value in s.ServiceValues.Where(value => value.Property.Name == "quantity"))
                {
                    value.Value = qt;
                }
                mem = new Memento(mem);
                mem.Add("date", dpDate.Date.ToString());
                mem.Add("initialtime", tpTime.Time.ToString());
                mem.Add("quantity", qt);
                mem.ServiceId = s.Id;
                _user.ShoppingCart.AddToCart(s);
            }
            _user.ShoppingCart.Parameters = mem;

            btnShoppingCart.Label = "Shopping Cart(" + _user.ShoppingCart.Num + ")";
        }

        private void AppBarButton_Click_3(object sender, RoutedEventArgs e)
        {
            if (gvSearch.SelectedItem == null) return;
            var l = DataHolder.GetInstance().Services;
            var c = (GridViewItem)gvSearch.SelectedItem;
            if (c == null)
                return;
            try
            {
                foreach (var service in data.Services.Where(service => service.Id == Convert.ToInt32(c.Name)))
                {
                    DataHolder.GetInstance().Services.Remove(service);
                    if (gvSearch.Items != null) gvSearch.Items.Remove(c);
                    break;
                }


                var m = new MessageDialog("Successfully removed an activity!", "Success!");
                m.ShowAsync();
            }
            catch (Exception)
            {
                var m = new MessageDialog("There was an error trying to remove that activity", "Error!");
                m.ShowAsync();
            }
            
           

            
        }


        public void Update()
        {
            btnShoppingCart.Label = "Shopping Cart(" + _user.ShoppingCart.Num + ")";
        }

        private void Leave<T>()
        {
            if (_user.ShoppingCart != null)
                _user.ShoppingCart.Unsubscribe(this);
            this.Frame.Navigate(typeof(T), _user.Username);
        }
    }
}
