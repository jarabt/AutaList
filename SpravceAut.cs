using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace AutaList
{
    // logika programu

    public class SpravceAut
    {
        public ObservableCollection<Auto> Auta { get; set; }                    // kolekce pro zobrazení základní tabulky 
        public ObservableCollection<PolozkaVysledku> Vysledky { get; set; }     // kolekce pro zobrazení výsledků

        private List<Auto> autaZakladni;                            // list zobrazení základní tabulky 

        public void Nacti()
        {
            // nastavení dialogu pro otevření souboru
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // přednastavené jméno souboru
            dlg.DefaultExt = ".xml"; // přednastavená přípona souboru
            dlg.Filter = "Xml documents (.xml)|*.xml"; // filter soubotů podle přípony

            // ukaž dialogové okno pro otevření souboru
            Nullable<bool> result = dlg.ShowDialog();

            // výsledek dialogového okna pro otevření souborů
            if (result == true)
            {

                // otevření dokumentu
                string filename = dlg.FileName;

                // Vyjímka pro úspěšné načtení správného dokumentu 
                try
                {
                    XDocument.Load(filename);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Chyba - načtěte prosím .xml soubor.", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }

                var auta = XDocument.Load(filename);

                // převod xml souboru do listu pro zobrazení základní tabulky
                autaZakladni = auta.Root.Descendants("auto")
                    .Select(p => new Auto
                    {
                        Model = p.Attribute("model").Value,
                        Prodano = Convert.ToDateTime(p.Element("prodano").Value),
                        Cena = Convert.ToDouble(p.Element("cena").Value),
                        DPH = Convert.ToDouble(p.Element("dph").Value),

                    }).ToList();

                foreach (Auto a in autaZakladni)
                {
                    a.CenaSDPH = (a.Cena + a.Cena * (a.DPH / 100));
                }

                // chybové hlášení pro načtení špatného nebo poškozeného xml souboru 
                bool isEmpty = !autaZakladni.Any();
                if (isEmpty)
                {
                    MessageBox.Show("Zdrojový list je prázdný", "Chyba - .xml soubor není pravděpodobně správný (v pořádku).", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }

                // převod listu do kolekce, která slouží jako zdroj pro zobrazení základní tabulky
                Auta = new ObservableCollection<Auto>(autaZakladni);
            }
        }



        public void Vypocti()
        {
            List<PolozkaVysledku> vysledkyList = autaZakladni
                .Where(p => ((p.Prodano.DayOfWeek == DayOfWeek.Saturday) || (p.Prodano.DayOfWeek == DayOfWeek.Sunday)))
                .GroupBy(p => p.Model,
                (key, g) => new PolozkaVysledku
                {
                    Model = key,
                    CenaCelkem = g.Sum(p => p.Cena),
                    CenaCelkemDPH = g.Sum(p => p.CenaSDPH),
                })
                .ToList();

            // vytvoření kolekce pro zobrazení výsledků
            Vysledky = new ObservableCollection<PolozkaVysledku>(vysledkyList);
        }

        public IList<Auto> GetList()
        {
            return autaZakladni;
        }


    }

}

