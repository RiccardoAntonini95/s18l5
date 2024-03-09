using Microsoft.Ajax.Utilities;
using PixelPalaceHotel.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PixelPalaceHotel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LoggedIn", "Home"); //sei già loggato, torna alla home
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(Dipendente dipendente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HotelDb"].ToString();
            var conn = new SqlConnection(connectionString);
            if (ModelState.IsValid)
            {
                try
                {
                    conn.Open();
                    var command = new SqlCommand("SELECT * FROM Dipendenti WHERE Username = @username AND Pass = @password", conn);
                    command.Parameters.AddWithValue("@username", dipendente.Username);
                    command.Parameters.AddWithValue("@password", dipendente.Pass);
                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        FormsAuthentication.SetAuthCookie(reader["IdDipendente"].ToString(), true);
                        return RedirectToAction("LoggedIn", "Home");
                    }
                    else
                    {
                        return View("error");
                    }
                }
                catch (Exception ex)
                {
                    return View("error");
                }
                finally { conn.Close(); }
            }
             return View("LoggedIn");
        }

        //questa è la vera home page
        [Authorize]
        public ActionResult LoggedIn()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult GetPrenotatiCodiceFiscale(string codiceFiscale)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HotelDb"].ToString();
            var conn = new SqlConnection(connectionString);
            List<Prenotazione> listaPrenotati = new List<Prenotazione>();
            try
            {
              conn.Open();
              var commandList = new SqlCommand("SELECT * FROM Prenotazioni WHERE CodiceFiscale = @codiceFiscale", conn);
              commandList.Parameters.AddWithValue("@codiceFiscale", codiceFiscale);
              var readerList = commandList.ExecuteReader();
              if (readerList.HasRows)
              {
                  while (readerList.Read())
                  {
                    var prenotazione = new Prenotazione()
                    {
                        IdPrenotazione = (int)readerList["IdPrenotazione"],
                        CodiceFiscale = (string)readerList["CodiceFiscale"],
                        Cognome = (string)readerList["Cognome"],
                        Nome = (string)readerList["Nome"],
                        Citta = (string)readerList["Citta"],
                        InizioSoggiorno = (DateTime)readerList["InizioSoggiorno"],
                        FineSoggiorno = (DateTime)readerList["FineSoggiorno"]                     
                     };
                     listaPrenotati.Add(prenotazione);
                  }
              }

            }
            catch (Exception ex)
            {
                return View("Error");
            }
            finally { conn.Close(); }
            return Json(listaPrenotati, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetTotalePensioneCompleta()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HotelDb"].ToString();
            var conn = new SqlConnection(connectionString);
            int totalePensioniComplete = 0;
            try
            {
                conn.Open();
                var commandList = new SqlCommand("SELECT COUNT (*) FROM Prenotazioni WHERE TipoSoggiorno = 'Pensione completa'", conn);
                totalePensioniComplete = (int)commandList.ExecuteScalar();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            finally { conn.Close(); }
            return Json(totalePensioniComplete, JsonRequestBehavior.AllowGet);
        }
    }
}