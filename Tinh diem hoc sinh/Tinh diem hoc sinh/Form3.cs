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
    public partial class Form3 : Form
    {
         SqlDataAdapter da;
        public Form3()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           
            
                string keyword = txtsearch.Text; 
            using (SqlConnection connection = new SqlConnection("Data Source=MSI;Initial Catalog=qlsv;Integrated Security=True"))
            {
                try
                {
                    connection.Open();
                    string queryString = "SELECT MaSV, TenSV, Lop, Diem, DiaChi " +
                                         "FROM STUDENT " +
                                         "WHERE MaSV LIKE @Keyword OR TenSV LIKE @Keyword OR Lop LIKE @Keyword OR DiaChi LIKE @Keyword";

                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            //Sử dụng dataTable để hiển thị dữ liệu

                            dataGridView1.DataSource = dataTable;
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        }
                    } 
                }
                catch (Exception)
                {
                    MessageBox.Show("Search data failed", "Notification");
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        private void Report1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 f = new Form7();
            f.ShowDialog();
        }
    }
}
/*private void btnSearch_Click(object sender, EventArgs e)
{
    string keyword = txtKeyword.Text.Trim().ToLower();

    using (SqlConnection connection = new SqlConnection("Data Source=MSI;Initial Catalog=qlsv;Integrated Security=True"))
    {
        try
        {
            connection.Open();
            string queryString = "SELECT MaSV, TenSV, Lop, Diem, DiaChi " +
                                 "FROM STUDENT " +
                                 "WHERE MaSV LIKE @Keyword OR TenSV LIKE @Keyword OR Lop LIKE @Keyword OR DiaChi LIKE @Keyword";

            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    //Sử dụng dataTable để hiển thị dữ liệu

                    // Ví dụ:
                    dataGridView.DataSource = dataTable;
                }
            }
        }
        catch (Exception)
        {
            MessageBox.Show("Search data failed", "Notification");
        }
        finally
        {
            connection.Close();
        }
    }
}
*/
