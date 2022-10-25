using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KwikKwekSnek.Models
{
    public class Drankje
    {
        [Key]
        public string Naam { get; set; }
        public string Description { get; set; }
        public string afbeelding { get; set; }
        public string prijs { get; set; }
        public string grootte { get; set; }
        public Boolean ijs { get; set; }
        public Boolean plasticrietje { get; set; }

    }
}
