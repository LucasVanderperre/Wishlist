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
        ObservableCollection<CustomItem> itms = new ObservableCollection<CustomItem>();

        public WishlistKopen()
        {
            this.InitializeComponent();
            this.wishlist = new WishlistViewModel();
            app = (App)Application.Current;       
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.wishlist = app.repository.wishlistViewmodel;
            foreach (Item item in wishlist.wishlist.Items)
            {
                itms.Add(new CustomItem(item));
            }
            items.ItemsSource = itms;
            titelView.Text = "Wishlist:  " + app.repository.wishlistViewmodel.wishlist.Naam;
        }
        private async void Button_koop(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            CustomItem koop = (CustomItem)btn.DataContext;
            itms.Remove(koop);
            await app.repository.koopItem(koop.Item, wishlist.wishlist);
            koop.Item.Gebruiker = app.repository.gebruikerViewModel.Gebruiker.username;
            koop.isGekocht = "Collapsed";
            itms.Add(koop);
        }

        private void Button_terug(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Homepage));
        }

    }

    public class CustomItem
    {
        public string isGekocht { get; set; }
        public Item Item { get; set; }

        public CustomItem(Item item)
        {
            Item = item;
            if (item.Gebruiker != null)
                isGekocht = "Collapsed";
            else
                isGekocht = "Visible";
        }
    }
}
