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
    public ObjectId Id { get; set; }
    [BsonElement("Naam")]
    public String Naam { get; set; }
    [BsonElement("Datum")]
    public DateTime Datum { get; set; }
    [BsonElement("Items")]
    public ICollection<Item> Items { get; set; }
    [BsonElement("Volgers")]
    public HashSet<Gebruiker> Volgers { get; }
    [BsonElement("Aanvragen")]
    public HashSet<Gebruiker> Aanvragen { get; }

		public Wishlist(String naam, DateTime datum)
		{
			Naam = naam;
			Datum = datum;
      this.Items = new List<Item>();
      this.Volgers = new HashSet<Gebruiker>();
      this.Aanvragen = new HashSet<Gebruiker>();
    }

		public void addItem(Item item)
		{
			Items.Add(item);
		}

		public void addVolger(Gebruiker gbr)
		{
			Volgers.Add(gbr);
		}

		public void verwijderVolger(Gebruiker gbr)
		{
			Volgers.Remove(gbr);
		}

		public void addAanvraag(Gebruiker gbr)
		{
			Aanvragen.Add(gbr);
		}

		public void keurAanvraagGoed(Gebruiker gbr)
		{
			if (Aanvragen.Contains(gbr)){
				Aanvragen.Remove(gbr);
				Volgers.Add(gbr);
			}
		}
	}
}
