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

namespace windowsWishlistAppGroepVM9
{
    public sealed partial class Homepage : Page
    {
        private App app;
        ObservableCollection<Wishlist> eigenlist = new ObservableCollection<Wishlist>();
        ObservableCollection<Wishlist> volgenlist = new ObservableCollection<Wishlist>();
        ObservableCollection<Wishlist> aanvragenlist = new ObservableCollection<Wishlist>();
        public Homepage()
        {
            this.InitializeComponent();
            app = (App)Application.Current;
            titel.Text = "Welkom " + app.repository.gebruikerViewModel.Gebruiker.voornaam + " " +
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
            app.repository.wishlistViewmodel.wishlist = (Wishlist)e.ClickedItem;
            this.Frame.Navigate(typeof(Wishlists));
        }

        private void ListItemAndere_Clicked(object sender, ItemClickEventArgs e)
        {
            app.repository.wishlistViewmodel.wishlist = (Wishlist)e.ClickedItem;
            this.Frame.Navigate(typeof(WishlistKopen));
        }

        private void AddWishlistbtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddWishlist));
        }

        private async void Button_weiger(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Wishlist wishlist = (Wishlist)btn.DataContext;
            await app.repository.weigerUitnodiging(wishlist);
            aanvragenlist.Remove(wishlist);
        }
        private async void Button_accept(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Wishlist wishlist = (Wishlist)btn.DataContext;
            await app.repository.accepteerUitnodiging(wishlist);
            aanvragenlist.Remove(wishlist);
            volgenlist.Add(wishlist);
        }

        public void Button_loguit(object sender, RoutedEventArgs e)
        {
            app.repository.gebruikerViewModel = new LoginViewModel();
            this.Frame.Navigate(typeof(Login));
        }
    }
}
