using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutaList.Utils
{
    public class WeekendSaleListMaker
    {
        
        public IList<PolozkaVysledku> VysledkyList { get; set; }
        public bool GetList(IList<Auto> autaZakladni)
        {
            if (autaZakladni != null)
            {
                this.VysledkyList = autaZakladni
                .Where(p => ((p.Prodano.DayOfWeek == DayOfWeek.Saturday) || (p.Prodano.DayOfWeek == DayOfWeek.Sunday)))
                .GroupBy(p => p.Model,
                (key, g) => new PolozkaVysledku
                {
                    Model = key,
                    CenaCelkem = g.Sum(p => p.Cena),
                    CenaCelkemDPH = g.Sum(p => p.CenaSDPH),
                })
                .ToList();

                return true;
            }
            else
                return false;
        }
    }
}
