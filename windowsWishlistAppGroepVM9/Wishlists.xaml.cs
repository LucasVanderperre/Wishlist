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
  public sealed partial class Wishlists : Page
  {
    public Wishlists()
    {
      this.InitializeComponent();
    }

    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
      base.OnNavigatedTo(e);
      //HttpClient client = new HttpClient();
      //var json = await client.GetStringAsync(new Uri("http://localhost:14547/api/movies"));
      //var lst = JsonConvert.DeserializeObject<ObservableCollection<Movie>>(json);
      wishlists.ItemsSource = WishlistManager.GetWishlists();
    }

    //private async void Button_Click(object sender, RoutedEventArgs e)
    //{
    //  //var movie = new Movie() { Title = "new movie", Director = "director" };
    //  //var movieJson = JsonConvert.SerializeObject(movie);

    //  //HttpClient client = new HttpClient();

    //  // var json = await client.GetStringAsync(new Uri("http://localhost:58421/api/movies", 
    //  //     new StringContent(movieJson, System.Text.Encoding.UTF8, "application/json")));

    //}
  }
}
