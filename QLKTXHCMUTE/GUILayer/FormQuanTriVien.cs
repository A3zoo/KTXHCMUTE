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
using QLKTXHCMUTE.BSLayer;

namespace QLKTXHCMUTE
{
    public partial class FormQuanTriVien : Form
    {
        MY_DB db;
        BLNhanVien blNhanVien;
        BLSinhVien blSinhVien;
        BLPhongTro blPhongTro;
        BLHoaDon blHoaDon;
        BLThanNhan blThanNhan;
        int chucnang;
        public FormQuanTriVien()
        {
            InitializeComponent();
        }

        private void LoadThongTinSinhVien(DataGridView a)
        {
            DataTable dt = blSinhVien.layTatCaSV();
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
            blNhanVien = new BLNhanVien();
            blHoaDon = new BLHoaDon();
            blSinhVien = new BLSinhVien();
            blThanNhan = new BLThanNhan();
            btnSuaSV.Enabled = false;
            btnXoaSV.Enabled = false;
            btnLuaSV.Enabled = false;
            btnTaiSV.Enabled = true;
        }

        private void btnChinhSuaSInhvien_Click(object sender, EventArgs e)
        {
            pnSinhVien.BringToFront();
            LoadThongTinSinhVien(tableQuanLySinhVien);
        }

        private void btnChinhSuaPhong_Click(object sender, EventArgs e)
        {
            pnPhong.BringToFront();
        }

        private void btnghiHoaDon_Click(object sender, EventArgs e)
        {
            pnGhiHoaDon.BringToFront();
        }


        private void btnThemSV_Click(object sender, EventArgs e)
        {
            pnTTSV.Enabled = true;
            btnLuaSV.Enabled = true;
            btnSuaSV.Enabled = false;
            btnXoaSV.Enabled = false;
            chucnang = 1;
            
            //blSinhVien.themSV(txtMaSV.Text, txtChuyenNganhSV.Text, txtKhoaSV.Text, DateTime.Now.Date, dateHanPhongSV.Value.Date, txtMaphongSV.Text, txtHoTenLotSV.Text, txtTenSV.Text, dateNSinhSV.Value.Date, a, txtQueQuanSV.Text, txtsdtSV.Text, txtCCCDSV.Text);
        }

        private void btnXoaSV_Click(object sender, EventArgs e)
        {
            try
            {
                int r = tableQuanLySinhVien.CurrentCell.RowIndex;
                blSinhVien.xoaSV(tableQuanLySinhVien.Rows[r].Cells[0].Value.ToString());
                MessageBox.Show("Đã thêm xong!");
            }
            catch (SqlException)
            {
                DialogResult result = MessageBox.Show("Không thêm được, Bạn có muốn chỉnh sửa lại không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    pnTTSV.Enabled = false;
                    btnSuaSV.Enabled = true;
                    btnLuaSV.Enabled = false;
                    btnXoa.Enabled = true;
                }
            }
            LoadThongTinSinhVien(tableQuanLySinhVien);
        }

        private void tableQuanLySinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (chucnang != 1)
            {
                btnSuaSV.Enabled = true;
                btnXoaSV.Enabled = true;
            }
        }

        private void btnSuaSV_Click(object sender, EventArgs e)
        {
            chucnang = 2;
            this.btnSuaSV.Enabled = false;
            this.btnThemSV.Enabled = false;
            this.btnXoa.Enabled = false;
            this.pnTTSV.Enabled = true;
            int r = tableQuanLySinhVien.CurrentCell.RowIndex;

            txtMaSV.Text = tableQuanLySinhVien.Rows[r].Cells[0].Value.ToString();
            txtMaSV.Enabled = false;
        }

        private void SuaSV()
        {
            try
            {
                string a = rdNamSV.Checked ? "Nam" : "Nu";
                blSinhVien.themSV(txtMaSV.Text, txtChuyenNganhSV.Text, txtKhoaSV.Text, DateTime.Now.Date, dateHanPhongSV.Value.Date, txtMaphongSV.Text, txtHoTenLotSV.Text, txtTenSV.Text, dateNSinhSV.Value.Date, a, txtQueQuanSV.Text, txtsdtSV.Text, txtCCCDSV.Text);
                MessageBox.Show("Đã thêm xong!");
                pnTTSV.Enabled = false;
                btnSuaSV.Enabled = true;
                btnLuaSV.Enabled = false;
                btnXoa.Enabled = true;
            }
            catch (SqlException)
            {
                DialogResult result = MessageBox.Show("Không thêm được, Bạn có muốn chỉnh sửa lại không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    pnTTSV.Enabled = false;
                    btnSuaSV.Enabled = true;
                    btnLuaSV.Enabled = false;
                    btnXoa.Enabled = true;
                }
            }
        }

        private void ThemSV()
        {
            try
            {
                string a = rdNamSV.Checked ? "Nam" : "Nu";
                blSinhVien.themSV(txtMaSV.Text, txtChuyenNganhSV.Text, txtKhoaSV.Text, DateTime.Now.Date, dateHanPhongSV.Value.Date, txtMaphongSV.Text, txtHoTenLotSV.Text, txtTenSV.Text, dateNSinhSV.Value.Date, a, txtQueQuanSV.Text, txtsdtSV.Text, txtCCCDSV.Text);
                MessageBox.Show("Đã thêm xong!");
                pnTTSV.Enabled = false;
                btnSuaSV.Enabled = true;
                btnLuaSV.Enabled = false;
                btnXoa.Enabled = true;
            }
            catch (SqlException)
            {
                DialogResult result = MessageBox.Show("Không thêm được, Bạn có muốn chỉnh sửa lại không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    pnTTSV.Enabled = false;
                    btnSuaSV.Enabled = true;
                    btnLuaSV.Enabled = false;
                    btnXoa.Enabled = true;
                }
            }
        }

        private void btnLuaSV_Click(object sender, EventArgs e)
        {
            if(chucnang == 1)
            {
                ThemSV();
            }    
            else if (chucnang == 2)
            {
                SuaSV();
            }
            chucnang = 0;
            LoadThongTinSinhVien(tableQuanLySinhVien);
        }

        private void btnTaiSV_Click(object sender, EventArgs e)
        {
            LoadThongTinSinhVien(tableQuanLySinhVien);
        }
    }

}
