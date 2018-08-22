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
    //public BsonObjectId Id { get; set; }
    [JsonProperty("naam")]
		public String Naam { get; set; }
	  [JsonProperty("datum")]
    public DateTime Datum { get; set; }
	  [JsonProperty("items")]
    public ICollection<Item> Items { get; set; }
	  [JsonProperty("volgers")]
    public HashSet<Gebruiker> Volgers { get; }
	  [JsonProperty("aanvragen")]
    public HashSet<Gebruiker> Aanvragen { get; }

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

  public class WishlistManager
  {
    public static List<Wishlist> GetWishlists()
    {
      var lists = new List<Wishlist>();

      lists.Add(new Wishlist("Piet's Bday bash", DateTime.Today));
      lists.Add(new Wishlist("Lucas's engagement", DateTime.Today));
      lists.Add(new Wishlist("Tom's parteh", DateTime.Today));
      lists.Add(new Wishlist("Piet's degree", DateTime.Today));

      return lists;
    }
  }
}
