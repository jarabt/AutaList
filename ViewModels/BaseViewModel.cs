using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutaList.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public virtual AppModel Model { get; set; }
        public BaseViewModel(AppModel model)
        {
            this.Model = model;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
