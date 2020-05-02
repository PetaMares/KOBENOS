using kobenos.classes;
using System.Windows;
using System.Windows.Controls;

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

            CheckStatus();
        }

        private void CheckStatus()
        {
            ReportButton.IsEnabled = mainSuite.Result.IsExecuted;
        }

        public void LoadConfiguration(string configFile)
        {
            this.mainSuite = SerializationHelper.DeserializeFile<Suite>(configFile);
            CheckStatus();
            this.MainGrid.DataContext = this.mainSuite;
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;
            parentWindow.NavigateToSummaryPage();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;
            parentWindow.NavigateToWelcomePage();
        }

        private void RunAllButton_Click(object sender, RoutedEventArgs e)
        {
            this.mainSuite.Execute();
            CheckStatus();
        }

        private void RunCheckButton_Click(object sender, RoutedEventArgs e)
        {
            //this.mainSuite.execute();
            CheckStatus();
        }
    }
}
