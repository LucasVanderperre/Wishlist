using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace windowsWishlistAppGroepVM9.Models
{
    public class Wishlist
    {
        public string name { get; set; }
        [JsonProperty("naam")]
        public String Naam { get; set; }
        [JsonProperty("datum")]
        public DateTime Datum { get; set; }
        [JsonProperty("items")]
        public ICollection<Item> Items { get; set; }
        [JsonProperty("volgers")]
        public ICollection<string> Volgers { get; set; }
        [JsonProperty("aanvragen")]
        public ICollection<string> Aanvragen { get; set; }
        public Wishlist()
        {
            Items = new List<Item>();
            Volgers = new List<string>();
            Aanvragen = new List<string>();
        }

        public Wishlist(string naam, DateTime datum)
        {
            Items = new List<Item>();
            Volgers = new List<string>();
            Aanvragen = new List<string>();
            Naam = naam;
            Datum = datum;
        }

        public void addItem(Item item)
        {
            Items.Add(item);
        }
        public void addVolger(Gebruiker gbr)
        {
            Volgers.Add(gbr.username);
        }
        public void verwijderVolger(Gebruiker gbr)
        {
            Volgers.Remove(gbr.username);
        }
        public void addAanvraag(Gebruiker gbr)
        {
            Aanvragen.Add(gbr.username);
        }
        public void keurAanvraagGoed(Gebruiker gbr)
        {
            if (Aanvragen.Contains(gbr.username))
            {
                Aanvragen.Remove(gbr.username);
                Volgers.Add(gbr.username);
            }
        }
    }
}
