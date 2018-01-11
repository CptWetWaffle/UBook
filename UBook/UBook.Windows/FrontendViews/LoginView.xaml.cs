// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using UBook.Creation;
using UBook.Data;
using UBook.Structure;

namespace UBook.FrontendViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Index : Page
    {
        public Index()
        {
            this.InitializeComponent();
            var admin = Factory.GetInstance().MakeUser();
            admin.Username = "admin";
            admin.Password = "adminpass";
            admin.Email = "admin@admin.com";
            admin.IsAdmin = true;
            DataHolder.GetInstance().Users.Add(admin);
            var user = Factory.GetInstance().MakeUser();
            user.Username = "user";
            user.Password = "user";
            user.Email = "user@admin.com";
            user.IsAdmin = false;
            DataHolder.GetInstance().Users.Add(user);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void Login()
        {
            if(PlainLogin.GetInstance().Authenticate(txtUser.Text, txtPass.Password))
                this.Frame.Navigate(typeof(HotelView), txtUser.Text);
            else
            {
                var m = new MessageDialog("The Username/Password was incorrect!","Error!");
                m.ShowAsync();
            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegisterView));
            
        }

        private void txtPass_KeyDown(object sender, KeyRoutedEventArgs e)
        {
           
        }

    }
}
