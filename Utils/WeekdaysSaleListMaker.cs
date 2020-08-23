using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutaList.Utils
{
    public class WeekdaysSaleListMaker
    {
        public IList<PolozkaVysledku> VysledkyList { get; set; }
        public bool GetList(IList<Auto> autaZakladni)
        {
            if (autaZakladni != null)
            {
                this.VysledkyList = autaZakladni
                .Where(p => ((p.Prodano.DayOfWeek == DayOfWeek.Monday) || (p.Prodano.DayOfWeek == DayOfWeek.Tuesday) || (p.Prodano.DayOfWeek == DayOfWeek.Wednesday) || (p.Prodano.DayOfWeek == DayOfWeek.Thursday) || (p.Prodano.DayOfWeek == DayOfWeek.Friday)))
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
