using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for Update.xaml
    /// </summary>
   
    public partial class Info : Window
    {
         public users u = new users();
        public Info(string val)
        {
            InitializeComponent();
            string name = val;
            string connec = "Data Source=DESKTOP-I9CKISJ;Initial Catalog=mailingsystem;Integrated Security=True";

                SqlConnection con = new SqlConnection(connec);
                 con.Open();
            string getUserData = "SELECT * FROM Users WHERE username = @name ";
            SqlCommand getuser = new SqlCommand(getUserData, con);
            getuser.Parameters.Add(new SqlParameter("@name", name));
            getuser.CommandType = System.Data.CommandType.Text;
             SqlDataReader userreader = getuser.ExecuteReader();
            while (userreader.Read())
            {
                u.name = userreader["username"];
                u.email = userreader["Email"];
                u.password = userreader["Password"];
                u.age = userreader["age"];
                u.phone = userreader["phone"];
            }
            userreader.Close();
            con.Close();
            username.Text = (u.name).ToString();
            foreach (char x in u.password.ToString())
            {
                 password.Text +='*';
            }
            age.Text = (u.age).ToString();
            phone.Text = (u.phone).ToString();
        }

        private void back_welcome(object sender, RoutedEventArgs e)
        {
            MailsHome mh = new MailsHome((u.email).ToString());
            mh.Show();
            Close();
        }

        private void Button_username(object sender, RoutedEventArgs e)
        {
            changeUsername us = new changeUsername(u.name.ToString(),u.email.ToString());
            us.Show();
        }

        private void Button_password(object sender, RoutedEventArgs e)
        {

        }

        private void Button_phone(object sender, RoutedEventArgs e)
        {

        }

        private void Button_age(object sender, RoutedEventArgs e)
        {

        }
    }
    public class users
    {
        public object name { get; internal set; }
        public object email { get; internal set; }
        public object password { get; internal set; }
        public object age { get; internal set; }
        public object phone { get; internal set; }
    }
}
