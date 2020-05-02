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
        string configFile;
        bool startExecution;
        Suite mainSuite;

        public ExecutionPage(string configFile, bool startExecution)
        {
            this.configFile = configFile;
            this.startExecution = startExecution;
            InitializeComponent();

            this.mainSuite = SerializationHelper.DeserializeFile<Suite>(configFile);
            this.categoryTree.ItemsSource = this.mainSuite.checks;
        }

        private void reportClick(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.navigate(new summaryPage());
            }
        }
    }
}
