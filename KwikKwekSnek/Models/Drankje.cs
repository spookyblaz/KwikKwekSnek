using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KwikKwekSnek.Models
{
    public class Drankje
    {
        [Key]
        public int ID { get; set; }
        public string Naam { get; set; }
        public string Description { get; set; }
        public string afbeelding { get; set; }
        [NotMapped]
        public IFormFile drankImageUrl { get; set; }
        public decimal prijs { get; set; }

        //  public string grootte { get; set; } // vervangen door vast aantal opties
        // public Boolean ijs { get; set; }
        // public Boolean plasticrietje { get; set; }

    }
}
