using QLKTXHCMUTE.DBLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKTXHCMUTE.BSLayer
{
    public class BLNhanVien
    {
        MY_DB db;

        public BLNhanVien()
        {
            db = new MY_DB();
        }

        public void ThemViPham(string stt,string idsv, string ndvp)
        {
            SqlCommand command = new SqlCommand("ThemViPham", db.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@STT", SqlDbType.VarChar).Value = stt;
            command.Parameters.Add("@ND", SqlDbType.VarChar).Value = ndvp;
            command.Parameters.Add("@ID", SqlDbType.VarChar).Value = idsv;
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();
        }

        public bool XoaNhanVien(string id)
        {
            SqlCommand command = new SqlCommand("proc_XoaNhanVien", db.getConnection);
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

        public bool ThemNhanVien(string id, string chuyennganh, string khoa, DateTime ngaydk, DateTime thoihan, string maphong, string ho, string ten, DateTime nsinh, string gtinh, string quequan, string sdt, string cccd)
        {
            SqlCommand command = new SqlCommand("proc_ThemSinhVien", db.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ID", SqlDbType.VarChar).Value = id;
            command.Parameters.Add("@ChuyenNganh", SqlDbType.VarChar).Value = chuyennganh;
            command.Parameters.Add("@Khoa", SqlDbType.VarChar).Value = khoa;
            command.Parameters.Add("@NgayDK", SqlDbType.Date).Value = ngaydk;
            command.Parameters.Add("@ThoiHan", SqlDbType.Date).Value = thoihan;
            command.Parameters.Add("@MaPhong", SqlDbType.VarChar).Value = maphong;
            command.Parameters.Add("@Ho", SqlDbType.NVarChar).Value = ho;
            command.Parameters.Add("@Ten", SqlDbType.NVarChar).Value = ten;
            command.Parameters.Add("@NgSinh", SqlDbType.Date).Value = nsinh;
            command.Parameters.Add("@GTinh", SqlDbType.NVarChar).Value = gtinh;
            command.Parameters.Add("@QueQuan", SqlDbType.NVarChar).Value = quequan;
            command.Parameters.Add("@CCCD", SqlDbType.VarChar).Value = cccd;
            command.Parameters.Add("@SDT", SqlDbType.VarChar).Value = sdt;
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
