using kobenos.pages;
using kobenos.classes;
using System;
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

namespace kobenos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WelcomePage welcomePage;

        public WelcomePage WelcomePage {  get
            {
                if (this.welcomePage == null)
                {
                     this.welcomePage = new WelcomePage();
                }
                return this.welcomePage;
            } 
        }

        ExecutionPage executionPage;

        public ExecutionPage ExecutionPage
        {
            get
            {
                if (this.executionPage == null)
                {
                    this.executionPage = new ExecutionPage();
                }
                return this.executionPage;
            }
        }

        SummaryPage summaryPage;

        public SummaryPage SummaryPage
        {
            get
            {
                if (this.summaryPage == null)
                {
                    this.summaryPage = new SummaryPage();
                }
                return this.summaryPage;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.NavigateToWelcomePage();
        }

        private void navigate(Page page)
        {
            MainContent.Content = page;
        }

        public void NavigateToWelcomePage()
        {
            this.navigate(this.WelcomePage);
        }

        public void NavigateToExecutionPage(string configFile)
        {
            this.ExecutionPage.LoadConfiguration(configFile);
            this.navigate(this.ExecutionPage);
        }

        public void NavigateToExecutionPage()
        {
            this.navigate(this.ExecutionPage);
        }

        public void NavigateToSummaryPage()
        {
            this.navigate(this.SummaryPage);
        }

        public void NavigateToSummaryPage(ExecutionResult result)
        {
            this.SummaryPage.SetResult(result);
            this.navigate(this.SummaryPage);
        }
    }
}
