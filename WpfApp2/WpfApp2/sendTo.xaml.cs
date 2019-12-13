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
using System.Text.RegularExpressions;


namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for sendTo.xaml
    /// </summary>
    public partial class sendTo : Window
    {
        public int nu;
        public string connec = "Data Source=DESKTOP-I9CKISJ ;Initial Catalog=mailingsystem;Integrated Security=True";
        public string str;
        public sendTo(String val)
        {
            InitializeComponent();
            str = val;
            senddraft.Visibility = Visibility.Hidden;

        }
        public sendTo(String toemail,string subj,string desc,int num)
        {
            InitializeComponent();
            draft.Visibility = Visibility.Hidden;
            send.Visibility = Visibility.Hidden;
            senddraft.Visibility = Visibility.Visible;
            towpf.Text = toemail;
            subjectwpf.Text = subj;
            descwpf.Text = desc;
            nu = num;
        }



        private void Button_sendmsg(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(connec);
            con.Open();

            SqlCommand checkemail = new SqlCommand("check_email_is_in_the_system", con);
            checkemail.CommandType = CommandType.StoredProcedure;

            checkemail.Parameters.Add(new SqlParameter("@email", towpf.Text));

            int emailcount = Convert.ToInt32(checkemail.ExecuteScalar());

            if (emailcount != 1)
            {
                MessageBox.Show("This email Does not exist");
                return;
            }







            SqlCommand cmd = new SqlCommand("sendmsg", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@subject", subjectwpf.Text));
            cmd.Parameters.Add(new SqlParameter("@description", descwpf.Text));
            cmd.Parameters.Add(new SqlParameter("@toemail", towpf.Text));
            cmd.Parameters.Add(new SqlParameter("@fromemail", str));
            cmd.Parameters.Add(new SqlParameter("@folder", "inbox"));


            cmd.ExecuteNonQuery();
            con.Close();
            Close();
        }
        private void Button_senddraft(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(connec);
            con.Open();

            SqlCommand checkemail = new SqlCommand("check_email_is_in_the_system", con);
            checkemail.CommandType = CommandType.StoredProcedure;

            checkemail.Parameters.Add(new SqlParameter("@email", towpf.Text));

            int emailcount = Convert.ToInt32(checkemail.ExecuteScalar());

            if (emailcount != 1)
            {
                MessageBox.Show("This email Does not exist");
                return;
            }



            SqlCommand cmd = new SqlCommand("drafttosend", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@id", nu));
            cmd.Parameters.Add(new SqlParameter("@email", towpf.Text));
            cmd.Parameters.Add(new SqlParameter("@subject", subjectwpf.Text));
            cmd.Parameters.Add(new SqlParameter("@description", descwpf.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            Close();



        }


        private void Button_discard(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(towpf.Text))
            {

                SqlConnection con = new SqlConnection(connec);
                con.Open();

                SqlCommand checkemail = new SqlCommand("check_email_is_in_the_system", con);
                checkemail.CommandType = CommandType.StoredProcedure;

                checkemail.Parameters.Add(new SqlParameter("@email", towpf.Text));

                int emailcount = Convert.ToInt32(checkemail.ExecuteScalar());

                if (emailcount != 1)
                {
                    MessageBox.Show("This email Does not exist");
                    return;
                }




                SqlCommand cmd = new SqlCommand("sendmsg", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@subject", subjectwpf.Text));
                cmd.Parameters.Add(new SqlParameter("@description", descwpf.Text));
                cmd.Parameters.Add(new SqlParameter("@toemail", towpf.Text));
                cmd.Parameters.Add(new SqlParameter("@fromemail", str));
                cmd.Parameters.Add(new SqlParameter("@folder", "draft"));


                cmd.ExecuteNonQuery();
                con.Close();
                Close();

            }


        }
    }
}
