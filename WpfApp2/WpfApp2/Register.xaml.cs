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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=MEDHAT;Initial Catalog=mailingsystem;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("login", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@email", emailwpf.Text));
            cmd.Parameters.Add(new SqlParameter("@password", passwordwpf.Password));
            cmd.Parameters.Add(new SqlParameter("@username", usernamewpf.Text));
            cmd.Parameters.Add(new SqlParameter("@age",Convert.ToInt32( agewpf.Text)));
            if (male.IsChecked == true)
                cmd.Parameters.Add(new SqlParameter("@gender", "Male"));
            else
                cmd.Parameters.Add(new SqlParameter("@gender", "Female"));


            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("data was inserted");




        }
    }
}
