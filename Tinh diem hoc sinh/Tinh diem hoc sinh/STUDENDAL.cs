using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tinh_diem_hoc_sinh
{
    internal class STUDENDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public STUDENDAL()
        {
            dc = new DataConnection();
        }
        public DataTable GetAllSTUDENT()
        {
            string sql = "SELECT *FROM STUDENT";
            SqlConnection con =dc.GetConnection();
            da = new SqlDataAdapter(sql,con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public bool InsertSTUDENT(STUDENT sv)
        {
            string sql = "INSERT INTO STUDENT(MaSV,TenSV,Diem,Lop,Diachi) VALUES (@MaSV,@TenSV,@Diem,@Lop,@Diachi";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaSV",SqlDbType.NVarChar).Value =sv.MaSV; 
                cmd.Parameters.Add("@TenSV", SqlDbType.NVarChar).Value = sv.TenSV;
                cmd.Parameters.Add("@Diem", SqlDbType.Float).Value = sv.Diem;
                cmd.Parameters.Add("@Lop", SqlDbType.NVarChar).Value = sv.Lop;
                cmd.Parameters.Add("@Diachi", SqlDbType.NVarChar).Value = sv.Diachi;
                cmd.ExecuteNonQuery(); 
                con.Close();
   
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }
        public bool UPDATESTUDENT(STUDENT sv)
        {
            string sql = "UPDATE STUDENT SET MaSV=@MaSV,TenSV=@TenSC,Diem=@Diem,Lop=@Lop,Diachi=@Diachi WHERE id=@id";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = sv.id;
                cmd.Parameters.Add("@MaSV", SqlDbType.NVarChar).Value = sv.MaSV;
                cmd.Parameters.Add("@TenSV", SqlDbType.NVarChar).Value = sv.TenSV;
                cmd.Parameters.Add("@Diem", SqlDbType.Float).Value = sv.Diem;
                cmd.Parameters.Add("@Lop", SqlDbType.NVarChar).Value = sv.Lop;
                cmd.Parameters.Add("@Diachi", SqlDbType.NVarChar).Value = sv.Diachi;
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool DeleteSTUDENT(STUDENT sv)
        {
            string sql = "Delete  STUDENT WHERE id=@id";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = sv.id;
               
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

    }
}

