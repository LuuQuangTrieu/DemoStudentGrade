using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Tinh_diem_hoc_sinh
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
       
        }
       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
             
        }

        private void txtLogin_Click(object sender, EventArgs e)
        {


            string connectionString = @"Data Source=MSI;Initial Catalog=qlsv;Integrated Security=True";
            string username = txtUser.Text;
            string password = txtPass.Text;
            string role = comboBox1.Text.ToLower(); // Convert role to lowercase for case-insensitive comparison

            string query = "";
            string successMessage = "Logged in successfully";
            string errorMessage = "Login failed";

            if (role == "student")
            {
                query = "SELECT MaSV, PassWord FROM STUDENT WHERE MaSV = @Username AND PassWord = @Password";
            }
            else if (role == "teacher")
            {
                query = "SELECT UserName, PassWord FROM TK WHERE UserName = @Username AND PassWord = @Password";
            }
            else
            {
                MessageBox.Show("Please choose the right role to login", "Notification");
                return; // Exit the function if the role is not valid
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            MessageBox.Show(successMessage, "Notification");
                            this.Hide();

                            if (role == "student")
                            {
                                Form3 form3 = new Form3();
                                form3.ShowDialog();
                            }
                            else if (role == "teacher")
                            {
                                Form4 form4 = new Form4();
                                form4.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageBox.Show(errorMessage, "Notification");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Notification");
                }
            }
        }

            private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void Register_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 f = new Form8();
            f.ShowDialog();
        }
    }     
            
        
}

