// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using System;
using System.Linq;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using UBook.Creation;
using UBook.Data;

namespace UBook.FrontendViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterView : Page
    {
        public RegisterView()
        {
            this.InitializeComponent();

        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog m;
            try
            {
                if (DataHolder.GetInstance().Users.FirstOrDefault(u => u.Email == txtEmail.Text) == null)
                    if (DataHolder.GetInstance().Users.FirstOrDefault(u => u.Username == txtUser.Text) == null)
                    {
                        var user = Factory.GetInstance().MakeUser();
                        user.Username = txtUser.Text;
                        user.Password = txtPass.Password;
                        user.Email = txtEmail.Text;
                        user.Profile.FirstName = txtFName.Text;
                        user.Profile.LastName = txtLName.Text;
                        user.Profile.PhoneNumber = long.Parse(txtPhone.Text);
                        user.Profile.DateOfBirth = dtDOB.Date.DateTime;
                        DataHolder.GetInstance().Users.Add(user);
                        m = new MessageDialog("Your account was successfully created!", "Success!");
                        m.ShowAsync();
                        this.Frame.Navigate(typeof(HotelView), user.Username);
                    }
                    else
                    {
                        m = new MessageDialog("That username already exists!", "Error!");
                        m.ShowAsync();
                    }
                else
                {
                    m = new MessageDialog("That email already has an account added to it!", "Error!");
                    m.ShowAsync();
                }
            }
            catch (Exception)
            {
                m = new MessageDialog("That user can not be created.", "Error!");
                m.ShowAsync();
            }
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Index));
        }
    }
}
