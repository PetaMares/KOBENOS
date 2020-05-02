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
        }

        public void LoadConfiguration(string configFile)
        {
            this.mainSuite = SerializationHelper.DeserializeFile<Suite>(configFile);
            this.MainGrid.DataContext = this.mainSuite;
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
