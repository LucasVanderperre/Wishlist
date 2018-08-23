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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace windowsWishlistAppGroepVM9
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
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
            await app.repository.Login(new Models.Gebruiker(username.Text, wachtwoord.Text));
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
