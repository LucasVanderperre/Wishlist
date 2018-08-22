using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using windowsWishlistAppGroepVM9.Models;
using WishlistAppBackend.Models;


namespace WishlistAppBackend.Controllers
{
    [Route("api/login")]
    public class LoginAPIController : Controller
    {
        DataAccess objds;

        public LoginAPIController()
        {
            objds = new DataAccess();
        }

        [HttpGet("{username}/{wachtwoord}")]
        public IActionResult Login(String username, String wachtwoord)
        {
            var gebruiker = objds.Login(username, wachtwoord);
            if (gebruiker == null)
            {
                return NotFound();
            }
            return new ObjectResult(gebruiker);
        }

        [HttpPost]
        public IActionResult Registreer([FromBody]Gebruiker p)
        {
            objds.RegistreerGebruiker(p);
            return Ok(p);
        }

    }
}