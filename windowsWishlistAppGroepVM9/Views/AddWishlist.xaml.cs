using System;
using System.Collections.Generic;
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

namespace windowsWishlistAppGroepVM9
{

    public sealed partial class AddWishlist : Page
    {
        private App app;
        public AddWishlist()
        {
            this.InitializeComponent();
            app = (App)Application.Current;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (naam.Text.Equals(""))
            {
                //  message.Text = "Naam moet ingevuld worden";
                // message.Visibility = Visibility.Visible;
            }
            else
            {
                Wishlist newWishlist = new Wishlist(naam.Text, datum.Date.DateTime);
                await app.repository.CreateWishlist(newWishlist);
                this.Frame.Navigate(typeof(Homepage));
            }
        }


        private void Button_Close(object sender, RoutedEventArgs e)
        {
            // Homepage homepage = (Homepage)this.Parent;
            // homepage.SluitWishlist();
            this.Frame.Navigate(typeof(Homepage));
        }
    }
}
