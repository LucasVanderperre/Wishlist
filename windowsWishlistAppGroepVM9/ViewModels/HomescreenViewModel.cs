using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using windowsWishlistAppGroepVM9.Models;

namespace windowsWishlistAppGroepVM9.ViewModels
{
    public class HomescreenViewModel
    {
        public List<Wishlist> eigenWishlists { get; set; }
        public List<Wishlist> volgendeWishlists { get; set; }
        public List<Wishlist> aangevraagdeWishlists { get; set; }

        public HomescreenViewModel()
        {
            eigenWishlists = new List<Wishlist>();
            volgendeWishlists = new List<Wishlist>();

            aangevraagdeWishlists = new List<Wishlist>();

        }

    }
}
