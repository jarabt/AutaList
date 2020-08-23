using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutaList.ViewModels
{
    public class VysledneWindowViewModel : BaseViewModel, INotifyPropertyChanged
    {

        private ObservableCollection<PolozkaVysledku> vysledky;
        public ObservableCollection<PolozkaVysledku> Vysledky
        {
            get { return vysledky; }
            set
            {
                vysledky = value;
                NotifyPropertyChanged(nameof(Vysledky));
            }
        }

        public VysledneWindowViewModel(AppModel model) : base(model)
        {
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
