// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using System;
using System.Linq;
using Windows.UI.Popups;
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
    public sealed partial class ShoppingCartView : Page
    {
        private IUser _user;
        public ShoppingCartView()
        {
            this.InitializeComponent();
            if (lvCart.Items != null) lvCart.Items.Clear();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                var user = e.Parameter as string;
                this._user = DataHolder.GetInstance().Users.FirstOrDefault(u => u.Username == user);
                var price = 0.0;
                foreach (var products in this._user.ShoppingCart.Items)
                {
                    var l = new ListViewItem
                    {
                        Name = price.ToString() + products.Id,
                        Content = products.LineToString()
                    };
                    if (lvCart.Items != null) lvCart.Items.Add(l);
                    
                    price += Convert.ToInt32(
                            products.ServiceValues.FirstOrDefault(u => u.Property.Name.Contains("price")).Value);

                        
                }
                lbPrice.Text = price.ToString()+"€";

                if (this._user.ShoppingCart.Num != 0)
                    btnShoppingCart.Label = "Shopping Cart(" + this._user.ShoppingCart.Num + ")";
                else
                    btnShoppingCart.Label = "Shopping Cart";
            }
            catch (Exception exception)
            {
                var m = new MessageDialog(exception.Message);
                m.ShowAsync();
            }
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void transportsBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TransportView), _user.Username);
        }

        private void activityBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ActivityView), _user.Username);
        }

        private void reservationBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ReservationView), _user.Username);
        }

        private void helpBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HelpView), _user.Username);
        }

        private void AppBarToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Index));
        }

        private void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            if (this._user.ShoppingCart.Num != 0)
                btnShoppingCart.Label = "Shopping Cart(" + this._user.ShoppingCart.Num + ")";
            else
            {

                btnShoppingCart.Label = "Shopping Cart";
            }
        }

        private void Purchase_Click(object sender, RoutedEventArgs e)
        {
            _user.ShoppingCart.Purchase();
            if (lvCart.Items != null) lvCart.Items.Clear();
            lbPrice.Text = "";
            btnShoppingCart.Label = "Shopping Cart";
        }

        private void HyperlinkButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HotelView), _user.Username);
        }
    }
}
