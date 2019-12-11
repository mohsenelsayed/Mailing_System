using System.Windows;


namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public Welcome()
        {
            InitializeComponent();
            welcome.Content = new Login();
        }

    }
}
