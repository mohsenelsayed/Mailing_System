using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Media;
using System.Configuration;

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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-ITEONSL\\RAY;Initial Catalog=mailingsystem;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("login", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@email", Emailwpf.Text));
            cmd.Parameters.Add(new SqlParameter("@password", passwordwpf.Password));

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 1)
                MessageBox.Show("User Exists");
            else
                MessageBox.Show("User DOES NOT Exists");
            con.Close();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Register w = new Register();
            w.Show();
            Close();
        }
    }
}
