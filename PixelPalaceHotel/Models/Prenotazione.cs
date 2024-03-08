using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace PixelPalaceHotel.Models
{
    public class Prenotazione
    {
        [Key]
        public int IdPrenotazione { get; set; }

        [Required(ErrorMessage = "Codice fiscale obbligatorio")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Il codice fiscale inserito non è valido")]
        [Display(Name = "Codice Fiscale: ")]
        public string CodiceFiscale { get; set; }

        [Required(ErrorMessage = "Cognome cliente obbligatorio")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Il cognome inserito non è valido, MAX 20 caratteri")]
        [Display(Name = "Cognome: ")]
        public string Cognome { get; set; }

        [Required(ErrorMessage = "Nome cliente obbligatorio")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Il nome inserito non è valido, MAX 20 caratteri")]
        [Display(Name = "Nome: ")]
        public string Nome { get; set; }

        [StringLength(20, MinimumLength = 1, ErrorMessage = "La città inserita non è valida, MAX 20 caratteri")]
        [Display(Name = "Città: ")]
        public string Citta { get; set; }

        [StringLength(20, MinimumLength = 1, ErrorMessage = "Il provincia inserita non è valida, MAX 20 caratteri")]
        [Display(Name = "Provincia: ")]
        public string Provincia { get; set; }

        [StringLength(25, MinimumLength = 1, ErrorMessage = "La mail inserita è troppo lunga, MAX 25 caratteri")]
        [EmailAddress(ErrorMessage = "E-mail inserita non valida")]
        [Display(Name = "E-Mail: ")]
        public string Email { get; set; }

        [Display(Name = "Telefono fisso: ")]
        public int Tel { get; set; }

        [Required(ErrorMessage = "Cellulare cliente obbligatorio")]
        [Display(Name = "Cellulare: ")]
        public int Cell { get; set; }

        [Required(ErrorMessage = "Identificativo camera obbligatorio")]
        [Display (Name = "Numero camera")]
        public int IdCamera { get; set; }

        [Required(ErrorMessage = "Data prenotazione obbligatoria")]
        [Display(Name = "Data prenotazione: ")]
        public DateTime DataPrenotazione { get; set; }

        [Required(ErrorMessage = "Data inizio soggiorno obbligatoria")]
        [Display(Name = "Inizio soggiorno: ")]
        public DateTime InizioSoggiorno { get; set; }

        [Required(ErrorMessage = "Data fine soggiorno obbligatoria")]
        [Display(Name = "Fine soggiorno: ")]
        public DateTime FineSoggiorno { get; set; }

        [Required(ErrorMessage = "Anno prenotazione obbligatorio")]
        [Display(Name = "Anno: ")]
        public int Anno { get; set; }

        [Required(ErrorMessage = "Caparra prenotazione obbligatoria")]
        [Display(Name = "Caparra confirmatoria: ")]
        public decimal Caparra { get; set; }

        [Required(ErrorMessage = "Tariffa prenotazione obbligatoria")]
        [Display(Name = "Tariffa applicata: ")]
        public decimal Tariffa { get; set; }

        [Required(ErrorMessage = "Tipo soggiorno obbligatorio")]
        [Display(Name = "Tipo soggiorno: ")]
        public string TipoSoggiorno { get; set; }

    }
}