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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace windowsWishlistAppGroepVM9
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class Registreer : Page
  {
        private App app;
        public Registreer()
    {
            app = (App)Application.Current;
            this.InitializeComponent();
            message.Visibility = Visibility.Collapsed;
    }

    private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
    {

    }

    private async void Registreerbtn_OnClick(object sender, RoutedEventArgs e)
    {
           
            if(username.Text.Equals("")|| voornaam.Text.Equals("") || familienaam.Text.Equals("")|| wachtwoord1.Text.Equals(""))
            {
                message.Text = "Alle velden moeten worden ingevuld";
                message.Visibility = Visibility.Visible;
            }
            if (wachtwoord1.Text.Equals(wachtwoord2.Text))
            {
                Gebruiker gbr = new Gebruiker(username.Text, wachtwoord1.Text, voornaam.Text, familienaam.Text);
                await app.repository.Registreer(gbr);
                this.Frame.Navigate(typeof(Homepage));

            }
            else
            {
                message.Text = "Wachtwoorden moeten overeenkomen";
                message.Visibility = Visibility.Visible;

            }
        }
    }
}
