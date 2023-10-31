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
    public class BLThanNhan
    {
        MY_DB db;
        public BLThanNhan()
        {
            db = new MY_DB();
        }

        public bool themTN(string id_nd, string cccd, string ho, DateTime nsinh, string ten, string gtinh, string quequan, string sdt, string nghenghiep)
        {
            SqlCommand command = new SqlCommand("proc_ThemThanNhan", db.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ID_ND", SqlDbType.VarChar).Value = id_nd;
            command.Parameters.Add("@Ho", SqlDbType.NVarChar).Value = ho;
            command.Parameters.Add("@Ten", SqlDbType.NVarChar).Value = ten;
            command.Parameters.Add("@NgSinh", SqlDbType.Date).Value = nsinh;
            command.Parameters.Add("@GTinh", SqlDbType.NVarChar).Value = gtinh;
            command.Parameters.Add("@QueQuan", SqlDbType.NVarChar).Value = quequan;
            command.Parameters.Add("@CCCD", SqlDbType.VarChar).Value = cccd;
            command.Parameters.Add("@SDT", SqlDbType.VarChar).Value = sdt;
            command.Parameters.Add("@NgNhiep", SqlDbType.NVarChar).Value = nghenghiep;
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
