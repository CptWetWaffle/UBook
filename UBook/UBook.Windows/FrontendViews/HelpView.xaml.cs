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
    public sealed partial class HelpView : Page
    {
        private IUser _user;
        public HelpView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var user = e.Parameter as string;
            this._user = DataHolder.GetInstance().Users.FirstOrDefault(u => u.Username == user);

            if (this._user.IsAdmin){
                btnShoppingCart.Visibility = Visibility.Collapsed;
                reservationBtn.Content = "Reservations";
            }

            if (this._user.ShoppingCart.Num != 0)
                btnShoppingCart.Label = "Shopping Cart(" + this._user.ShoppingCart.Num + ")";
            else
                btnShoppingCart.Label = "Shopping Cart";
        }

        private void AppBarToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Index));
        }

        private void hotelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HotelView), _user.Username);
        }

        private void restaurantBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RestaurantView), _user.Username);
        }

        private void transportsBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TransportView),_user.Username);
        }

        private void activityBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ActivityView), _user.Username);
        }

        private void reservationBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ReservationView), _user.Username);
        }

        private void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {

        }


    }
}
