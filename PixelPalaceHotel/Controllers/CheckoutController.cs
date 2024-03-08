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
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult EffettuaCheckout()
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

        public ActionResult RisultatoCheckout(string IdPrenotazione)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HotelDb"].ToString();
            var conn = new SqlConnection(connectionString);
            List<Checkout> riepilogoList = new List<Checkout>();
            try
            {
             conn.Open();
             var commandList = new SqlCommand("SELECT c.NumeroCamera, p.InizioSoggiorno, p.FineSoggiorno, s.TipoServizio, s.DataServizio, (SUM(p.Tariffa - p.Caparra) + SUM(s.prezzo)) AS TotaleImporto FROM Prenotazioni as p JOIN Servizi AS s ON s.IdPrenotazione = p.IdPrenotazione JOIN Camere AS c ON c.IdCamera = p.IdCamera WHERE p.IdPrenotazione = @idprenotato GROUP BY c.NumeroCamera, p.InizioSoggiorno, p.FineSoggiorno, s.TipoServizio, s.DataServizio", conn);
             commandList.Parameters.AddWithValue("@idprenotato", IdPrenotazione);
             var readerList = commandList.ExecuteReader();

              if (readerList.HasRows)
              {
                while(readerList.Read())
                {
                    var riepilogo = new Checkout()
                    {
                        NumeroCamera = (int)readerList["NumeroCamera"],
                        InizioSoggiorno = (DateTime)readerList["InizioSoggiorno"],
                        FineSoggiorno = (DateTime)readerList["FineSoggiorno"],
                        TipoServizio = (string)readerList["TipoServizio"],
                        DataServizio = (DateTime)readerList["DataServizio"],
                        TotaleImporto = (decimal)readerList["TotaleImporto"]
                    };
                    riepilogoList.Add(riepilogo);
                }
              }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            finally { conn.Close(); }
            return View(riepilogoList);
        }
    }
}