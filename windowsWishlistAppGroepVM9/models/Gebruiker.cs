using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace windowsWishlistAppGroepVM9.Models
{
public class Gebruiker
	{
		public String username { get; set; }
        public String voornaam { get; set; }
        public String familienaam { get; set; }
        private ICollection<Wishlist> EigenWishlists { get; set; }
		private ICollection<Wishlist> VolgendeWishlists { get; set; }
		private ICollection<Wishlist> Uitnodigingen { get; set; }
        public String wachtwoord { get; set; }

        public Gebruiker() { }

        public Gebruiker(String username, String wachtwoord)
        {
            this.username = username;
            this.wachtwoord = wachtwoord;
        }
        public Gebruiker(String username, String wachtwoord, String voornaam, String familienaam)
		{
            this.username = username;
            this.wachtwoord = wachtwoord;
            this.voornaam = voornaam;
            this.familienaam = familienaam;
		}

		public void addEigenWishlist(Wishlist wishlist)
		{
			EigenWishlists.Add(wishlist);
		}
		public void addVolgendeWishlist(Wishlist wishlist)
		{
			VolgendeWishlists.Add(wishlist);
		}

		public void addUitnodiging(Wishlist wishlist)
		{
			Uitnodigingen.Add(wishlist);
		}
	}
}
