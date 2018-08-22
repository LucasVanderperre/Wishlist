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
        [BsonElement("Username")]
        public String Username { get; set; }
        [BsonElement("Voornaam")]
        public String Voornaam { get; set; }
        [BsonElement("Familienaam")]
        public String Familienaam { get; set; }
        [BsonElement("Wachtwoord")]
        public String Wachtwoord { get; set; }
        [BsonElement("EigenWishlists")]
        public ICollection<string> EigenWishlists { get; set; }
        [BsonElement("AndereWishlists")]
        public ICollection<string> AndereWishlists { get; set; }
        [BsonElement("Uitnodigingen")]
        public ICollection<string> Uitnodigingen { get; set; }

        public Gebruiker(String username, String wachtwoord, String voornaam, String familienaam)
        {
            this.Username = username;
            this.Wachtwoord = wachtwoord;
            this.Voornaam = voornaam;
            this.Familienaam = familienaam;
            this.EigenWishlists = new List<string>();
            this.AndereWishlists = new List<string>();
            this.Uitnodigingen = new List<string>();
        }

        public void addEigenWishlist(Wishlist wishlist)
        {
            EigenWishlists.Add(wishlist.name);
        }
        public void addAndereWishlist(Wishlist wishlist)
        {
            AndereWishlists.Add(wishlist.name);
        }

        public void addUitnodiging(Wishlist wishlist)
        {
            Uitnodigingen.Add(wishlist.name);
        }
    }
}