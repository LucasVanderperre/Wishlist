﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishlistAppBackend.Models;
using windowsWishlistAppGroepVM9.Models;
using MongoDB.Bson;
using Microsoft.AspNetCore.Http;


namespace WishlistAppBackend.Controllers
{
    [Route("api/wishlist")]
    public class WishlistAPIController : Controller
    {
        DataAccess objds;

        public WishlistAPIController()
        {
            objds = new DataAccess();
        }

        [HttpGet]
        public IEnumerable<Wishlist> Get()
        {
            return objds.GetWishlists();
        }

        [HttpGet("{id:length(24)}")]
        public IActionResult Get(string id)
        {
            var Wishlist = objds.GetWishlist(new ObjectId(id));
            if (Wishlist == null)
            {
                return NotFound();
            }
            if(Wishlist.Items == null)
            {
                Wishlist.Items = new List<Item>();
            }
            return new ObjectResult(Wishlist);
        }

        [HttpPut]
        public IEnumerable<Wishlist> Put([FromBody]List<string> p)
        {
            List<Wishlist> result = new List<Wishlist>();
            foreach(string id in p){
                var Wishlist = objds.GetWishlist(new ObjectId(id));
                if (Wishlist == null)
                {
                    throw new Exception("list not found");
                }
                if(Wishlist.Items == null)
                {
                    Wishlist.Items = new List<Item>();
                }

                result.Add(Wishlist);
            }
            return result;
        }

        [HttpPost("{id:length(24)}")]
        public IActionResult Post([FromBody]Wishlist p, string id)
        {
            var gebruiker = objds.GetGebruiker(new ObjectId(id));
            objds.CreateWishlist(p);
            gebruiker.addEigenWishlist(p);
            objds.UpdateGebruiker(new ObjectId(id), gebruiker);
            return Ok(p);
        }


        [HttpPut("{id:length(24)}")]
        public IActionResult Put(string id, [FromBody]Wishlist p)
        {
            var recId = new ObjectId(id);
            var Wishlist = objds.GetWishlist(recId);
            if (Wishlist == null)
            {
                return HttpNotFound();
            }

            objds.UpdateWishlist(recId, p);
            return new OkResult();
        }

        private IActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Wishlist = objds.GetWishlist(new ObjectId(id));
            if (Wishlist == null)
            {
                return NotFound();
            }

            objds.RemoveWishlist(Wishlist.Id);
            return new OkResult();
        }
    }
}