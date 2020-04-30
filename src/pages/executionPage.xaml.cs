using kobenos.category;
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
    public partial class executionPage : Page
    {
        string csvFile;
        bool startExecution;
        InitializeTests tests = new InitializeTests();

        public executionPage(string csvFile, bool startExecution)
        {
            this.csvFile = csvFile;
            this.startExecution = startExecution;
            InitializeComponent();
            List<Category> categories = tests.initilize();
            categoryTree.ItemsSource = categories;
            if(startExecution)
            {
                foreach(Category category in categories)
                {
                    category.execute();
                }
            }
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
