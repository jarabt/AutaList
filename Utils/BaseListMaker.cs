﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace AutaList.Utils
{
    public class BaseListMaker
    {
        public IList<Auto> AutaZakladni { get; set; }
        public bool GetList(XDocument auta)
        {
           

                // převod xml souboru do listu pro zobrazení základní tabulky
                AutaZakladni = auta.Root.Descendants("auto")
                    .Select(p => new Auto
                    {
                        Model = p.Attribute("model").Value,
                        Prodano = Convert.ToDateTime(p.Element("prodano").Value),
                        Cena = Convert.ToDouble(p.Element("cena").Value),
                        DPH = Convert.ToDouble(p.Element("dph").Value),

                    }).ToList();

                foreach (Auto a in AutaZakladni)
                {
                    a.CenaSDPH = (a.Cena + a.Cena * (a.DPH / 100));
                }

                // chybové hlášení pro načtení špatného nebo poškozeného xml souboru 
                bool isEmpty = !AutaZakladni.Any();
                if (isEmpty)
                {
                    MessageBox.Show("Zdrojový list je prázdný", "Chyba - .xml soubor není pravděpodobně správný (v pořádku).", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
                }

            return true;
            
        }
            

    }
}
