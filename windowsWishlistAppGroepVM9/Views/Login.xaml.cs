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

namespace windowsWishlistAppGroepVM9
{
    public sealed partial class Login : Page
    {
        private App app;

        public Login()
        {
            this.InitializeComponent();
            app = (App)Application.Current;
            message.Visibility = Visibility.Collapsed;
        }

        private async void Loginbtn_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
            await app.repository.Login(new Models.Gebruiker(username.Text, wachtwoord.Password));
                this.Frame.Navigate(typeof(Homepage));
            }
            catch(Exception ex)
            {
                message.Visibility = Visibility.Visible;
            }
        }

        private void Registreerbtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Registreer));
        }
    }
}
