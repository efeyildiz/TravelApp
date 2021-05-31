using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelApp.Models
{
    public class Otel
    {
        public int OtelId { get; set; }
        public string otelAd { get; set; }
        public string otelTel { get; set; }
        public string otelAdres { get; set; }
        public string otelImage { get; set; }
        public string otelAciklama { get; set; }
        public double otelPuan { get ; set; }

        public int SehirId { get; set; }
        public Sehir Sehir { get; set; }
    }
}
