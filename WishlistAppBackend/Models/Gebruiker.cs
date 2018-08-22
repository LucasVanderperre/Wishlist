using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace windowsWishlistAppGroepVM9.Models
{
    public class Gebruiker
    {
        public ObjectId Id { get; set; }
        [BsonElement("Username")]
        public String Username { get; set; }
        [BsonElement("Voornaam")]
        public String Voornaam { get; set; }
        [BsonElement("Familienaam")]
        public String Familienaam { get; set; }
        [BsonElement("Wachtwoord")]
        public String Wachtwoord { get; set; }
        [BsonElement("EigenWishlists")]
        public ICollection<Wishlist> EigenWishlists { get; set; }
        [BsonElement("AndereWishlists")]
        public ICollection<Wishlist> AndereWishlists { get; set; }
        [BsonElement("Uitnodigingen")]
        public ICollection<Wishlist> Uitnodigingen { get; set; }

        public Gebruiker(String username, String wachtwoord, String voornaam, String familienaam)
        {
            this.Username = username;
            this.Wachtwoord = wachtwoord;
            this.Voornaam = voornaam;
            this.Familienaam = familienaam;
            this.EigenWishlists = new List<Wishlist>();
            this.AndereWishlists = new List<Wishlist>();
            this.Uitnodigingen = new List<Wishlist>();
        }

        public void addEigenWishlist(Wishlist wishlist)
        {
            EigenWishlists.Add(wishlist);
        }
        public void addAndereWishlist(Wishlist wishlist)
        {
            AndereWishlists.Add(wishlist);
        }

        public void addUitnodiging(Wishlist wishlist)
        {
            Uitnodigingen.Add(wishlist);
        }
    }
}