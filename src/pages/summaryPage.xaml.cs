using System.Windows;
using System.Windows.Controls;
using kobenos.classes;

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;

namespace kobenos.pages
{
    /// <summary>
    /// Interaction logic for summaryPage.xaml
    /// </summary>
    public partial class SummaryPage : Page
    {
        private ExecutionResult result;

        public SummaryPage()
        {
            InitializeComponent();
        }

        public void SetResult(ExecutionResult result)
        {
            this.result = result;
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

        private void GenerateReportButton_Click(object sender, RoutedEventArgs e)
        {
            //Create a new PDF document
            PdfDocument document = new PdfDocument();

            //Add a page to the document
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;

            //Set the standard font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

            //Draw the text
            graphics.DrawString(this.result.Name, font, PdfBrushes.Black, new PointF(0, 0));

            FileStream fileStreamResult = new FileStream("pdf.pdf", FileMode.CreateNew);

            document.Save(fileStreamResult);                     
            fileStreamResult.Close();
        }
    }
}
