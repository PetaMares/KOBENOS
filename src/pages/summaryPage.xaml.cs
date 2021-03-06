﻿using System.Windows;
using System.Windows.Controls;
using kobenos.classes;

using SelectPdf;
using System.IO;
using Microsoft.Win32;
using System.Text;
using kobenos.controls;

namespace kobenos.pages
{
    /// <summary>
    /// Interaction logic for summaryPage.xaml
    /// </summary>
    public partial class SummaryPage : Page
    {
        private Suite result;
        private string ConfigFile;

        public SummaryPage()
        {
            InitializeComponent();
        }

        public void SetResult(Suite result, string configFilePath)
        {
            this.result = result;
            this.ConfigFile = configFilePath;
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
            if(Tester.Text.Length == 0 || Tested.Text.Length == 0)
            {
                MessageBox.Show("Nebyla vyplněna požadovaná textová pole. Prosím vyplňte je.");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";

            
                
            if (saveFileDialog.ShowDialog() == true)
            {
                string testerName = Tester.Text;
                string testedName = Tested.Text;

                WaitWindow.Show(async progress =>
                {
                    progress.Report(new WaitWindow.WaitWindowProgress("Startuji proces tvorby PDF reportu", 0));

                    HtmlToPdf converter = new HtmlToPdf();
                    converter.Options.PdfPageSize = PdfPageSize.A4;
                    converter.Options.MarginBottom = 72;
                    converter.Options.MarginLeft = 72;
                    converter.Options.MarginRight = 72;
                    converter.Options.MarginTop = 72;

                    progress.Report(new WaitWindow.WaitWindowProgress("Vytvářím podklad pro tvorbu PDF reportu", 30));

                    // convert the url to pdf
                    string header = "<h1>KOntrola BEzpečnostního Nastavení Operačního Systému</h1>\n";
                    string tester = "<h2>Testující: " + testerName + "</h2>";
                    string tested = "<h2>Testovaný: " + testedName + "</h2>";
                    string start = "<h2>Čas startu testu: " + this.result.StartTime + "</h2>";
                    string end = "<h2>Čas konce testu: " + this.result.EndTime + "</h2>";
                    string result = $"<h2>Výsledek: {this.result.Result.Name} - {this.result.Result.Details}</h2>";
                    string config = "<h2>Konfigurační soubor: " + this.ConfigFile + "</h2>";
                    string testResult = "<h2>Tests results:</h2>";

                    var sb = new StringBuilder(header + tester + tested + start + end + result + config + testResult);

                    AppendCheck(this.result, sb);

                    progress.Report(new WaitWindow.WaitWindowProgress("Vytvářím PDF report", 60));

                    PdfDocument doc = converter.ConvertHtmlString(sb.ToString());

                    progress.Report(new WaitWindow.WaitWindowProgress("Ukládám PDF report", 90));

                    // save pdf document
                    doc.Save(saveFileDialog.FileName);

                    // close pdf document
                    doc.Close();
                }, false);
            }

        }

        private void AppendCheck(AbstractCheck check, StringBuilder stringBuilder)
        {
            stringBuilder.Append($"<li>{check.Name} - {check.Result.Name} - {check.Result.Details}");
            if(check is Suite suite)
            {
                stringBuilder.Append("<ul>");
                foreach (var childCheck in suite.Checks)
                {
                    AppendCheck(childCheck, stringBuilder);
                }
                stringBuilder.Append("</ul>");
            }
            stringBuilder.Append("</li>");
        }
    }
}
