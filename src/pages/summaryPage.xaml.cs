using System.Windows;
using System.Windows.Controls;
using kobenos.classes;

namespace kobenos.pages
{
    /// <summary>
    /// Interaction logic for summaryPage.xaml
    /// </summary>
    public partial class SummaryPage : Page
    {
        public SummaryPage()
        {
            InitializeComponent();
        }

        public void SetResult(ExecutionResult result)
        {
            MainResult.DataContext = result;
        }

        private void konecClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;
            parentWindow.NavigateToExecutionPage();
        }
    }
}
