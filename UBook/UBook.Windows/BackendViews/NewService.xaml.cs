using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UBook.Behavior;
using UBook.Creation;
using UBook.Data;
using UBook.FrontendViews;
using UBook.Interfaces;
using UBook.Structure;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UBook.BackendViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewService : Page
    {
        private IUser _user;
        private int Punctual=0, Duration=0, TimeOFF=0;
        public NewService()
        {
            this.InitializeComponent();
            Clear();
            AddSuperType("Accomodation");
            CreateGrid("Name");
            CreateGrid("Location");
            CreateGrid("Price");
            CreateGrid("Description");
            CreateGrid("Quantity");
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var user = e.Parameter as string;
            this._user = DataHolder.GetInstance().Users.FirstOrDefault(u => u.Username == user);
        }

        private void reservationBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (ReservationView), _user.Username);
        }

        private void helpBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (FrontendViews.HelpView), _user.Username);
        }

        private void activityBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (FrontendViews.ActivityView), _user.Username);
        }

        private void transportsBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (FrontendViews.TransportView), _user.Username);
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (FrontendViews.RestaurantView), _user.Username);
        }

        private void HyperlinkButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (FrontendViews.HotelView), _user.Username);
        }

        private void AppBarToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (FrontendViews.Index));
        }

        private void lviAccomodation_Tapped(object sender, TappedRoutedEventArgs e)
        {
          
            Clear();
            AddSuperType("Accomodation");
            CreateGrid("Name");
            CreateGrid("Location");
            CreateGrid("Price");
            CreateGrid("Description");
            CreateGrid("Quantity");
        }

        private void lviTransportion_Tapped(object sender, TappedRoutedEventArgs e)
        {
            
            Clear();
            AddSuperType("Transportation");
            CreateGrid("Name");
            CreateGrid("Location");
            CreateGrid("Price");
            CreateGrid("Description");
            CreateGrid("Quantity");
        }

        private void lviRestaurant_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Clear();
            AddSuperType("Restaurant");      
            CreateGrid("Name");
            CreateGrid("Location");
            CreateGrid("Price");
            CreateGrid("Description");
            CreateGrid("Quantity");
        }
        private void lviDuration_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (Duration != 0) return;
            AddType("Duration");
            RemoveLV("Punctual");
            Duration = 1;
            Punctual = 0;
            RemovePunctual();
        }

        private void lviPunctual_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (Punctual != 0) return;
            RemoveLV("Duration");
            AddType("Punctual");
            Punctual = 1;
            Duration = 0;
            CreateGrid("InitialTime");
            CreateGrid("EndTime");
        }
        private void lviTimeOFF_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TimeOFF++;
            AddType("TimeOFF");
            CreateGrid("InitialOFF");
            CreateGrid("EndOFF");
        }

       private void lviActivity_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Clear();
            AddSuperType("Activity");
            CreateGrid("Name");
            CreateGrid("Location");
            CreateGrid("Price");
            CreateGrid("Description");
            CreateGrid("Quantity");
        }

     

        private void lviActivity_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Clear();
        }

        private void lviAccomodation_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Clear();
        }

        private void lviRestaurant_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Clear();
        }

        private void lviTransportion_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Clear();
        }

        private void lviPunctual_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
           Punctual = 0;
           RemovePunctual();
           RemoveLV("Punctual");
        }

        private void RemovePunctual()
        {
            if (gvProperties.Items == null) return;
            for (int b = 0; b < gvProperties.Items.Count + 1; b++)
                for (int i = 0; i < gvProperties.Items.Count + 1; i++)
                    for (int j = 0; j < gvProperties.Items.Count; j++)
                    {
                        var aux = gvProperties.Items[j] as TextBox;
                        if (aux != null && aux.Name == "txtInitialTime")
                            gvProperties.Items.Remove(aux);
                        else if (aux != null && aux.Name == "txtEndTime")
                            gvProperties.Items.Remove(aux);
                    }
        }

        private void lviTimeOFF_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            TimeOFF = 0;
            RemoveLV("TimeOFF");
            if (gvProperties.Items == null) return;
            for (int b = 0; b < gvProperties.Items.Count + 1; b++)
                for (int i = 0; i < gvProperties.Items.Count + 1; i++)
                    for (int j = 0; j < gvProperties.Items.Count; j++)
                    {
                        var aux = gvProperties.Items[j] as TextBox;
                        if (aux != null && aux.Name == "txtInitialOFF")
                            gvProperties.Items.Remove(aux);
                        else if (aux != null && aux.Name == "txtEndOFF")
                            gvProperties.Items.Remove(aux);
                    }
        }

       

        private void RemoveLV(string type)
        {
            if (lvMap.Items == null) return;
            for (int b = 0; b < lvMap.Items.Count + 1; b++)
                for (int i = 0; i < lvMap.Items.Count + 1; i++)
                    for (int j = 0; j < lvMap.Items.Count; j++)
                    {
                        var aux = lvMap.Items[j] as TextBlock;
                        if (aux != null && aux.Name == type)
                            lvMap.Items.Remove(aux);

                    }
        }



        private void Clear()
        {
            if (gvProperties.Items != null)
                gvProperties.Items.Clear();
            if (lvMap.Items != null) 
                lvMap.Items.Clear();
            lviDuration.IsSelected = false;
            lviPunctual.IsSelected = false;
            lviTimeOFF.IsSelected = false;
        }

        private void AddType(string type)
        {
         var txt = new TextBlock {Name = type,Height = 25,Width = 200,Text = "\t"+type};
            if (lvMap.Items != null) lvMap.Items.Add(txt);
        }

        private void AddSuperType(string type)
        {
            var txt = new TextBlock {Height = 50,Width = 200, Padding = new Thickness(10), Text = type };
            if (lvMap.Items != null) lvMap.Items.Add(txt);
        }
        private void CreateGrid(string name)
        {
            var txt = new TextBox { Name = "txt" + name, Width = 500, PlaceholderText = name, Padding = new Thickness(10), Margin = new Thickness(10) };
            if (gvProperties.Items != null) gvProperties.Items.Add(txt);
        }

        private void lviDuration_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Duration = 0;
            RemoveLV("Duration");
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var s = Factory.GetInstance().MakeService();
            var gvi = gvType.SelectedItem as ListViewItem;
            if (gvi != null)
                if (gvi.Content != null)
                    switch (gvi.Content.ToString())
                    {
                        case "Accomodation":
                            s.Type = new HotelServiceType();
                            break;
                        case "Transportation":
                            s.Type = new TransportServiceType();
                            break;
                        case "Restaurant":
                            s.Type = new RestaurantServiceTypecs();
                            break;
                        case "Activity":
                            s.Type = new ActivityServiceType();
                            break;
                        default:
                            s.Type = new HotelServiceType();
                            break;
                    }
            
            for (var i = 0; i < 5; i++)
            {
                if (gvProperties.Items == null) continue;
                var item = gvProperties.Items[i] as TextBox;
                if (item != null) s.AddValues(item.Name.Substring(3).ToLower(), item.Text);
            }
            if (gvProperties.Items != null)
                foreach (var v in gvProperties.Items)
                {
                    var vaux = v as TextBox;
                    if(vaux != null && !vaux.Name.Contains("InitialTime")) continue;
                    s.Type = new TimeDurationDecorator(s.Type);
                    if (vaux != null) s.AddValues("initialtime", vaux.Text);
                    var va = gvProperties.Items[gvProperties.Items.IndexOf(v) + 1] as TextBox;
                    if (va != null) s.AddValues("endtime", va.Text);
                }
            if (gvProperties.Items != null)
                foreach (var v in gvProperties.Items)
                {
                    var vaux = v as TextBox;
                    if (vaux != null && !vaux.Name.Contains("InitialOFF")) continue;
                    s.Type = new TimeOffDecorator(s.Type);
                    if (vaux != null) s.AddValues("initialtimeoff", vaux.Text);
                    var va = gvProperties.Items[gvProperties.Items.IndexOf(v) + 1] as TextBox;
                    if (va != null) s.AddValues("endtimeoff", va.Text);
                }
            for (var i = 0; i < Duration; i++ )
            {
                s.Type=new DurationDecorator(s.Type);
            }
            DataHolder.GetInstance().Services.Add(s);
            var m = new MessageDialog(s.ToString());
            m.ShowAsync();
        }
    }
}
