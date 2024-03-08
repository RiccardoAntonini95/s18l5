using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PixelPalaceHotel.Models
{
    public class Servizio
    {
        [Key]
        public int IdServizio {  get; set; }

        [Required (ErrorMessage ="Tipo servizio obbligatorio")]
        [Display(Name = "Tipo servizio: ")]
        public string TipoServizio { get; set; }

        [Required(ErrorMessage = "Data servizio obbligatoria")]
        [Display(Name = "Data servizio: ")]
        public DateTime DataServizio { get; set; }

        [Required(ErrorMessage = "Quantità obbligatoria")]
        [Display(Name = "Numero di servizi richiesti: ")]
        public int Quantita { get; set; }

        [Required(ErrorMessage = "Prezzo servizio obbligatorio")]
        [Display(Name = "Prezzo servizio: ")]
        public decimal Prezzo { get; set; }

        [Required(ErrorMessage = "Identificativo prenotazione obbligatorio")]
        [Display(Name = "Nome cliente: ")]
        public int IdPrenotazione { get; set; }

    }
}