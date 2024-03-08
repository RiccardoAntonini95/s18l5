using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PixelPalaceHotel.Models
{
    public class Checkout
    {
        public int NumeroCamera {  get; set; }
        public DateTime InizioSoggiorno { get; set; }
        public DateTime FineSoggiorno { get; set; }
        public string TipoServizio { get; set; }
        public DateTime DataServizio { get; set; }
        public decimal TotaleImporto { get; set; }

    }
}