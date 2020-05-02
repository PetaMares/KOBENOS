using System.Windows;
using System.Windows.Controls;

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

        private void konecClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
