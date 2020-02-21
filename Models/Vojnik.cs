using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MvcVojnik.Models
{
    public class Vojnik
    {
        public int VojnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        [DataType(DataType.Date)]
        [Display(Name="Datum rođenja")]
        public DateTime DatumRođenja { get; set; }
        public string Baza { get; set; }
        public string Pozicija { get; set; }
    }
}
