using kobenos.classes;
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
    /// Interaction logic for executionPage.xaml
    /// </summary>
    public partial class ExecutionPage : Page
    {
        Suite mainSuite;

        public ExecutionPage()
        {
            InitializeComponent();
        }

        public void LoadConfiguration(string configFile)
        {
            this.mainSuite = SerializationHelper.DeserializeFile<Suite>(configFile);
            this.MainGrid.DataContext = this.mainSuite;
            this.MainSuiteTree.ItemsSource = this.mainSuite.Checks;
        }

        private void reportClick(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;
            parentWindow.NavigateToSummaryPage();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;
            parentWindow.NavigateToWelcomePage();
        }
    }
}
