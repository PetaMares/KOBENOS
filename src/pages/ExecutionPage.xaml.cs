using kobenos.classes;
using kobenos.controls;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace kobenos
{
    /// <summary>
    /// Interaction logic for executionPage.xaml
    /// </summary>
    public partial class ExecutionPage : Page
    {

        public ExecutionPage()
        {
            InitializeComponent();

            RefreshButtons();
        }

        public static readonly DependencyProperty MainSuiteProperty =
            DependencyProperty.Register(
                "MainSuite",
                typeof(Suite),
                typeof(ExecutionPage),
                new FrameworkPropertyMetadata(null)
        );

        public AbstractCheck MainSuite
        {
            get { return (AbstractCheck)GetValue(MainSuiteProperty); }
            set
            {
                SetValue(MainSuiteProperty, value);
            }
        }

        public static readonly DependencyProperty SelectedCheckProperty =
            DependencyProperty.Register(
                "SelectedCheck",
                typeof(AbstractCheck),
                typeof(ExecutionPage),
                new FrameworkPropertyMetadata(null)
        );

        public AbstractCheck SelectedCheck
        {
            get { return (AbstractCheck)GetValue(SelectedCheckProperty); }
            set
            {
                SetValue(SelectedCheckProperty, value);
            }
        }

        private void RefreshTree()
        {
            AbstractCheck suite = MainSuite;
            MainSuite = null;
            MainSuite = suite;
        }

        private void RefreshButtons()
        {
            ReportButton.IsEnabled = MainSuite != null && MainSuite.Result.IsExecuted;
            RunCheckButton.IsEnabled = SelectedCheck != null;
        }

        public bool LoadConfiguration(string configFile)
        {
            this.MainSuite = SerializationHelper.DeserializeFile<Suite>(configFile);
            if (this.MainSuite != null)
            {
                RefreshButtons();
                this.MainGrid.DataContext = this.MainSuite;
                return true;
            }
            else 
            {
                return false;
            }
        }
        
        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;
            parentWindow.NavigateToSummaryPage(this.MainSuite.Result);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;
            parentWindow.NavigateToWelcomePage();
        }

        private void RunCheck(AbstractCheck check)
        {
            WaitWindow.Show(async progress =>
            {
                progress.Report("running...");
                check.Execute();
                progress.Report("finished");
            });
        }

        private void RunAllButton_Click(object sender, RoutedEventArgs e)
        {
            RunCheck(this.MainSuite);
            RefreshTree();
            RefreshButtons();
        }

        private void RunCheckButton_Click(object sender, RoutedEventArgs e)
        {
            RunCheck(this.SelectedCheck);
            RefreshTree();
            RefreshButtons();
        }

        private void MainSuiteTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SelectedCheck = (AbstractCheck)e.NewValue;
            RefreshButtons();
        }
    }
}
