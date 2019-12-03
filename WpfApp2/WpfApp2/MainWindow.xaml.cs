using System;
using System.Windows;
using System.Windows.Threading;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            StartCloseTimer();
            void StartCloseTimer()
            {
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(3d);
                timer.Tick += TimerTick;
                timer.Start();
            }
            void TimerTick(object sender, EventArgs e)
            {
                DispatcherTimer timer = (DispatcherTimer)sender;
                timer.Stop();
                timer.Tick -= TimerTick;
                dots.Text += ".";
                Welcome w = new Welcome();
                w.Show();
                Close();
            }
        }
    }
}
