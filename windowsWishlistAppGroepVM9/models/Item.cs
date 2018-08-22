using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace windowsWishlistAppGroepVM9.Models
{
public class Item
	{
		private String Titel { get; set; }
		private String Beschrijving { get; set; }
		private String FotoUrl { get; set; }
		private Gebruiker gebruiker { get; set; }
		private CategorieEnum Categorie { get; set; }

		public Item(String titel, String beschrijving, CategorieEnum cat)
		{
			Titel = titel;
			Beschrijving = beschrijving;
            Categorie = cat;
		}

		public Boolean getGekocht()
		{
			if (gebruiker != null) { return true; }
			return false;
		}
	}
}
