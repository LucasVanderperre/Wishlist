using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishlistAppBackend.Models;
using MongoDB.Bson;
using windowsWishlistAppGroepVM9.Models;

namespace WishlistAppBackend.Controllers
{
    [Route("api/gebruiker")]
    public class GebruikerAPIController : Controller
    {
      DataAccess objds;

      public GebruikerAPIController()
      {
        objds = new DataAccess();
      }

      [HttpGet]
      public IEnumerable<Gebruiker> Get()
      {
        return objds.GetGebruikers();
      }


      [HttpGet("{Username}")]
      public IActionResult Get(string Username)
      {
        var Gebruiker = objds.GetGebruiker(Username);
        if (Gebruiker == null)
        {
          return NotFound();
        }
        return new ObjectResult(Gebruiker);
      }

      [HttpPost]
      public IActionResult Post([FromBody]Gebruiker p)
      {
        objds.RegistreerGebruiker(p);
        //return new HttpOkObjectResult(p);
        return Ok(p);
      }


      [HttpPut("{id:length(24)}")]
      public IActionResult Put(string id, [FromBody]Gebruiker p)
      {
        var recId = new ObjectId(id);
        var Gebruiker = objds.GetGebruiker(recId);
        if (Gebruiker == null)
        {
          return HttpNotFound();
        }

        objds.UpdateGebruiker(recId, p);
        return new OkResult();
      }

      private IActionResult HttpNotFound()
      {
        throw new NotImplementedException();
      }

      [HttpDelete("{id:length(24)}")]
      public IActionResult Delete(string id)
      {
        var Gebruiker = objds.GetGebruiker(new ObjectId(id));
        if (Gebruiker == null)
        {
          return NotFound();
        }

        objds.RemoveGebruiker(Gebruiker.Id);
        return new OkResult();
      }
    }
}