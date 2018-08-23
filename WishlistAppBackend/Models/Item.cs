using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace windowsWishlistAppGroepVM9.Models
{
	public class Item
	{
    public ObjectId Id { get; set; }
	  [BsonElement("Titel")]
    public string Titel { get; set; }
	  [BsonElement("Beschrijving")]
    public string Beschrijving { get; set; }
	  [BsonElement("FotoUrl")]
    public string FotoUrl { get; set; }
	  [BsonElement("Gebruiker")]
    public string Gebruiker { get; set; }
    public CategorieEnum Categorie { get; set; }

		public Item(String titel, String beschrijving)
		{
			Titel = titel;
			Beschrijving = beschrijving;
		}

		public Boolean getGekocht()
		{
			if (Gebruiker != null) { return true; }
			return false;
		}
	}
}
