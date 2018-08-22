using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using windowsWishlistAppGroepVM9.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace windowsWishlistAppGroepVM9
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Homepage : Page
    {
        private App app;

        public Homepage()
        {
            this.InitializeComponent();
            app = (App)Application.Current;
            titel.Text = "Welkom " + app.repository.gebruikerViewModel.Gebruiker.voornaam + " "+
                app.repository.gebruikerViewModel.Gebruiker.familienaam;

        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:57703/api/wishlist"));
            var lst = JsonConvert.DeserializeObject<List<Wishlist>>(json);
            wishlists.ItemsSource = app.repository.gebruikerViewModel.Gebruiker.EigenWishlists;
            wishlists2.ItemsSource = lst;
            wishlists1.ItemsSource = lst;
        }

        private void AddWishlistbtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddWishlist));
        }
    }
}
