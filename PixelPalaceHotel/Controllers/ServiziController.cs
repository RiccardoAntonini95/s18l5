using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PixelPalaceHotel.Controllers
{
    public class ServiziController : Controller
    {
        // GET: Servizi
        public ActionResult NuovoServizio()
        {
            return View();
        }
    }
}