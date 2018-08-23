using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Microsoft.AspNetCore.Http;
using WishlistAppBackend.Models;
using windowsWishlistAppGroepVM9.Models;

namespace ItemAppBackend.Controllers
{
  [Route("api/item")]
  public class ItemAPIController : Controller
  {
    DataAccess objds;

    public ItemAPIController()
    {
      objds = new DataAccess();
    }

    [HttpGet]
    public IEnumerable<Item> Get()
    {
      return objds.GetItems();
    }
    [HttpGet("{id:length(24)}")]
    public IActionResult Get(string id)
    {
      var Item = objds.GetItem(new ObjectId(id));
      if (Item == null)
      {
        return NotFound();
      }
      return new ObjectResult(Item);
    }

    [HttpPost]
    public IActionResult Post([FromBody]Item p)
    {
      objds.CreateItem(p);
      return Ok(p);
    }
    [HttpPut("{id:length(24)}")]
    public IActionResult Put(string id, [FromBody]Item p)
    {
      var recId = new ObjectId(id);
      var Item = objds.GetItem(recId);
      if (Item == null)
      {
        return HttpNotFound();
      }

      objds.UpdateItem(recId, p);
      return new OkResult();
    }

    private IActionResult HttpNotFound()
    {
      throw new NotImplementedException();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var Item = objds.GetItem(new ObjectId(id));
      if (Item == null)
      {
        return NotFound();
      }

      objds.RemoveItem(Item.Id);
      return new OkResult();
    }
  }
}