using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tinh_diem_hoc_sinh
{
    internal class DataConnection
    {
        string conStr;
        public DataConnection()
        {
            conStr = "Data Source =MSI;Initial Catalog=qlsv;Intergrated Security=true";
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(conStr);
        }
    }
}
