using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutaList
{
    // třída pro základní tabuklu
    public class Auto
    {
        public string Model { get; set; }
        public DateTime Prodano { get; set; }
        public double Cena { get; set; }
        public double DPH { get; set; }
        public double CenaSDPH { get; set; }
    }
}
