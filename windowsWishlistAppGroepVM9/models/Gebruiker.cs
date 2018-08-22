using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace windowsWishlistAppGroepVM9.Models
{
public class Gebruiker
    {

        public string name { get; set; }

        public string username { get; set; }
        public string voornaam { get; set; }
        public string familienaam { get; set; }
        public ICollection<string> EigenWishlists { get; set; }
        public ICollection<string> VolgendeWishlists { get; set; }
        public ICollection<string> Uitnodigingen { get; set; }
        public string wachtwoord { get; set; }

        public Gebruiker() {
            EigenWishlists = new List<string>();
            VolgendeWishlists = new List<string>();
            Uitnodigingen = new List<string>();

        }

        public Gebruiker(string username, string wachtwoord)
        {
            this.username = username;
            this.wachtwoord = wachtwoord;
            EigenWishlists = new List<string>();
            VolgendeWishlists = new List<string>();
            Uitnodigingen = new List<string>();
        }
        public Gebruiker(string username, string wachtwoord, string voornaam, string familienaam)
		{
            this.username = username;
            this.wachtwoord = wachtwoord;
            this.voornaam = voornaam;
            this.familienaam = familienaam;
            EigenWishlists = new List<string>();
            VolgendeWishlists = new List<string>();
            Uitnodigingen = new List<string>();
        }

		public void addEigenWishlist(Wishlist wishlist)
		{
			EigenWishlists.Add(wishlist.name);
		}
		public void addVolgendeWishlist(Wishlist wishlist)
		{
			VolgendeWishlists.Add(wishlist.name);
		}

		public void addUitnodiging(Wishlist wishlist)
		{
			Uitnodigingen.Add(wishlist.name);
		}
	}
}
