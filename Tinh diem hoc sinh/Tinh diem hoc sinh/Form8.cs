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

namespace Tinh_diem_hoc_sinh
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            string UserName = txtUser.Text;
            string PassWord = txtPass.Text;
            string MaSV = txtMaSV.Text;         
      



            using (SqlConnection connection = new SqlConnection("Data Source=MSI;Initial Catalog=qlsv;Integrated Security=True"))
            {

                SqlCommand cmd = new SqlCommand("INSERT INTO TK  VALUES (@MaSV,@UserName, @PassWord)", connection);
                cmd.Parameters.AddWithValue("@MaSV", MaSV);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@PassWord", PassWord);
               
               
             

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User registered successfully.");
                    this.Hide();
                    Form1 f = new Form1();
                    f.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                connection.Close();

            }
        }
    }
}
