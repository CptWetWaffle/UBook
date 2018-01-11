// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using UBook.Data;
using UBook.Interfaces;

namespace UBook.FrontendViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReservationView : Page
    {
        private IUser _user;
        public ReservationView()
        {
            this.InitializeComponent();
          
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (lvRes.Items != null) lvRes.Items.Clear();
            var user = e.Parameter as string;
            this._user = DataHolder.GetInstance().Users.FirstOrDefault(u=>u.Username == user);

            if (this._user.IsAdmin)
            {
                btnShoppingCart.Visibility = Visibility.Collapsed;
                reservationsBtn.Content = "Reservations";
                foreach (var res in DataHolder.GetInstance().Reservations)
                {
                    var l = new ListViewItem
                    {
                        Content = res.ToString()
                    };
                    if (lvRes.Items != null) lvRes.Items.Add(l);
                }
            }
            else
            {
                foreach (var res in _user.Reservations)
                {
                    var l = new ListViewItem
                    {
                        Content = res.LineToString()
                    };
                    if (lvRes.Items != null) lvRes.Items.Add(l);
                }
                
               }

                if (this._user.ShoppingCart.Num != 0)
                    btnShoppingCart.Label = "Shopping Cart(" + this._user.ShoppingCart.Num + ")";
                else
                {

                    btnShoppingCart.Label = "Shopping Cart";
                }
            }

            private
            void AppBarToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Index));
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void hotelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HotelView), _user.Username);
        }

        private void restaurantBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RestaurantView), _user.Username);
        }

        private void transportBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TransportView), _user.Username);
        }

        private void activityBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ActivityView), _user.Username);
        }

        private void reservationsBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ReservationView),_user.Username);
        }

        private void helpBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HelpView), _user.Username);
        }

        private void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ShoppingCartView), _user.Username);
        }
    }
}
