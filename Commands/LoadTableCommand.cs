using AutaList.Utils;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace AutaList.Commands
{
    public class LoadTableCommand : ICommand
    {
        private XDocument auta;
        
        public AppModel Model { get; set; }        
        public delegate void Notify();

        public bool CanExecute(object parameter)
        {           
                return true;           
        }

        public void Execute(object parameter)
        {
            OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
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

                auta = XDocument.Load(filename);
            }

            if (auta != null)
            {
                this.Model.AutaZakladni = new BaseListMaker().GetList(auta);
                OnTableLoaded();
            }

            //SpravceAut spravceAut = new SpravceAut();
            //spravceAut.Nacti();
            //this.Model.AutaZakladni = spravceAut.GetBaseList();
            //OnTableLoaded();

        }

        public LoadTableCommand(AppModel model)
        {
            this.Model = model;

        }

        private void OnTableLoaded()
        {
            TableLoaded?.Invoke();
        }

        public event EventHandler CanExecuteChanged;
        public event Notify TableLoaded;

    }
}
