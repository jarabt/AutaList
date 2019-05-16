﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutaList
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private SpravceAut spravceAut = new SpravceAut();



        public MainWindow()
        {
            InitializeComponent();
        }



        private void Nacist_Click(object sender, RoutedEventArgs e)
        {

            spravceAut.Nacti();
            InitializeComponent();
            AutaDataGrid.ItemsSource = spravceAut.Auta;

        }



        private void Vypocet_Click(object sender, RoutedEventArgs e)
        {

            // vyjímka pro výpočet bez načteného souboru
            try
            {
                spravceAut.Vypocti();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba - prosím načtěte .xml soubor.", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            VysledneWindow vysledneWindow = new VysledneWindow(spravceAut);
            vysledneWindow.ShowDialog();

        }

    }
}
