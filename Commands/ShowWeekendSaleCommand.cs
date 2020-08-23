using AutaList.Bootstrap;
using AutaList.Utils;
using AutaList.ViewModels;
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
            {
                VysledneWindow vysledneWindow = new VysledneWindow();
                VysledneWindowViewModel vysledneWindowViewModel = IoC.Resolve<VysledneWindowViewModel>();
                vysledneWindowViewModel.Vysledky = new ObservableCollection<PolozkaVysledku>(weekendSaleListMaker.VysledkyList);
                vysledneWindow.DataContext = vysledneWindowViewModel;
                vysledneWindow.ShowDialog();
                
            }
        }



        public ShowWeekendSaleCommand(AppModel appModel)
        {
            this.Model = appModel;
            
        }


        public event EventHandler CanExecuteChanged;

    }
}
