using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using windowsWishlistAppGroepVM9.Models;
using System.Collections.ObjectModel;

namespace WishlistAppBackend.Models
{
    public class DataAccess
    {

        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        public DataAccess()
        {
            _client = new MongoClient("mongodb://rec_user:windowstaakdb@ds139436.mlab.com:39436/windowstaak");
#pragma warning disable CS0618 // Type or member is obsolete
            _server = _client.GetServer();
#pragma warning restore CS0618 // Type or member is obsolete
            _db = _server.GetDatabase("windowstaak");
            var users = _db.GetCollection<Gebruiker>("Gebruikers");

            users.CreateIndex(new IndexKeysBuilder().Ascending("Username"), IndexOptions.SetUnique(true));
        }

        public IEnumerable<Wishlist> GetWishlists()
        {
            return _db.GetCollection<Wishlist>("Wishlists").FindAll();
        }

        public Wishlist GetWishlist(ObjectId id)
        {
            var res = Query<Wishlist>.EQ(p => p.Id, id);
            return _db.GetCollection<Wishlist>("Wishlists").FindOne(res);
        }

        public Wishlist CreateWishlist(Wishlist p)
        {
            _db.GetCollection<Wishlist>("Wishlists").Save(p);
            return p;
        }

        public void UpdateWishlist(ObjectId id, Wishlist p)
        {
            p.Id = id;
            var res = Query<Wishlist>.EQ(pd => pd.Id, id);
            var operation = Update<Wishlist>.Replace(p);
            _db.GetCollection<Wishlist>("Wishlists").Update(res, operation);
        }
        public void RemoveWishlist(ObjectId id)
        {
            var res = Query<Wishlist>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<Wishlist>("Wishlists").Remove(res);
        }

        public IEnumerable<Gebruiker> GetGebruikers()
        {
            return _db.GetCollection<Gebruiker>("Gebruikers").FindAll();
        }

        public Gebruiker GetGebruiker(string username)
        {
            var res = Query<Gebruiker>.EQ(p => p.Username, username);
            return _db.GetCollection<Gebruiker>("Gebruikers").FindOne(res);
        }

        public Gebruiker GetGebruiker(ObjectId id)
        {
            var res = Query<Gebruiker>.EQ(p => p.Id, id);
            return _db.GetCollection<Gebruiker>("Gebruikers").FindOne(res);
        }



        public void UpdateGebruiker(ObjectId id, Gebruiker p)
        {
            p.Id = id;
            var res = Query<Gebruiker>.EQ(pd => pd.Id, id);
            var operation = Update<Gebruiker>.Replace(p);
            _db.GetCollection<Gebruiker>("Gebruikers").Update(res, operation);
        }
        public void RemoveGebruiker(ObjectId id)
        {
            var res = Query<Gebruiker>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<Gebruiker>("Gebruikers").Remove(res);
        }

        public IEnumerable<Item> GetItems()
        {
            return _db.GetCollection<Item>("Items").FindAll();
        }

        public Item GetItem(ObjectId id)
        {
            var res = Query<Item>.EQ(p => p.Id, id);
            return _db.GetCollection<Item>("Items").FindOne(res);
        }

        public Item CreateItem(Item p)
        {
            _db.GetCollection<Item>("Items").Save(p);
            return p;
        }

        public void UpdateItem(ObjectId id, Item p)
        {
            p.Id = id;
            var res = Query<Item>.EQ(pd => pd.Id, id);
            var operation = Update<Item>.Replace(p);
            _db.GetCollection<Item>("Items").Update(res, operation);
        }
        public void RemoveItem(ObjectId id)
        {
            var res = Query<Item>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<Item>("Items").Remove(res);
        }

        public Gebruiker Login(String username, String wachtwoord)
        {
            var query = Query.And(
                Query<Gebruiker>.EQ(g => g.Username, username),
                Query<Gebruiker>.EQ(g => g.Wachtwoord, wachtwoord)
            );
            return _db.GetCollection<Gebruiker>("Gebruikers").FindOne(query);
        }

        public Gebruiker RegistreerGebruiker(Gebruiker p)
        {
            _db.GetCollection<Gebruiker>("Gebruikers").Insert(p);
            return p;
        }
    }
}
