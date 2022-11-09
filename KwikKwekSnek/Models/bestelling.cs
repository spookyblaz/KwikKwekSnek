using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KwikKwekSnek.Models
{
    public class Bestelling
    {
        [Key]
        public int bestellingsnummer { get; set; }
        public List<Drankjehasextra> besteldedrankjes { get; set; }
        public int snacks { get; set; }
        public int status { get; set; }

    }
}
