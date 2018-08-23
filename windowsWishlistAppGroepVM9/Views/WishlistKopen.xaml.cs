using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using windowsWishlistAppGroepVM9.Models;
using windowsWishlistAppGroepVM9.ViewModels;

namespace windowsWishlistAppGroepVM9
{
    public sealed partial class WishlistKopen : Page
    {
        private WishlistViewModel wishlist;
        private App app;
        ObservableCollection<Item> itms = new ObservableCollection<Item>();


        public WishlistKopen()
        {
            this.InitializeComponent();
            this.wishlist = new WishlistViewModel();
            app = (App)Application.Current;
          

           
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //HttpClient client = new HttpClient();
            //var json = await client.GetStringAsync(new Uri("http://localhost:14547/api/movies"));
            //var lst = JsonConvert.DeserializeObject<ObservableCollection<Movie>>(json);
            this.wishlist = app.repository.wishlistViewmodel;
            foreach (Item item in wishlist.wishlist.Items)
            {
                itms.Add(item);
            }
            items.ItemsSource = itms;
            titelView.Text = "Wishlist:  " + app.repository.wishlistViewmodel.wishlist.Naam;
        }
        private async void Button_koop(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Item koop = (Item)btn.DataContext;
            itms.Remove(koop);
            await app.repository.koopItem(koop, wishlist.wishlist);
            koop.gebruiker = app.repository.gebruikerViewModel.Gebruiker.username;
            itms.Add(koop);

            //    Wishlist wishlist = (Wishlist)e.ClickedItem;
            //   await app.repository.weigerUitnodiging(wishlist);
            //  aanvragenlist.Remove(wishlist);
            // aanvragenlist.Remove(wishlist);
            //volgenlist.Add(wishlist);


        }


        private void Button_terug(object sender, RoutedEventArgs e)
        {
            //Homepage homepage = (Homepage)this.Parent;
            //homepage.SluitWishlist();
            this.Frame.Navigate(typeof(Homepage));
        }

    }
}
