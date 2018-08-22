using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace windowsWishlistAppGroepVM9.Models
{
    public class Wishlist
    {
        //public String Id { get; set; }
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        public string name
        {
            get { return Convert.ToString(Id); }
            set
            {
                if (value == null)
                {
                    Id = new ObjectId();
                }
                else
                {
                    Id = MongoDB.Bson.ObjectId.Parse(value);
                }
            }
        }
        [BsonElement("Naam")]
        public String Naam { get; set; }
        [BsonElement("Datum")]
        public DateTime Datum { get; set; }
        [BsonElement("Items")]
        public ICollection<Item> Items { get; set; }
        [BsonElement("Volgers")]
        public HashSet<string> Volgers { get; set; }
        [BsonElement("Aanvragen")]
        public HashSet<string> Aanvragen { get; set; }

        public Wishlist(String naam, DateTime datum)
        {
            Naam = naam;
            Datum = datum;
            this.Items = new List<Item>();
            this.Volgers = new HashSet<string>();
            this.Aanvragen = new HashSet<string>();
        }

        public void addItem(Item item)
        {
            Items.Add(item);
        }

        public void addVolger(Gebruiker gbr)
        {
            Volgers.Add(gbr.Username);
        }

        public void verwijderVolger(Gebruiker gbr)
        {
            Volgers.Remove(gbr.Username);
        }

        public void addAanvraag(Gebruiker gbr)
        {
            Aanvragen.Add(gbr.Username);
        }

        public void keurAanvraagGoed(Gebruiker gbr)
        {
            if (Aanvragen.Contains(gbr.Username))
            {
                Aanvragen.Remove(gbr.Username);
                Volgers.Add(gbr.Username);
            }
        }
    }
}
