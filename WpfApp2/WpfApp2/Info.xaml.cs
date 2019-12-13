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
        public string connec = "Data Source=DESKTOP-I9CKISJ ;Initial Catalog=mailingsystem;Integrated Security=True";
        public string name;
        public users u = new users();
        public Info(string val)
        {
            InitializeComponent();
            name = val;
            showdata();
        }
        public event System.ComponentModel.CancelEventHandler Closing;

        private void back_welcome(object sender, RoutedEventArgs e)
        {
            MailsHome mh = new MailsHome((u.email).ToString());
            mh.Show();
            Close();
        }
        
     
        private void child_Closed(object sender, EventArgs e)
        {
            showdata();
        }

        public void showdata()
        {

            SqlConnection con = new SqlConnection(connec);
            con.Open();
            string getUserData = "showuserinfo";
            SqlCommand getuser = new SqlCommand(getUserData, con);
            getuser.Parameters.Add(new SqlParameter("@email", name));
            getuser.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader userreader = getuser.ExecuteReader();
            while (userreader.Read())
            {
                u.name = userreader["username"];
                u.password = userreader["Password"];
                u.age = userreader["age"];
                u.phone = userreader["phone"];
            }
            u.email = name;

            userreader.Close();
            con.Close();
            username.Text = newUserName.Text = (u.name).ToString();
            password.Text = "";
            foreach (char x in u.password.ToString())
            {
                password.Text += '*';
            }
            newPassword.Text = u.password.ToString();
            age.Text = newAge.Text = (u.age).ToString();
            phone.Text = newPhone.Text = (u.phone).ToString();


        }

        private void Button_Update(object sender, RoutedEventArgs e)
        {
            u.name = newUserName.Text;
            u.password = newPassword.Text;
            u.age = newAge.Text;
            u.phone = newPhone.Text;


            SqlConnection con = new SqlConnection(connec);
            con.Open();
            string updateUserData = "updateall";
            SqlCommand updateuser = new SqlCommand(updateUserData, con);
            updateuser.CommandType = System.Data.CommandType.StoredProcedure;
            updateuser.Parameters.Add(new SqlParameter("@email", u.email));
            updateuser.Parameters.Add(new SqlParameter("@newpassword ", u.password));
            updateuser.Parameters.Add(new SqlParameter("@newusername", u.name));
            updateuser.Parameters.Add(new SqlParameter("@newphone", u.phone));
            updateuser.Parameters.Add(new SqlParameter("@newage", u.age));
            updateuser.ExecuteNonQuery();
            con.Close();
            showUpdate();
        }
        public void showUpdate()
        {
            username.Text = newUserName.Text = (u.name).ToString();
            password.Text = "";
            foreach (char x in u.password.ToString())
            {
                password.Text += '*';
            }
            newPassword.Text = u.password.ToString();
            age.Text = newAge.Text = (u.age).ToString();
            phone.Text = newPhone.Text = (u.phone).ToString();
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
