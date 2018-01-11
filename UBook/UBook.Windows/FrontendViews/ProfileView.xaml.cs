// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using UBook.Data;
using UBook.Interfaces;

namespace UBook.FrontendViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProfileView : Page
    {
        private IUser user;
        public ProfileView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var user = e.Parameter as string;
            this.user = DataHolder.GetInstance().Users.FirstOrDefault(u => u.Username == user);

        }
    }
}
