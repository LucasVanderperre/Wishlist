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
using windowsWishlistAppGroepVM9.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace windowsWishlistAppGroepVM9
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Homepage : Page
    {
        private App app;
        ObservableCollection<Wishlist> eigenlist = new ObservableCollection<Wishlist>();
        ObservableCollection<Wishlist> volgenlist = new ObservableCollection<Wishlist>();
        ObservableCollection<Wishlist> aanvragenlist = new ObservableCollection<Wishlist>();
        Homepage content;
        public Homepage()
        {
            this.InitializeComponent();
            app = (App)Application.Current;
            titel.Text = "Welkom " + app.repository.gebruikerViewModel.Gebruiker.voornaam + " "+
                app.repository.gebruikerViewModel.Gebruiker.familienaam;

        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            ophalen();
        }
        private async void ophalen()
        {
            await app.repository.getWishlists();
            foreach (Wishlist wl in app.repository.homescreenLists.eigenWishlists)
            {
                eigenlist.Add(wl);
            }
            foreach (Wishlist wl in app.repository.homescreenLists.volgendeWishlists)
            {
                volgenlist.Add(wl);
            }
            foreach (Wishlist wl in app.repository.homescreenLists.aangevraagdeWishlists)
            {
                aanvragenlist.Add(wl);
            }
            eigen.ItemsSource = eigenlist;
            volgen.ItemsSource = volgenlist;
            aanvragen.ItemsSource = aanvragenlist;
        }
        private void ListItem_Clicked(object sender, ItemClickEventArgs e)
        {
            
            WishlistViewModel vm = new WishlistViewModel();
            vm.wishlist = (Wishlist)e.ClickedItem;
            content = this;
           var view = new Wishlists(vm);
           this.Content = view;
          //  this.Frame.Navigate(typeof(Wishlists), vm);

        }

        private void AddWishlistbtn_OnClick(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(AddWishlist));
            this.Content = new AddWishlist();
        }

        private async void Button_weiger(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Wishlist wishlist = (Wishlist) btn.DataContext;
          //  Wishlist wishlist = (Wishlist)e.ClickedItem;
           await app.repository.weigerUitnodiging(wishlist);
            aanvragenlist.Remove(wishlist);

           
        }
        private async void Button_accept(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Wishlist wishlist = (Wishlist)btn.DataContext;
            //    Wishlist wishlist = (Wishlist)e.ClickedItem;
            //   await app.repository.weigerUitnodiging(wishlist);
            //  aanvragenlist.Remove(wishlist);
            await app.repository.accepteerUitnodiging(wishlist);
            aanvragenlist.Remove(wishlist);
            volgenlist.Add(wishlist);


        }

        public void SluitWishlist()
        {
            Homepage hp = new Homepage();
            hp.ophalen();
            this.Content = hp;
        }
    }
}
