using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace kobenos.controls
{
    /// <summary>
    /// Interaction logic for WaitWindow.xaml
    /// </summary>
    public partial class WaitWindow : Window
    {
        public WaitWindow()
        {
            InitializeComponent();
                        
        }

        public static readonly DependencyProperty ProgressTextProperty =
            DependencyProperty.Register(
                "ProgressText",
                typeof(string),
                typeof(WaitWindow),
                new FrameworkPropertyMetadata(null)
        );

        public string ProgressText
        {
            get { return (string)GetValue(ProgressTextProperty); }
            set
            {
                SetValue(ProgressTextProperty, value);
            }
        }

        public static void Show(Func<IProgress<string>, Task> workAsync)
        {
            var progressWindow = new WaitWindow();
            progressWindow.Owner = Application.Current.MainWindow;            
            Progress<string> progress = new Progress<string>(text => progressWindow.ProgressText = text);
            BackgroundWorker worker = new BackgroundWorker();
                       
            worker.DoWork += (s, workerArgs) => workAsync(progress);

            worker.RunWorkerCompleted +=
                (s, workerArgs) => progressWindow.Close();
                
            progressWindow.Loaded += (s, e) =>
            {
                worker.RunWorkerAsync();
            };

            progressWindow.ShowDialog();
            Application.Current.MainWindow.Focus();
        }
    }
}
