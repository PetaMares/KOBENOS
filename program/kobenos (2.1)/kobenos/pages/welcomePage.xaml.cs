﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kobenos
{
    /// <summary>
    /// Interaction logic for welcomePage.xaml
    /// </summary>
    public partial class welcomePage : Page
    {
        public static string nameFile;
        public welcomePage()
        {
            InitializeComponent();

            ConfigFilePathTextBox.Text = System.AppDomain.CurrentDomain.BaseDirectory + "konfigurace_testu.csv";
        }

        private void startButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                if (StartExecution.IsChecked == true)
                {
                    parentWindow.navigate(new executionPage(ConfigFilePathTextBox.Text, true));
                }
                else
                {
                    parentWindow.navigate(new executionPage(ConfigFilePathTextBox.Text, false));
                }
            }
        }

        private void vybratButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                ConfigFilePathTextBox.Text = openFileDialog.FileName;
                nameFile = openFileDialog.FileName;
            }
        }
    }
}
