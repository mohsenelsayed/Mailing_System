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
using Microsoft.Win32;
using System.IO;
using System.Windows.Navigation;
using System.Data;
using System.Drawing.Imaging;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Update.xaml
    /// </summary>

    public partial class Info : Window
    {
        public string connec = "Data Source=DESKTOP-ITEONSL\\RAY;Initial Catalog=mailingsystem;Integrated Security=True";
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
            username.Text = newUserName.Text = (u.name).ToString();
            password.Text = "";
            foreach (char x in u.password.ToString())
            {
                password.Text += '*';
            }
            newPassword.Text = u.password.ToString();
            age.Text = newAge.Text = (u.age).ToString();
            phone.Text = newPhone.Text = (u.phone).ToString();



            SqlCommand sc = new SqlCommand("select imgdata from Users where email=@email", con);
            sc.CommandType = System.Data.CommandType.Text;
            sc.Parameters.Add(new SqlParameter("@email", name));
            SqlDataReader reader = sc.ExecuteReader();
            while (reader.Read())
            {
                if (String.IsNullOrWhiteSpace(reader["imgdata"].ToString()))
                    return;

                byte[] data = (byte[])reader["imgdata"];
                MemoryStream strm = new MemoryStream();
                strm.Write(data, 0, data.Length);
                strm.Position = 0;
                System.Drawing.Image img = System.Drawing.Image.FromStream(strm);
                BitmapImage bi = new BitmapImage();

                bi.BeginInit();

                MemoryStream ms = new MemoryStream();

                img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                ms.Seek(0, SeekOrigin.Begin);

                bi.StreamSource = ms;

                bi.EndInit();

                im.Source = bi;


            }
            reader.Close();
            con.Close();

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

        private void Button_browse(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select a picture";
            dlg.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (dlg.ShowDialog() == true)
            {
                im.Source = new BitmapImage(new Uri(dlg.FileName));
            }
            FileStream fs = new FileStream(dlg.FileName, FileMode.Open,
             FileAccess.Read);
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();

            SqlConnection con = new SqlConnection(connec);
            con.Open();
            SqlCommand sc = new SqlCommand("update Users set imgdata=@p,imgname=@n where email=@email", con);
            sc.CommandType = System.Data.CommandType.Text;

            sc.Parameters.AddWithValue("@email", name);

            sc.Parameters.AddWithValue("@p", data);
            sc.Parameters.AddWithValue("@n", "pic");
            sc.ExecuteNonQuery();

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
