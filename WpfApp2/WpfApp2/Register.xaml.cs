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
using System.Text.RegularExpressions;


namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase);


            //username

            if (String.IsNullOrWhiteSpace(usernamewpf.Text))
            {
                MessageBox.Show("your username cant be empty pls fill it ");
                return;
            }
            //end of username
            //phone
            if (String.IsNullOrWhiteSpace(phonewpf.Text))
            {
                MessageBox.Show("your phone cant be empty pls fill it ");
                return;
            }

            int z = 0;
            if (!int.TryParse(phonewpf.Text, out z))
            {

                MessageBox.Show("Pls enter a number in the phone box ");
                return;
            }

            if (phonewpf.Text.Length != 11)
            {

                MessageBox.Show("Pls enter a correct number ");
                return;
            }

            //end of phone
            //email
            if (String.IsNullOrWhiteSpace(emailwpf.Text))
            {
                MessageBox.Show("your email cant be empty pls fill it ");
                return;
            }
            if (!regex.IsMatch(emailwpf.Text))
            {
                MessageBox.Show("pls enter the right format of the email ");
                return;

            }

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-ITEONSL\\RAY;Initial Catalog=mailingsystem;Integrated Security=True");
            con.Open();

            SqlCommand checkemail = new SqlCommand("check_email_is_in_the_system", con);
            checkemail.CommandType = CommandType.StoredProcedure;

            checkemail.Parameters.Add(new SqlParameter("@email", emailwpf.Text));

            int emailcount = Convert.ToInt32(checkemail.ExecuteScalar());

            if (emailcount == 1)
            {
                MessageBox.Show("This email already exist");
                return;
            }

            //end of email
            //password
            if (String.IsNullOrWhiteSpace(passwordwpf.Password))
            {
                MessageBox.Show("your password cant be empty pls fill it");
                return;
            }
            if (passwordwpf.Password.Length < 5)
            {

                MessageBox.Show("your password should be more than 5 characters or numbers");
                return;
            }
            //end of password

            //confirmpass
            if (String.IsNullOrWhiteSpace(confirmpasswpf.Password))
            {
                MessageBox.Show("pls fill the confirmpassword box ");
                return;
            }
            if (confirmpasswpf.Password != passwordwpf.Password)
            {
                MessageBox.Show("your passwords doesnt match ");
                return;

            }
            //end of confirmpass
            //age

            if (String.IsNullOrWhiteSpace(agewpf.Text))
            {
                MessageBox.Show("pls fill the age box ");
                return;
            }
            int x = 0;
            if (!int.TryParse(agewpf.Text, out x))
            {

                MessageBox.Show("Pls enter a number in the age box ");
                return;
            }
            x = Convert.ToInt32(agewpf.Text);
            if (!(x >= 6 && x <= 100))
            {
                MessageBox.Show("Pls enter a number between 6 and 100 in the age box ");
                return;
            }

            //end of age
            //gender
            if (male.IsChecked == false && female.IsChecked == false)
            {
                MessageBox.Show("pls choose your gender");
                return;
            }
            //end of gender
            






            SqlCommand cmd = new SqlCommand("signup", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@email", emailwpf.Text));
            cmd.Parameters.Add(new SqlParameter("@password", passwordwpf.Password));
            cmd.Parameters.Add(new SqlParameter("@username", usernamewpf.Text));
            cmd.Parameters.Add(new SqlParameter("@age", Convert.ToInt32(agewpf.Text)));
            cmd.Parameters.Add(new SqlParameter("@phone", phonewpf.Text));
            if (male.IsChecked == true)
                cmd.Parameters.Add(new SqlParameter("@gender", "Male"));
            else
                cmd.Parameters.Add(new SqlParameter("@gender", "Female"));


            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("New Data inserted");




        }

        private void back_welcome(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Login.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
