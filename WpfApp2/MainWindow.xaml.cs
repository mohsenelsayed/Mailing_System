using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;
namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        BackgroundWorker worker;
        public MainWindow()
        {
            InitializeComponent();
        }
        Welcome w = new Welcome();
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            long sum = 0;
            long total = 29999;
            for (long i = 1; i <= total; i++)
            {
                sum += i;
                int percentage = Convert.ToInt32(((double)i / total) * 100);

                Dispatcher.Invoke(new System.Action(() =>
                {
                    worker.ReportProgress(percentage);
                }));
            }
            Dispatcher.Invoke(new System.Action(() =>
            {
                w.Show();
                Close();
            }));
        }
        void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MyProgressBar.Value = e.ProgressPercentage;
        }
        private void PerformTask_Click(object sender, RoutedEventArgs e)
        {
            MyProgressBar.Visibility = Visibility.Visible; //Make Progressbar visible
            PerformTask.IsEnabled = false; //Disabling the button
            worker = new BackgroundWorker(); //Initializing the worker object
            worker.ProgressChanged += Worker_ProgressChanged; //Binding Worker_ProgressChanged method
            worker.DoWork += Worker_DoWork; //Binding Worker_DoWork method
            worker.WorkerReportsProgress = true; //telling the worker that it supports reporting progress
            worker.RunWorkerAsync(); //Executing the worker
        }
    }
}
