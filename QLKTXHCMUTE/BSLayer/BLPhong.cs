using QLKTXHCMUTE.DBLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKTXHCMUTE.BSLayer
{
    
    internal class BLPhong
    {
        MY_DB db;
        public BLPhong()
        {
            db  = new MY_DB();
        }

        public bool SuaThongTinPhong(string maphong, string loaiphong, string tinhtrangphong, string matoa)
        {
            SqlCommand command = new SqlCommand("proc_ThemPhong", db.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaPhong", SqlDbType.VarChar).Value = maphong;
            command.Parameters.Add("@SoNguoiDangO", SqlDbType.Int).Value = 0;
            command.Parameters.Add("@LoaiPhong", SqlDbType.VarChar).Value = loaiphong;
            command.Parameters.Add("@TinhTrangPhong", SqlDbType.Date).Value = tinhtrangphong;
            command.Parameters.Add("@MaToa", SqlDbType.Date).Value = matoa;
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

        public DataTable layTatCaPhong()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Phong", db.getConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            db.closeConnection();
            return dt;
        }

        public bool XoaPhong(string id)
        {
            SqlCommand command = new SqlCommand("proc_XoaSinhVien", db.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ID", SqlDbType.VarChar).Value = id;
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
        public bool themPhong(string maphong, string loaiphong, string tinhtrangphong, string matoa)
        {
            SqlCommand command = new SqlCommand("proc_ThemPhong", db.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaPhong", SqlDbType.VarChar).Value = maphong;
            command.Parameters.Add("@SoNguoiDangO", SqlDbType.Int).Value = 0;
            command.Parameters.Add("@LoaiPhong", SqlDbType.VarChar).Value = loaiphong;
            command.Parameters.Add("@TinhTrangPhong", SqlDbType.Date).Value = tinhtrangphong;
            command.Parameters.Add("@MaToa", SqlDbType.Date).Value = matoa;
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
    }
}
