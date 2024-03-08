using PixelPalaceHotel.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
            string connectionString = ConfigurationManager.ConnectionStrings["HotelDb"].ToString();
            var conn = new SqlConnection(connectionString);
            List<Prenotazione> listaPrenotati = new List<Prenotazione>();
            conn.Open();
            var commandList = new SqlCommand("SELECT * FROM Prenotazioni", conn);
            var readerList = commandList.ExecuteReader();

            if (readerList.HasRows)
            {
                while (readerList.Read())
                {
                    var prenotazione = new Prenotazione()
                    {
                        IdPrenotazione = (int)readerList["IdPrenotazione"],
                        Cognome = (string)readerList["Cognome"],
                        Nome = (string)readerList["Nome"]
                    };
                    listaPrenotati.Add(prenotazione);
                }
                ViewBag.listaPrenotati = listaPrenotati;
                conn.Close();
            }
            return View();
        }

        [HttpPost]
        public ActionResult NuovoServizio(Servizio nuovoServizio)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HotelDb"].ToString();
            var conn = new SqlConnection(connectionString);
            List<Prenotazione> listaPrenotati = new List<Prenotazione>();
            conn.Open();
            var commandList = new SqlCommand("SELECT * FROM Prenotazioni", conn);
            var readerList = commandList.ExecuteReader();

            if (readerList.HasRows)
            {
                while (readerList.Read())
                {
                    var prenotazione = new Prenotazione()
                    {
                        IdPrenotazione = (int)readerList["IdPrenotazione"],
                        Cognome = (string)readerList["Cognome"],
                        Nome = (string)readerList["Nome"]
                    };
                    listaPrenotati.Add(prenotazione);
                }
                ViewBag.listaPrenotati = listaPrenotati;
                conn.Close();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    conn.Open();
                    var command = new SqlCommand(@"INSERT INTO Servizi 
                    (TipoServizio, DataServizio, Quantita, Prezzo, IdPrenotazione)
                    VALUES (@tipoServizio, @dataServizio, @quantita, @prezzo, @idPrenotazione)", conn);
                    command.Parameters.AddWithValue("@tipoServizio", nuovoServizio.TipoServizio);
                    command.Parameters.AddWithValue("@dataServizio", nuovoServizio.DataServizio);
                    command.Parameters.AddWithValue("@quantita", nuovoServizio.Quantita);
                    command.Parameters.AddWithValue("@prezzo", nuovoServizio.Prezzo);
                    command.Parameters.AddWithValue("@idPrenotazione", nuovoServizio.IdPrenotazione);
                    var nRows = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return View("error");
                }
                finally { conn.Close(); }
                return RedirectToAction("LoggedIn", "Home");
            }
            return View();

        }
    }
}