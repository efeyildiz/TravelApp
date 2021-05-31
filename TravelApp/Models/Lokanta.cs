using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelApp.Models
{
    public class Lokanta
    {
        public int LokantaId { get; set; }
        public string lokantaAd { get; set; }
        public string lokantaTel { get; set; }
        public double lokantaPuan { get; set; }
        public string lokantaAdres { get; set; }
        public string lokantaAciklama { get; set; }
        public string lokantaImage { get; set; }

        public int SehirId { get; set; }
        public Sehir Sehir { get; set; }
    }
}
