using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutaList.Commands
{
    public class LoadTableCommand : ICommand
    {
        public AppModel Model { get; set; }
        public delegate void Notify();

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SpravceAut spravceAut = new SpravceAut();
            spravceAut.Nacti();
            this.Model.AutaZakladni = spravceAut.GetList();
            OnTableLoaded();
            
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
