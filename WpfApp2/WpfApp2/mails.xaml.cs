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
    /// Interaction logic for mails.xaml
    /// </summary>
    public partial class mails : Page
    {
        string str;

        public mails(string val) 
        {
            InitializeComponent();

            str = val;



            SqlConnection con = new SqlConnection("Data Source=DESKTOP-I9CKISJ;Initial Catalog=mailingsystem;Integrated Security=True");
            con.Open();


            SqlCommand num = new SqlCommand("msgnum", con);
            num.CommandType = CommandType.StoredProcedure;
            num.Parameters.Add(new SqlParameter("@email", str));
            int count = Convert.ToInt32(num.ExecuteScalar());
            msgs.Text = "messages number is " + count;




            SqlCommand cmd = new SqlCommand("msgpro", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@theloggedemail", str));
            SqlDataReader reader = cmd.ExecuteReader();

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


            con.Close();

        }
        public mails()
        {
            InitializeComponent();
        }
    }
}
