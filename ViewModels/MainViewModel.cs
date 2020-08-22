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
    public class MainViewModel : BaseViewModel, INotifyPropertyChanged
    {



        private ObservableCollection<Auto> auta; 
        public ObservableCollection<Auto> Auta
        {
            get { return auta; }
            set 
            { 
                auta = value;
                NotifyPropertyChanged(nameof(Auta));
            }
        }

        public LoadTableCommand LoadTableCommand { get; set; }



        private string testing = "Original";

        public string Testing
        {
            get { return testing; }
            set 
            { 
                testing = value;
                NotifyPropertyChanged(nameof(Testing));
            }
        }




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


            this.LoadTableCommand  = new LoadTableCommand(model);
            this.LoadTableCommand.TableLoaded += LoadTableCommand_TableLoaded;

        }

        private void LoadTableCommand_TableLoaded()
        {
            this.Auta = new ObservableCollection<Auto>(this.Model.AutaZakladni);
            this.Testing = "Updated";
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
