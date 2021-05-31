using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelApp.Models
{
    public class Soru
    {
        public int SoruId { get; set; }
        public string soruTittle { get; set; }
        public string soruBody { get; set; }
        public string Cevap { get; set; }
    }
}
