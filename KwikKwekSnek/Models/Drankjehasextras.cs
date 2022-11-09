using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KwikKwekSnek.Models
{
    public class Drankjehasextra
    {
        [Key]
        public int ID { get; set; }
        public Drankje Drankje { get; set; }
        public Extrasdrankje Extrasdrankje { get; set; }

    }
}
