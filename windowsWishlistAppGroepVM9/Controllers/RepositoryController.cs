﻿using Newtonsoft.Json;
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
        public HomescreenViewModel homescreenLists { get; set; }

        public WishlistViewModel wishlistViewmodel { get; set; }

        public bool results = false;
        public RepositoryController()
        {
            gebruikerViewModel = new LoginViewModel();
            homescreenLists = new HomescreenViewModel();
            wishlistViewmodel = new WishlistViewModel();
        }
        public async Task Login(Gebruiker gbr)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri(baseUrl + "/login/" + gbr.username + "/" + gbr.wachtwoord));
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
            var result = await client.PostAsync((baseUrl + "/wishlist/" + gebruikerViewModel.Gebruiker.name), stringContent);
            result.EnsureSuccessStatusCode();
            string responseBody = await result.Content.ReadAsStringAsync();
            Wishlist wl = JsonConvert.DeserializeObject<Wishlist>(responseBody);
            if (result != null)
            {
                gebruikerViewModel.Gebruiker.addEigenWishlist(wl.name);
                Console.Write("wishlist toegevoegd");
            }
            else
            {
                Console.Write("wishlist NIET toegevoegd");
            }
        }

        public async Task addUitnodiging(string username, string wishlist)
        {
            HttpClient client = new HttpClient();
            var myContent = JsonConvert.SerializeObject(username);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");
            var result = await client.GetStringAsync(baseUrl + "/gebruiker/" + username);
            Gebruiker gebruiker = JsonConvert.DeserializeObject<Gebruiker>(result);
            gebruiker.addUitnodiging(wishlist);
            myContent = JsonConvert.SerializeObject(gebruiker);
            stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");
            var rst = await client.PutAsync(baseUrl + "/gebruiker/" + gebruiker.name, stringContent);
            rst.EnsureSuccessStatusCode();
        }

        public async Task UpdateWishlist(Wishlist wishlist)
        {
            HttpClient client = new HttpClient();
            var myContent = JsonConvert.SerializeObject(wishlist);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");
            var result = await client.PutAsync((baseUrl + "/wishlist/" + wishlist.name), stringContent);
            result.EnsureSuccessStatusCode(); ;
            if (result != null)
            {
                Console.Write("Item toegevoegd");
            }
            else
            {
                Console.Write("item NIET toegevoegd");
            }
        }

        public async Task CheckUsername(string usrname, string wishlist)
        {
            results = false;
            HttpClient client = new HttpClient();
            var myContent = JsonConvert.SerializeObject(usrname);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");
            var result = await client.GetStringAsync(baseUrl + "/gebruiker/" + usrname);
            Gebruiker wl = JsonConvert.DeserializeObject<Gebruiker>(result);
            if (wl != null)
            {
                Console.Write("User bestaat");
                results = true;
            }
            else
            {
                Console.Write("User bestaat niet");
            }
        }
        public async Task getWishlists()
        {
            HttpClient client = new HttpClient();
            var myContent = JsonConvert.SerializeObject(gebruikerViewModel.Gebruiker.EigenWishlists);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");
            var result = await client.PutAsync(baseUrl + "/wishlist", stringContent);
            result.EnsureSuccessStatusCode();
            string responseBody = await result.Content.ReadAsStringAsync();
            List<Wishlist> wl = JsonConvert.DeserializeObject<List<Wishlist>>(responseBody);
            if (wl != null)
            {
                homescreenLists.eigenWishlists = wl;
                Console.Write("Wishlist opgelhaald");
            }
            else
            {
                Console.Write("Wishlist niet opgelhaald");
            }

            myContent = JsonConvert.SerializeObject(gebruikerViewModel.Gebruiker.AndereWishlists);
            stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");
            result = await client.PutAsync(baseUrl + "/wishlist", stringContent);
            result.EnsureSuccessStatusCode();
            responseBody = await result.Content.ReadAsStringAsync();
            List<Wishlist> wl1 = JsonConvert.DeserializeObject<List<Wishlist>>(responseBody);
            if (wl1 != null)
            {
                homescreenLists.volgendeWishlists = wl1;
                Console.Write("Wishlist opgelhaald");
            }
            else
            {
                Console.Write("Wishlist niet opgelhaald");
            }

            myContent = JsonConvert.SerializeObject(gebruikerViewModel.Gebruiker.Uitnodigingen);
            stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");
            result = await client.PutAsync(baseUrl + "/wishlist", stringContent);
            result.EnsureSuccessStatusCode();
            responseBody = await result.Content.ReadAsStringAsync();
            List<Wishlist> wl2 = JsonConvert.DeserializeObject<List<Wishlist>>(responseBody);
            if (wl2 != null)
            {
                homescreenLists.aangevraagdeWishlists = wl2;
                Console.Write("Wishlist opgelhaald");
            }
            else
            {
                Console.Write("Wishlist niet opgelhaald");
            }
        }

        public async Task weigerUitnodiging(Wishlist wishlist)
        {
            gebruikerViewModel.Gebruiker.Uitnodigingen.Remove(wishlist.name);
            wishlist.Volgers.Remove(gebruikerViewModel.Gebruiker.username);
            await UpdateWishlist(wishlist);
            HttpClient client = new HttpClient();
            var myContent = JsonConvert.SerializeObject(gebruikerViewModel.Gebruiker);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");
            var rst = await client.PutAsync(baseUrl + "/gebruiker/" + gebruikerViewModel.Gebruiker.name, stringContent);
            rst.EnsureSuccessStatusCode();
        }

        public async Task accepteerUitnodiging(Wishlist wishlist)
        {
            gebruikerViewModel.Gebruiker.addVolgendeWishlist(wishlist.name);
            gebruikerViewModel.Gebruiker.Uitnodigingen.Remove(wishlist.name);
            HttpClient client = new HttpClient();
            var myContent = JsonConvert.SerializeObject(gebruikerViewModel.Gebruiker);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");
            var rst = await client.PutAsync(baseUrl + "/gebruiker/" + gebruikerViewModel.Gebruiker.name, stringContent);
            rst.EnsureSuccessStatusCode();
        }

        public async Task koopItem(Item item, Wishlist list)
        {
            list.Items.Remove(item);
            item.Gebruiker = gebruikerViewModel.Gebruiker.username;
            list.Items.Add(item);

            HttpClient client = new HttpClient();
            var myContent = JsonConvert.SerializeObject(list);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");
            var rst = await client.PutAsync(baseUrl + "/wishlist/" + list.name, stringContent);
            rst.EnsureSuccessStatusCode();
        }
    }
}
