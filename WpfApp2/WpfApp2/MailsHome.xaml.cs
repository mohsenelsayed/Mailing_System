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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MailsHome.xaml
    /// </summary>
    public partial class MailsHome : Window
    {
        public MailsHome()
        {
            InitializeComponent();
      
        }

        private void Button_New(object sender, RoutedEventArgs e)
        {
            sendTo st = new sendTo();
            st.Show();
        }
    }
}
