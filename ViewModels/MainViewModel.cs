using AutaList.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutaList.ViewModels
{
    public class MainViewModel : BaseViewModel
    {



        private ObservableCollection<Auto> auta; 
        public ObservableCollection<Auto> Auta
        {
            get { return auta; }
            set 
            { 
                auta = value;
                NotifyPropertyChanged("Auta");
            }
        }

        public LoadTableCommand LoadTableCommand { get; set; } = new LoadTableCommand();




        public MainViewModel(AppModel model) : base(model)
        {
            Auto auto = new Auto();
            auto.Cena = 123.0;
            auto.CenaSDPH = 125.5;
            auto.DPH = 19;
            auto.Model = "model";
            auto.Prodano = DateTime.Now;

            this.Auta = new ObservableCollection<Auto>();
            this.Auta.Add(auto);

        }







        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
