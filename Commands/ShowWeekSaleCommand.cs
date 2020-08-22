using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutaList.Commands
{
    public class ShowWeekSaleCommand : ICommand
    {
        public AppModel Model { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SpravceAut spravceAut = new SpravceAut();

        }

        public ShowWeekSaleCommand(AppModel model)
        {
            this.Model = model;
        }


        public event EventHandler CanExecuteChanged;

    }
}
