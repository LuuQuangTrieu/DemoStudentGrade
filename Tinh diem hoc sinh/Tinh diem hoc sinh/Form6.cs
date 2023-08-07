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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            Loaddata();
        }
        private void Loaddata()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=MSI;Initial Catalog=qlsv;Integrated Security=True"))
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Report", connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dt6.DataSource = dataTable;
                            dt6.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void Del_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dt6.SelectedRows[0];
            int ReportID = (int)selectedRow.Cells["ReportID"].Value;
            using (SqlConnection connection = new SqlConnection("Data Source=MSI;Initial Catalog=qlsv;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand("DELETE FROM dbo.Report WHERE Report.ReportID = @ReportID", connection);
                command.Parameters.AddWithValue("@ReportID", ReportID);
                connection.Open();
                command.ExecuteNonQuery();
            }
            MessageBox.Show("Delete successfully", "Notification");
            Loaddata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
