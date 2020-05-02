using kobenos.classes;
using Microsoft.Win32;
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

namespace kobenos.pages
{
    /// <summary>
    /// Interaction logic for welcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {

        public WelcomePage()
        {
            InitializeComponent();
            ConfigFilePathTextBox.Text = System.AppDomain.CurrentDomain.BaseDirectory + "config.xml";
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;
            parentWindow.NavigateToExecutionPage(ConfigFilePathTextBox.Text);
        }

        private void VybratButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                ConfigFilePathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void CheckFile()
        {
            FileExistsCheck check = new FileExistsCheck(ConfigFilePathTextBox.Text);
            ExecutionResult result = check.Execute();
            ContinueButton.IsEnabled = result.IsSuccessful;
            FileCheckDetail.DataContext = result;
        }

        private void ConfigFilePathTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckFile();
        }

        private void EndButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
