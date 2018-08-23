using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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

    public sealed partial class Wishlists : Page
    {
        private WishlistViewModel wishlist;
        private App app;
        ObservableCollection<Item> itms = new ObservableCollection<Item>();
        ObservableCollection<string> vlgrs = new ObservableCollection<string>();

        public Wishlists()
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
            messageItem.Visibility = Visibility.Collapsed;
            message.Visibility = Visibility.Collapsed;

            foreach (Item item in wishlist.wishlist.Items)
            {
                itms.Add(item);
            }
            items.ItemsSource = itms;
            foreach (string aanvr in wishlist.wishlist.Volgers)
            {
                vlgrs.Add(aanvr);
            }
            volgers.ItemsSource = vlgrs;
            titelView.Text = "Wishlist:  " + app.repository.wishlistViewmodel.wishlist.Naam;
        }

        private async void Button_item(object sender, RoutedEventArgs e)
        {
            if (titel.Text.Equals("") || beschrijving.Text.Equals(""))
            {
                //  message.Text = "Naam moet ingevuld worden";
                messageItem.Visibility = Visibility.Visible;
            }
            else
            {
                CategorieEnum cat = CategorieEnum.Sport;
                switch (categorie.SelectedItem.ToString())
                {
                    case "Boek":
                        cat = CategorieEnum.Boek;
                        break;
                    case "Muziek en film":
                        cat = CategorieEnum.Muziek_Film;
                        break;
                    case "Keuken":
                        cat = CategorieEnum.Keuken;
                        break;
                    case "Sport":
                        cat = CategorieEnum.Sport;
                        break;
                    default:
                        Console.WriteLine("Categorie probleem");
                        break;
                }
                Item item = new Item(titel.Text, beschrijving.Text, cat);
                wishlist.wishlist.addItem(item);
                await app.repository.UpdateWishlist(wishlist.wishlist);
                itms.Add(item);
            }
        }

        private async void Button_volger(object sender, RoutedEventArgs e)
        {
            if (username.Text.Equals(""))
            {
                message.Text = "Gebruikersnaam moet ingevuld worden";
                message.Visibility = Visibility.Visible;
            }
            else
            {
                try
                {
                    await app.repository.CheckUsername(username.Text, wishlist.wishlist.name);
                }catch(Exception ex)
                {
                    message.Text = "Gebruiker niet gevonden";
                    message.Visibility = Visibility.Visible;
                }
                if (app.repository.results)
                {
                    if (wishlist.wishlist.Volgers.Contains(username.Text))
                    {
                        message.Text = "Gebruiker is al toegevoegd";
                        message.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        wishlist.wishlist.Volgers.Add(username.Text);
                        await app.repository.UpdateWishlist(wishlist.wishlist);
                        vlgrs.Add(username.Text);
                    }
                  
                }



            }
        }
        private void Button_terug(object sender, RoutedEventArgs e)
        {
            // Homepage homepage = (Homepage) this.Parent;
            // homepage.SluitWishlist();
            app.repository.wishlistViewmodel = new WishlistViewModel();
            this.Frame.Navigate(typeof(Homepage));
        }
    }
}
