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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tinh_diem_hoc_sinh
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            Showdata();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string MaSV = textBox1.Text;
            string TenSV = textBox2.Text;
            string Lop = textBox3.Text;
            string Diem = textBox4.Text;
            string Diachi = textBox6.Text;
            string id = textBox7.Text;
            string Password = textBox5.Text;

            string connectionString = "Data Source=MSI;Initial Catalog=qlsv;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ADD1", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", @id));
                    cmd.Parameters.Add(new SqlParameter("@MaSV", @MaSV));
                    cmd.Parameters.Add(new SqlParameter("@TenSV", @TenSV));
                    cmd.Parameters.Add(new SqlParameter("@Lop", @Lop));
                    cmd.Parameters.Add(new SqlParameter("@Diem", @Diem));
                    cmd.Parameters.Add(new SqlParameter("@Diachi", @Diachi));
                    cmd.Parameters.Add(new SqlParameter("@Password", textBox5.Text));

                    try
                    {
                        con.Open();
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        d1.DataSource = dt;
                        d1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        MessageBox.Show("Add data successfully", "Notification");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Add data failed", "Notification");
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            Showdata();
        }
        public void Showdata()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=MSI;Initial Catalog=qlsv;Integrated Security=True"))
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.STUDENT ", connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            d1.DataSource = dataTable;
                            d1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Search data failed", "Notification");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }

            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRows = d1.SelectedRows[0];
            int id = (int)selectedRows.Cells["id"].Value;
            using (SqlConnection connection = new SqlConnection("Data Source=MSI;Initial Catalog=qlsv;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand("DELETE FROM STUDENT WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
            MessageBox.Show("Delete successfully", "Notification");
            Showdata();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = d1.SelectedRows[0];
            int id = (int)selectedRow.Cells["id"].Value;
            string MaSV = textBox1.Text;
            string TenSV = textBox2.Text;
            string Lop = textBox3.Text;
            string Diem = textBox4.Text;
            string Diachi = textBox6.Text;   

            using (SqlConnection connection = new SqlConnection("Data Source=MSI;Initial Catalog=qlsv;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("UPDATE STUDENT SET MaSV =@MaSV, TenSV = @TenSV, Lop = @Lop,Diem =@Diem , Diachi =@Diachi WHERE id = @id", connection);
                cmd.Parameters.Add(new SqlParameter("@id", @id));
                cmd.Parameters.Add(new SqlParameter("@MaSV", @MaSV));
                cmd.Parameters.Add(new SqlParameter("@TenSV", @TenSV));
                cmd.Parameters.Add(new SqlParameter("@Lop", @Lop));
                cmd.Parameters.Add(new SqlParameter("@Diem", @Diem));
                cmd.Parameters.Add(new SqlParameter("@Diachi", @Diachi));

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            Showdata();

        }

        private void Report_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f = new Form6();  
            f.ShowDialog();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
