using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using windowsWishlistAppGroepVM9.Models;
using windowsWishlistAppGroepVM9.ViewModels;

namespace windowsWishlistAppGroepVM9.Controllers
{
    public class RepositoryController
    {
        private readonly string baseUrl = "http://localhost:57703/api";
        public LoginViewModel gebruikerViewModel { get; set; }
        public bool results = true;
        public RepositoryController()
        {
        }
        public async Task Login(Gebruiker gbr)
        {
            gebruikerViewModel = new LoginViewModel();
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri(baseUrl+ "/login/"+gbr.username+"/"+gbr.wachtwoord));
            Gebruiker gebruiker = JsonConvert.DeserializeObject<Gebruiker>(json);
            if (gebruiker != null)
            {
                gebruikerViewModel.Gebruiker = gebruiker;
                Console.Write("gebruiker ingelogd");

            }
            else
            {
                gebruikerViewModel.Gebruiker = gebruiker;
                Console.Write("gebruiker niet ingelogd");
            }
        }

        public async Task Registreer(Gebruiker gbr)
        {
            gebruikerViewModel = new LoginViewModel();
            HttpClient client = new HttpClient();
            var myContent = JsonConvert.SerializeObject(gbr);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");
            var result = await client.PostAsync((baseUrl + "/login"), stringContent);
            result.EnsureSuccessStatusCode();
            string responseBody = await result.Content.ReadAsStringAsync();
            Gebruiker gebruiker = JsonConvert.DeserializeObject<Gebruiker>(responseBody);
            if (gebruiker != null)
            {
                gebruikerViewModel.Gebruiker = gebruiker;
                Console.Write("gebruiker geregistreerd");

            }
            else
            {
                gebruikerViewModel.Gebruiker = gebruiker;
                Console.Write("gebruiker niet geregistreerd");
            }
        }

        public async Task CreateWishlist(Wishlist wishlist)
        {
            HttpClient client = new HttpClient();
            var myContent = JsonConvert.SerializeObject(wishlist);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");
            var result = await client.PostAsync((baseUrl + "/wishlist/"+ gebruikerViewModel.Gebruiker.name), stringContent);
            result.EnsureSuccessStatusCode();
            string responseBody = await result.Content.ReadAsStringAsync();
            Wishlist wl = JsonConvert.DeserializeObject<Wishlist>(responseBody);
            if (result != null)
            {
                gebruikerViewModel.Gebruiker.addEigenWishlist(wl);
                Console.Write("wishlist toegevoegd");

            }
            else
            {
                Console.Write("wishlist NIET toegevoegd");
            }
        }

        public async Task UpdateWishlist(Wishlist wishlist)
        {
            HttpClient client = new HttpClient();
            var myContent = JsonConvert.SerializeObject(wishlist);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");
            var result = await client.PutAsync((baseUrl + "/wishlist/"+wishlist.name ), stringContent);
            result.EnsureSuccessStatusCode();
            string responseBody = await result.Content.ReadAsStringAsync();
            Wishlist wl = JsonConvert.DeserializeObject<Wishlist>(responseBody);
            if (result != null)
            {
                string remove = gebruikerViewModel.Gebruiker.EigenWishlists.Where(item => item.Equals(wishlist.name)).First();
                gebruikerViewModel.Gebruiker.EigenWishlists.Remove(remove);
                gebruikerViewModel.Gebruiker.addEigenWishlist(wl);
                Console.Write("Item toegevoegd");

            }
            else
            {
                Console.Write("item NIET toegevoegd");
            }
        }

        public async Task CheckUsername(string usrname)
        {
            HttpClient client = new HttpClient();
            var myContent = JsonConvert.SerializeObject(usrname);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");
            var result = await client.GetStringAsync(baseUrl + "/gebruiker/" + usrname);
            Gebruiker wl = JsonConvert.DeserializeObject<Gebruiker>(result);
            if (result != null)
            {
                Console.Write("User bestaat");
                results = true;
            }
            else
            {
                Console.Write("User bestaat niet");
                results = false;
            }
        }

    }
}
