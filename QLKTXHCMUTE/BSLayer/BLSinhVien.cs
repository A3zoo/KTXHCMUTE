using QLKTXHCMUTE.DBLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKTXHCMUTE.BSLayer
{
    public class BLSinhVien
    {
        MY_DB db;
        public BLSinhVien()
        {
            db = new MY_DB();
        }

        public void CạpNhatThongTinSinhVien(string id, string ho, string ten, DateTime ngaysinh, string quequan, string SDT)
        {
            SqlCommand command = new SqlCommand("proc_CapNhatThongTin", db.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ID", SqlDbType.VarChar).Value = id;
            command.Parameters.Add("@Ho", SqlDbType.NVarChar).Value = ho;
            command.Parameters.Add("@Ten", SqlDbType.NVarChar).Value = ten;
            command.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = ngaysinh;
            command.Parameters.Add("@QueQuan", SqlDbType.NVarChar).Value = quequan;
            command.Parameters.Add("@SDT", SqlDbType.VarChar).Value = SDT;
            command.ExecuteNonQuery();
            db.closeConnection();
        }

        public DataTable layTatCaSV()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM V_DSSinhVien", db.getConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            db.closeConnection();
            return dt;
        }

        public bool xoaSV(string id)
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
        public bool themSV(string id, string chuyennganh, string khoa, DateTime ngaydk, DateTime thoihan, string maphong, string ho, string ten, DateTime nsinh, string gtinh, string quequan, string sdt, string cccd)
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
