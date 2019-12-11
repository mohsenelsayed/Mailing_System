﻿using System;
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
    /// Interaction logic for MailsHome.xaml
    /// </summary>
    public partial class MailsHome : Window
    {

        public string connec = "Data Source=DESKTOP-I9CKISJ;Initial Catalog=mailingsystem;Integrated Security=True";

        public string str;
        public string name;

        public MailsHome()
        {
            InitializeComponent();

        }
        public MailsHome(string val)
        {
            InitializeComponent();
     

            str = val;

            

            SqlConnection con = new SqlConnection(connec);
            con.Open();

               SqlCommand showuser = new SqlCommand("showusername", con);
            showuser.CommandType = CommandType.StoredProcedure;
            showuser.Parameters.Add(new SqlParameter("@email", str));
            SqlDataReader userreader = showuser.ExecuteReader();
            while (userreader.Read())
                name =(userreader["username"].ToString());;
            userreader.Close();

            usernamewpf.Text += name;


            SqlCommand num = new SqlCommand("msgnum", con);
            num.CommandType = CommandType.StoredProcedure;
            num.Parameters.Add(new SqlParameter("@email", str));
            int count = Convert.ToInt32(num.ExecuteScalar());
            msgs.Text = "messages number is " + count;



            SqlCommand cmd = new SqlCommand("msgpro", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@theloggedemail", str));

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Mails");
            da.Fill(dt);
            dg.ItemsSource = dt.DefaultView;
            dg.Columns[1].Visibility = Visibility.Hidden;


            /* SqlDataReader reader = cmd.ExecuteReader();

             DataTable tbl_mail = new DataTable();
             tbl_mail.Columns.Add("From");
             tbl_mail.Columns.Add("Subject");
             tbl_mail.Columns.Add("Date");

             DataRow row;
             while (reader.Read())
             {
                 row = tbl_mail.NewRow();
                 row["From"] = reader["Username"];
                 row["Subject"] = reader["Subject"];
                 row["Date"] = reader["msgdate"];

                 tbl_mail.Rows.Add(row);


             }

             dg.ItemsSource = tbl_mail.DefaultView;
       //      dg.Columns[1].Visibility = Visibility.Hidden;

             reader.Close();

     */
            con.Close();

        }

        private void Button_New(object sender, RoutedEventArgs e)
        {
            sendTo st = new sendTo(str);
            st.Show();
        }
        private void Button_inbox(object sender, RoutedEventArgs e)
        {
                


            SqlConnection con = new SqlConnection(connec);
            con.Open();


            SqlCommand num = new SqlCommand("msgnum", con);
            num.CommandType = CommandType.StoredProcedure;
            num.Parameters.Add(new SqlParameter("@email", str));
            int count = Convert.ToInt32(num.ExecuteScalar());
            msgs.Text = "messages number is " + count;



            
            SqlCommand cmd = new SqlCommand("msgpro", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@theloggedemail", str));

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Mails");
            da.Fill(dt);
            dg.ItemsSource = dt.DefaultView;
            dg.Columns[1].Visibility = Visibility.Hidden;
            dg.Columns[0].Visibility = Visibility.Visible;
            /*  SqlDataReader reader = cmd.ExecuteReader();

              DataTable tbl_mail = new DataTable();
              tbl_mail.Columns.Add("From");
              tbl_mail.Columns.Add("Subject");
              tbl_mail.Columns.Add("Date");

              DataRow row;
              while (reader.Read())
              {
                  row = tbl_mail.NewRow();
                  row["From"] = reader["Username"];
                  row["Subject"] = reader["Subject"];
                  row["Date"] = reader["msgdate"];

                  tbl_mail.Rows.Add(row);


              }

              dg.ItemsSource = tbl_mail.DefaultView;


              reader.Close();

      */
            con.Close();
        }

        private void Button_Sent(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(connec);
            con.Open();


            SqlCommand num = new SqlCommand("msgnumsent", con);
            num.CommandType = CommandType.StoredProcedure;
            num.Parameters.Add(new SqlParameter("@email", str));
            int count = Convert.ToInt32(num.ExecuteScalar());
            msgs.Text = "messages number is " + count;




            SqlCommand cmd = new SqlCommand("msgsent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@sender", str));

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Mails");
            da.Fill(dt);
            dg.ItemsSource = dt.DefaultView;
            dg.Columns[0].Visibility = Visibility.Hidden;
            dg.Columns[1].Visibility = Visibility.Visible;
            /* SqlDataReader reader = cmd.ExecuteReader();

             DataTable tbl_mail = new DataTable();
             tbl_mail.Columns.Add("To");
             tbl_mail.Columns.Add("Subject");
             tbl_mail.Columns.Add("Date");

             DataRow row;
             while (reader.Read())
             {
                 row = tbl_mail.NewRow();
                 row["To"] = reader["Username"];
                 row["Subject"] = reader["Subject"];
                 row["Date"] = reader["msgdate"];

                 tbl_mail.Rows.Add(row);


             }

             dg.ItemsSource = tbl_mail.DefaultView;


             reader.Close();
             */

            con.Close();
        }

        private void Button_draft(object sender, RoutedEventArgs e)
        {
           
            SqlConnection con = new SqlConnection(connec);
            con.Open();


            
            SqlCommand num = new SqlCommand("msgdraftnum", con);
            num.CommandType = CommandType.StoredProcedure;
            num.Parameters.Add(new SqlParameter("@email", str));
            int count = Convert.ToInt32(num.ExecuteScalar());
            msgs.Text = "messages number is " + count;


            SqlCommand cmd = new SqlCommand("msgdraft", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@sender", str));

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Mails");
            da.Fill(dt);
            dg.ItemsSource = dt.DefaultView;
            /*SqlDataReader reader = cmd.ExecuteReader();

            DataTable tbl_mail = new DataTable();
            tbl_mail.Columns.Add("To");
            tbl_mail.Columns.Add("Subject");
            tbl_mail.Columns.Add("Date");

            DataRow row;
            while (reader.Read())
            {
                row = tbl_mail.NewRow();
                row["To"] = reader["Username"];
                row["Subject"] = reader["Subject"];
                row["Date"] = reader["msgdate"];

                tbl_mail.Rows.Add(row);


            }

            dg.ItemsSource = tbl_mail.DefaultView;


            reader.Close();
            */

            con.Close();
        }

        private void Button_spam(object sender, RoutedEventArgs e)
        {

            SqlConnection con = new SqlConnection(connec);
            con.Open();


            SqlCommand num = new SqlCommand("msgspamnum", con);
            num.CommandType = CommandType.StoredProcedure;
            num.Parameters.Add(new SqlParameter("@email", str));
            int count = Convert.ToInt32(num.ExecuteScalar());
            msgs.Text = "messages number is " + count;




            SqlCommand cmd = new SqlCommand("msgspam", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@email", str));


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Mails");
            da.Fill(dt);
            dg.ItemsSource = dt.DefaultView;
            /* SqlDataReader reader = cmd.ExecuteReader();

             DataTable tbl_mail = new DataTable();
             tbl_mail.Columns.Add("From");
             tbl_mail.Columns.Add("Subject");
             tbl_mail.Columns.Add("Date");

             DataRow row;
             while (reader.Read())
             {
                 row = tbl_mail.NewRow();
                 row["From"] = reader["Username"];
                 row["Subject"] = reader["Subject"];
                 row["Date"] = reader["msgdate"];

                 tbl_mail.Rows.Add(row);


             }

             dg.ItemsSource = tbl_mail.DefaultView;


             reader.Close();

     */
            con.Close();


        }

        private void Button_logOut(object sender, RoutedEventArgs e)
        {
            Welcome w = new Welcome();
            w.Show();
            Close();
            
        }

        private void Button_update(object sender, RoutedEventArgs e)
        {
            Info u = new Info(name);
            u.Show();
            Close();
        }
    }
}