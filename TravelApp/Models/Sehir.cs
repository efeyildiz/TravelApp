using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelApp.Models
{
    public class Sehir
    {
        public int SehirId { get; set; }
        public int Plaka { get; set; }
        public string sehirAd { get; set; }

        public List<Otel> Otels { get; set; }
        public List<Lokanta> Lokantas { get; set; }
    }
}
