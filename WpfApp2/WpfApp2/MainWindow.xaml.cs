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
            StartCloseTimer();
        }
        Welcome w = new Welcome();
        private void StartCloseTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(4d);
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
            timer.Tick -= TimerTick;
            w.Show();
            Close();
        }
    }
}
