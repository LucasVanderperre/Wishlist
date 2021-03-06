﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace windowsWishlistAppGroepVM9.Models
{
    public class Item
    {
        public string Titel { get; set; }
        public string Beschrijving { get; set; }
        public string FotoUrl { get; set; }
        public string Gebruiker { get; set; }
        public CategorieEnum Categorie { get; set; }

        public Item(string titel, string beschrijving, CategorieEnum cat, string gebruiker)
        {
            Titel = titel;
            Beschrijving = beschrijving;
            Categorie = cat;
            Gebruiker = gebruiker;
        }
    }
}
