using AutaList.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutaList.Commands
{
    public class ShowWeekendSaleCommand : ICommand
    {
        private ObservableCollection<PolozkaVysledku> vysledky;

        public AppModel Model { get; set; }




        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            WeekendSaleListMaker weekendSaleListMaker = new WeekendSaleListMaker();
            if (weekendSaleListMaker.GetList(this.Model.AutaZakladni))
                vysledky = new ObservableCollection<PolozkaVysledku>(weekendSaleListMaker.VysledkyList);

        }



        public ShowWeekendSaleCommand(AppModel appModel)
        {
            this.Model = appModel;
            
        }


        public event EventHandler CanExecuteChanged;

    }
}
