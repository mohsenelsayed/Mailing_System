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
    /// Interaction logic for changeUsername.xaml
    /// </summary>
    /// 

    public partial class changeUsername : Window
    {
        public String em;
        public changeUsername(string Name, string email)
        {
            InitializeComponent();
            username.Text = Name;
            em = email;
        }

        private void Button_cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_update(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrWhiteSpace(username.Text)) { 
                MessageBox.Show("u need to fill the username ");
            return;
        }

                string connec = "Data Source=MEDHAT;Initial Catalog=mailingsystem;Integrated Security=True";

            
            SqlConnection con = new SqlConnection(connec);
            con.Open();
            string setUserName = "updateusername";
            SqlCommand setuser = new SqlCommand(setUserName, con);
            setuser.CommandType = System.Data.CommandType.StoredProcedure;
            setuser.Parameters.Add(new SqlParameter("@newusername", username.Text));
            setuser.Parameters.Add(new SqlParameter("@email", em));
            setuser.ExecuteNonQuery();
            con.Close();
            Close();

        }
    }
}
