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
    public class ShowWeekdaysSaleCommand : ICommand
    {
        public AppModel Model { get; set; }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            WeekdaysSaleListMaker weekdaysSaleListMaker = new WeekdaysSaleListMaker();

            if (weekdaysSaleListMaker.GetList(this.Model.AutaZakladni))
            {
                VysledneWindow vysledneWindow = new VysledneWindow();
                VysledneWindowViewModel vysledneWindowViewModel = IoC.Resolve<VysledneWindowViewModel>();
                vysledneWindowViewModel.Vysledky = new ObservableCollection<PolozkaVysledku>(weekdaysSaleListMaker.VysledkyList);
                vysledneWindowViewModel.Title = "Všední dny";
                vysledneWindow.DataContext = vysledneWindowViewModel;
                vysledneWindow.ShowDialog();

            }
        }

        public ShowWeekdaysSaleCommand(AppModel model)
        {
            this.Model = model;
        }



        public event EventHandler CanExecuteChanged;

    }
}
