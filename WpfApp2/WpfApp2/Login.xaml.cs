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
    public partial class Login : Page
    {
        public string connec = "Data Source=DESKTOP-ITEONSL\\RAY;Initial Catalog=mailingsystem;Integrated Security=True";
        public Login()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Emailwpf.Text == "")
            {
                Errors.Visibility = Visibility.Visible;
                Errors.Text = "You didn't input your email";
               
                return;
            }
            if (passwordwpf.Password == "")
            {
                Errors.Visibility = Visibility.Visible;
                Errors.Text = "You didn't input your password";
         
                return;
            }

            SqlConnection con = new SqlConnection(connec);
            con.Open();


            SqlCommand cmd = new SqlCommand("login", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@email", Emailwpf.Text));
            cmd.Parameters.Add(new SqlParameter("@password", passwordwpf.Password));

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 1)
            {
                string x = Emailwpf.Text;
                MailsHome mh = new MailsHome(x);
                var w = Window.GetWindow(this);
                mh.Show();
                w.Close();

            }
            else
            {
                SqlCommand checkemail = new SqlCommand("check_email_is_in_the_system", con);
                checkemail.CommandType = CommandType.StoredProcedure;

                checkemail.Parameters.Add(new SqlParameter("@email", Emailwpf.Text));

                int emailcount = Convert.ToInt32(checkemail.ExecuteScalar());

                if (emailcount == 1)
                {
                    Errors.Visibility = Visibility.Visible;
                    Errors.Text = "Wrong Password Entered";
                
                }

                else
                {
                    Errors.Visibility = Visibility.Visible;
                    Errors.Text = "This email doesn't exist";
               
                }
            }
            con.Close();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Uri uri = new Uri("Register.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
