using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

//using MongoDB.Bson;


namespace windowsWishlistAppGroepVM9.Models
{
    public class Wishlist
    {
        public string name { get; set; }

        //public BsonObjectId Id { get; set; }
        [JsonProperty("naam")]
        public String Naam { get; set; }
        [JsonProperty("datum")]
        public DateTime Datum { get; set; }
        [JsonProperty("items")]
        public ICollection<Item> Items { get; set; }
        [JsonProperty("volgers")]
        public HashSet<string> Volgers { get; }
        [JsonProperty("aanvragen")]
        public HashSet<string> Aanvragen { get; }

        public Wishlist()
        {

        }

        public Wishlist(String naam, DateTime datum)
        {
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
