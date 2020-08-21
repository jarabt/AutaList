using AutaList.Bootstrap;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AutaList
{
    /// <summary>
    /// Interakční logika pro App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected async override void OnStartup(StartupEventArgs e)
        {
            IAppIoCContainerBuilderFactory appIoCContainerBuilderFactory = new AppIoCContainerBuilderFactory();
            IoC.Configure(appIoCContainerBuilderFactory);
        }
    }
}
