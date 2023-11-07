using QLKTXHCMUTE.DBLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QLKTXHCMUTE.BSLayer
{
    internal class BLHoaDon
    {
        MY_DB db;
        public BLHoaDon()
        {
            db = new MY_DB();
        }

        public DataTable XemThongTinHoaDonCuaPhong(string maphong)
        {
            SqlCommand command = new SqlCommand("Select * from func_XemThongTinHoaDon(@string)", db.getConnection);
            command.Parameters.Add("@string", SqlDbType.VarChar).Value = maphong;
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            return table;
        }
        public bool GhiHoaDon(string mahd,string maPhong, int sonuoc, int sodien, int dathanhtoan)
        {
            SqlCommand command = new SqlCommand("proc_TaoHoaDon", db.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaHD", SqlDbType.VarChar).Value = mahd;
            command.Parameters.Add("@MaPhong", SqlDbType.VarChar).Value = maPhong;
            command.Parameters.Add("@NuocThangNay", SqlDbType.Int).Value = sonuoc;
            command.Parameters.Add("@DienThangNay", SqlDbType.Int).Value = sodien;
            command.Parameters.Add("@DaThanhToan", SqlDbType.Bit).Value = dathanhtoan;
            db.openConnection();
            if (command.ExecuteNonQuery() > 0)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        public DataTable XemHoaDonChuaThanhToan(string maphong)
        {
            if (maphong != null)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM V_DSHDChuaThanhToan where MaPhong = '" +maphong+ "'", db.getConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
            else
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM V_DSHDChuaThanhToan", db.getConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }    
        }
    }
}
