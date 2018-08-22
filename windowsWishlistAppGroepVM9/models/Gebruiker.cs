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
        public ICollection<string> AndereWishlists { get; set; }
        public ICollection<string> Uitnodigingen { get; set; }
        public string wachtwoord { get; set; }

        public Gebruiker() {
            EigenWishlists = new List<string>();
            AndereWishlists = new List<string>();
            Uitnodigingen = new List<string>();

        }

        public Gebruiker(string username, string wachtwoord)
        {
            this.username = username;
            this.wachtwoord = wachtwoord;
            EigenWishlists = new List<string>();
            AndereWishlists = new List<string>();
            Uitnodigingen = new List<string>();
        }
        public Gebruiker(string username, string wachtwoord, string voornaam, string familienaam)
		{
            this.username = username;
            this.wachtwoord = wachtwoord;
            this.voornaam = voornaam;
            this.familienaam = familienaam;
            EigenWishlists = new List<string>();
            AndereWishlists = new List<string>();
            Uitnodigingen = new List<string>();
        }

		public void addEigenWishlist(string wishlist)
		{
			EigenWishlists.Add(wishlist);
		}
		public void addVolgendeWishlist(string wishlist)
		{
            AndereWishlists.Add(wishlist);
		}

		public void addUitnodiging(string wishlist)
		{
			Uitnodigingen.Add(wishlist);
		}
	}
}
