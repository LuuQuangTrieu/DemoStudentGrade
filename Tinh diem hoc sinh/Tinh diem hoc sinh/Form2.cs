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
    public partial class Form2 : Form
    {
        STUDENTBLL bllSV;
        public Form2()
        {
            InitializeComponent();
            bllSV = new STUDENTBLL();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        } 
    private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (CheckData())
            {
                STUDENT sv = new STUDENT();

                sv.MaSV = textBox1.Text;
                sv.TenSV = textBox2.Text;
                sv.Lop = textBox3.Text;
                sv.Diem = float.Parse(textBox4.Text);
                sv.Diachi = textBox6.Text;
                if (bllSV.UPDATESTUDENT(sv))
                {
                    ShowAllSTUDENT();
                }
                else 
                { 
                MessageBox.Show("Error", "Infitication", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                STUDENT sv = new STUDENT();
                sv.MaSV = textBox1.Text;
                sv.TenSV = textBox2.Text;
                sv.Lop = textBox3.Text;
                sv.Diem = float.Parse(textBox4.Text);
                sv.Diachi = textBox6.Text;
                if (bllSV.INSERTSTUDENT(sv))
                {
                    ShowAllSTUDENT();
                }
                else
                { 
                MessageBox.Show("Error", "Infitication", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            string MaSV = textBox1.Text;
            string TenSV = textBox2.Text;
            string Lop = textBox3.Text;
            string Diem = textBox4.Text;
            string Diachi = textBox6.Text;

            string connectionString = "Data Source=MSI;Initial Catalog=qlsv;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Add", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@MaSV", @MaSV));
                    cmd.Parameters.Add(new SqlParameter("@TenSV", @TenSV));
                    cmd.Parameters.Add(new SqlParameter("@Lop", @Lop));
                    cmd.Parameters.Add(new SqlParameter("@Diem", @Diem));
                    cmd.Parameters.Add(new SqlParameter("@Diachi", @Diachi));

                    try
                    {
                        con.Open();
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        dataGridView2.DataSource = dt;
                        dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void ShowAllSTUDENT()
        {
            DataTable dt = bllSV.GetAllSTUDENT();
            dataGridView2.DataSource= dt;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ShowAllSTUDENT();   
        }
        public bool CheckData()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("No MaSV", "Infitication", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("No TenSV", "Infitication", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("No Lop", "Infitication", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("No Diem", "Infitication", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("No Diachi", "Infitication", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox6.Focus();
                return false;
            }

            return true;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index =e.RowIndex;
            if(index >= 0) 
            {
             
                textBox1.Text = dataGridView2.Rows[index].Cells["MaSV"].Value.ToString();
                textBox2.Text = dataGridView2.Rows[index].Cells["TenSV"].Value.ToString();
                textBox3.Text = dataGridView2.Rows[index].Cells["Lop"].Value.ToString();
                textBox4.Text = dataGridView2.Rows[index].Cells["Diem"].Value.ToString();
                textBox6.Text = dataGridView2.Rows[index].Cells["Diachi"].Value.ToString();
            }
        }

       

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
            int BookID = (int)selectedRow.Cells["BookID"].Value;
            using (SqlConnection connection = new SqlConnection("Data Source=REL_LANCER;Initial Catalog=ASM;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand("DELETE FROM Book WHERE BookID = @BookID", connection);
                command.Parameters.AddWithValue("@BookID", BookID);
                connection.Open();
                command.ExecuteNonQuery();
            }
            MessageBox.Show("Delete successfully", "Notification");
            Showdata();

        }
        public void Showdata()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=REL_LANCER;Initial Catalog=ASM;Integrated Security=True"))
            {
                using (SqlCommand command = new SqlCommand("SELECT Book.BookID ,Book.Title,Author.AuthorName,Categories.CategoryName,Book.PublishingYear \r\nFROM dbo.Book\r\nINNER JOIN dbo.Author ON Book.AuthorID = Author.AuthorID\r\nINNER JOIN dbo.Categories ON Book.CategoryID =Categories.CategoryID ", connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataGridView2.DataSource = dataTable;
                            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
    }
}
