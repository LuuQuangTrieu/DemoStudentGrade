using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tinh_diem_hoc_sinh
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string UserID = TID.Text;
            string Title = Tt.Text;
            string Content = Tc.Text;
            using (SqlConnection connection = new SqlConnection("Data Source=MSI;Initial Catalog=qlsv;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("intreport", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@UserID", @UserID));
                    cmd.Parameters.Add(new SqlParameter("@Title", @Title));
                    cmd.Parameters.Add(new SqlParameter("@Content", @Content));
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Add data successfully", "Notification");

                }
            }
        }
    }
}
