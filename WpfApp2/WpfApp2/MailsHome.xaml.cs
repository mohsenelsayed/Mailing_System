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
using System.IO;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MailsHome.xaml
    /// </summary>
    public partial class MailsHome : Window
    {
        public string connec = "Data Source=DESKTOP-I9CKISJ ;Initial Catalog=mailingsystem;Integrated Security=True";

        public string str;
        public string lastfun;
 
        public MailsHome(string val)
        {
            InitializeComponent();
            str = val;

            shownameimg();
            get_sent();
            get_spam();
            get_drafts();

            Button_inbox(new object(), new RoutedEventArgs());


        }

        public void shownameimg ()
        {
            SqlConnection con = new SqlConnection(connec);
            con.Open();

            SqlCommand showuser = new SqlCommand("showusername", con);
            showuser.CommandType = CommandType.StoredProcedure;
            showuser.Parameters.Add(new SqlParameter("@email", str));
            SqlDataReader userreader = showuser.ExecuteReader();
            while (userreader.Read())
                usernamewpf.Text = "Welcome back , " + (userreader["username"].ToString()); ;
            userreader.Close();



            SqlCommand sc = new SqlCommand("select imgdata from Users where email=@email", con);
            sc.CommandType = System.Data.CommandType.Text;
            sc.Parameters.Add(new SqlParameter("@email", str));
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
        private void get_inbox ()
        {
            SqlConnection con = new SqlConnection(connec);
            con.Open();
            SqlCommand num = new SqlCommand("msgnum", con);
            num.CommandType = CommandType.StoredProcedure;
            num.Parameters.Add(new SqlParameter("@email", str));
            

               int count = Convert.ToInt32(num.ExecuteScalar());
            con.Close();
            
            btnInbox.Content = "Inbox (" + count + ")";
        }

        private void get_drafts()
        {
            SqlConnection con = new SqlConnection(connec);
            con.Open();



            SqlCommand num = new SqlCommand("msgdraftnum", con);
            num.CommandType = CommandType.StoredProcedure;
            num.Parameters.Add(new SqlParameter("@email", str));
            
            int count = Convert.ToInt32(num.ExecuteScalar());
            con.Close();
           btnDraft.Content = "Drafts (" + count + ")";
        }

        public void get_sent()
        {
            SqlConnection con = new SqlConnection(connec);
            con.Open();


            SqlCommand num = new SqlCommand("msgnumsent", con);
            num.CommandType = CommandType.StoredProcedure;
            num.Parameters.Add(new SqlParameter("@email", str));
            int count = Convert.ToInt32(num.ExecuteScalar());
          
            con.Close();
          btnSent.Content = "Sent (" + count + ")";


        }
        private void get_spam()
        {
            SqlConnection con = new SqlConnection(connec);
            con.Open();


            SqlCommand num = new SqlCommand("msgspamnum", con);
            num.CommandType = CommandType.StoredProcedure;
            num.Parameters.Add(new SqlParameter("@email", str));
            int count = Convert.ToInt32(num.ExecuteScalar());
            con.Close();
            btnSpam.Content = "Spam (" + count + ")";
        }

        private void Button_New(object sender, RoutedEventArgs e)
        {
            sendTo st = new sendTo(str);
            st.Show();

            st.Closed += child_Closed;

        }

        private void child_Closed(object sender, EventArgs e)
        {
            get_sent();
            get_spam();
            get_drafts();

            if (lastfun == "inbox")
            {
                Button_inbox(new object(), new RoutedEventArgs());
            }



            else if (lastfun == "spam")
            {
                Button_spam(new object(), new RoutedEventArgs());

            }
            else if (lastfun == "sent")
            {
                Button_Sent(new object(), new RoutedEventArgs());


            }
            else
            {
                Button_draft(new object(), new RoutedEventArgs());


            }
        }

        private void Button_inbox(object sender, RoutedEventArgs e)
        {
            contmsg.Visibility = Visibility.Hidden;


             get_inbox();
            

            SqlConnection con = new SqlConnection(connec);
            con.Open();

            SqlCommand cmd = new SqlCommand("msgpro", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@theloggedemail", str));

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Mails");
            da.Fill(dt);
            dg.ItemsSource = dt.DefaultView;
            dg.Columns[0].Visibility = Visibility.Visible;
            dg.Columns[1].Visibility = Visibility.Hidden;
            dg.Columns[4].Visibility = Visibility.Hidden;
            dg.Columns[5].Visibility = Visibility.Hidden;
            dg.Columns[6].Visibility = Visibility.Hidden;
            dg.Columns[7].Visibility = Visibility.Hidden;
            con.Close();


            lastfun = "inbox";
        }

        private void Button_Sent(object sender, RoutedEventArgs e)
        {
            contmsg.Visibility = Visibility.Hidden;
            
            get_sent();
           

            SqlConnection con = new SqlConnection(connec);
            con.Open();


           

            SqlCommand cmd = new SqlCommand("msgsent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@sender", str));

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Mails");
            da.Fill(dt);
            dg.ItemsSource = dt.DefaultView;
            dg.Columns[1].Visibility = Visibility.Visible;
            dg.Columns[0].Visibility = Visibility.Hidden;
          

            con.Close();
            lastfun = "sent";

        }

        private void Button_draft(object sender, RoutedEventArgs e)
        {
            contmsg.Visibility = Visibility.Visible;
            
            get_drafts();
           

            SqlConnection con = new SqlConnection(connec);
            con.Open();

            SqlCommand cmd = new SqlCommand("msgdraft", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@sender", str));

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Mails");
            da.Fill(dt);
            dg.ItemsSource = dt.DefaultView;
            dg.Columns[1].Visibility = Visibility.Visible;
            dg.Columns[0].Visibility = Visibility.Hidden;
           

            con.Close();
            lastfun = "draft";

        }

        private void Button_spam(object sender, RoutedEventArgs e)
        {
            contmsg.Visibility = Visibility.Hidden;

            get_spam();
          

            SqlConnection con = new SqlConnection(connec);
            con.Open();


           




            SqlCommand cmd = new SqlCommand("msgspam", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@email", str));


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Mails");
            da.Fill(dt);
            dg.ItemsSource = dt.DefaultView;

            dg.Columns[0].Visibility = Visibility.Visible;
            dg.Columns[1].Visibility = Visibility.Hidden;

           
            con.Close();

            lastfun = "spam";

        }

        private void Button_logOut(object sender, RoutedEventArgs e)
        {
            Welcome w = new Welcome();
            w.Show();
            Close();

        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {

            DataRowView row = dg.SelectedItem as DataRowView;

            string msgnum = row.Row.ItemArray[5].ToString();
             int num = Convert.ToInt32(msgnum);

            SqlConnection con = new SqlConnection(connec);
            con.Open();

            if (lastfun == "inbox")
            {
                SqlCommand showuser = new SqlCommand("updatetodelete", con);
                showuser.CommandType = CommandType.StoredProcedure;
                showuser.Parameters.Add(new SqlParameter("@id", num));
                showuser.ExecuteNonQuery();

                Button_inbox(new object(), new RoutedEventArgs());
            }



            else if (lastfun == "spam")
            {
                SqlCommand showuser = new SqlCommand("updatetodelete", con);
                showuser.CommandType = CommandType.StoredProcedure;
                showuser.Parameters.Add(new SqlParameter("@id", num));
                showuser.ExecuteNonQuery();

                Button_spam(new object(), new RoutedEventArgs());
            }
            else if (lastfun == "sent")
            {
                SqlCommand showuser = new SqlCommand("updatetodeletesent", con);
                showuser.CommandType = CommandType.StoredProcedure;
                showuser.Parameters.Add(new SqlParameter("@id", num));
                showuser.ExecuteNonQuery();
                Button_Sent(new object(), new RoutedEventArgs());
            }
            else
            {
                SqlCommand showuser = new SqlCommand("deletemsg", con);
                showuser.CommandType = CommandType.StoredProcedure;
                showuser.Parameters.Add(new SqlParameter("@id", num));
                showuser.ExecuteNonQuery();
                Button_draft(new object(), new RoutedEventArgs());

            }
            SqlCommand del = new SqlCommand("deleteboth", con);
            del.CommandType = CommandType.StoredProcedure;
            del.ExecuteNonQuery();

            SqlCommand deltwin = new SqlCommand("deletetwin", con);
            deltwin.CommandType = CommandType.StoredProcedure;
            deltwin.ExecuteNonQuery();
            con.Close();

        }
        private void Button_cont(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedIndex != -1)
            {

                DataRowView row = dg.SelectedItem as DataRowView;
                sendTo st = new sendTo(row.Row.ItemArray[3].ToString(), row.Row.ItemArray[1].ToString(), row.Row.ItemArray[4].ToString(), Convert.ToInt32(row.Row.ItemArray[5]));
                st.Show();
            }
            else
                MessageBox.Show("Pls Select a message");
        }

        private void Button_info(object sender, RoutedEventArgs e)
        {
            Info userinfo = new Info(str);
            userinfo.Show();
            Close();
        }

        private void Button_Reply(object sender, RoutedEventArgs e)
        {
            DataRowView row = dg.SelectedItem as DataRowView;
            sendTo st = new sendTo(str,row.Row.ItemArray[3].ToString());
            st.Show();
        }
    }
}