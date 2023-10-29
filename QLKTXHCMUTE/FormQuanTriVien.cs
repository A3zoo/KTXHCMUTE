using QLKTXHCMUTE.DBLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLKTXHCMUTE
{
    public partial class FormQuanTriVien : Form
    {
        MY_DB db;
        public FormQuanTriVien()
        {
            InitializeComponent();
        }

        private void XemThongTinSinhVien(DataGridView a)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM V_TTSinhVien", db.getConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            a.DataSource = dt;
            a.Columns["MaSV"].HeaderText = "Mã sinh viên";
            a.Columns["Ho"].HeaderText = "Họ";
            a.Columns["Ten"].HeaderText = "Tên";
            a.Columns["NgSinh"].HeaderText = "Ngày sinh";
            a.Columns["GTinh"].HeaderText = "Giới tính";
            a.Columns["QueQuan"].HeaderText = "Quê quán";
            a.Columns["SDT"].HeaderText = "Số điện thoại";
            a.Columns["CCCD"].HeaderText = "CCCD";
            a.Columns["Khoa"].HeaderText = "Khoa";
            a.Columns["ChuyenNganh"].HeaderText = "Chuyên ngành";
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            db = new MY_DB(); 
        }

        private void btnChinhSuaSInhvien_Click(object sender, EventArgs e)
        {
            pnSinhVien.BringToFront();
            XemThongTinSinhVien(tableQuanLySinhVien);
        }

        private void btnChinhSuaPhong_Click(object sender, EventArgs e)
        {
            pnPhong.BringToFront();
        }

        private void btnghiHoaDon_Click(object sender, EventArgs e)
        {
            pnGhiHoaDon.BringToFront();
        }
    }
}
