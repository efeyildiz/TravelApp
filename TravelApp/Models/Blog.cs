using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelApp.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string BlogTittle { get; set; }
        public string BlogDescription { get; set; }
        public string BlogImage { get; set; }
        public string BlogBody { get; set; }

        public bool isShared { get; set; }
        public bool isSlider { get; set; }
    }
}
