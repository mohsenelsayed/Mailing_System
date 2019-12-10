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
   
    public partial class Update : Window
    {
        public Update(string val)
        {
            InitializeComponent();
            string name = val;
            users u = new users();
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
            email.Text = (u.email).ToString();
            password.Text = (u.password).ToString();
            
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
