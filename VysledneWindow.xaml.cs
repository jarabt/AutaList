﻿using AutaList.Bootstrap;
using AutaList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AutaList
{
    /// <summary>
    /// Interakční logika pro VysledneWindow.xaml
    /// </summary>
    public partial class VysledneWindow : Window
    {

        private SpravceAut spravceAut;

        public VysledneWindow()
        {
            //VysledneWindowViewModel vysledneWindowViewModel = IoC.Resolve<VysledneWindowViewModel>();
            //this.DataContext = vysledneWindowViewModel;
            InitializeComponent();
        }

        //public VysledneWindow(SpravceAut spravceAut)
        //{
        //    InitializeComponent();
        //    this.spravceAut = spravceAut;
        //    VysledkyDataGrid.ItemsSource = spravceAut.Vysledky;
        //}

    }
}
