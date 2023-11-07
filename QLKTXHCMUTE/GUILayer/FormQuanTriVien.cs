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
        BLPhong blPhong;
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
            blPhong = new BLPhong();
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
            btnThemSV.Enabled = false;
            chucnang = 1;
            
            //blSinhVien.themSV(txtMaSV.Text, txtChuyenNganhSV.Text, txtKhoaSV.Text, DateTime.Now.Date, dateHanPhongSV.Value.Date, txtMaphongSV.Text, txtHoTenLotSV.Text, txtTenSV.Text, dateNSinhSV.Value.Date, a, txtQueQuanSV.Text, txtsdtSV.Text, txtCCCDSV.Text);
        }

        private void btnXoaSV_Click(object sender, EventArgs e)
        {
            try
            {
                int r = tableQuanLySinhVien.CurrentCell.RowIndex;
                blSinhVien.xoaSV(tableQuanLySinhVien.Rows[r].Cells[0].Value.ToString());
                MessageBox.Show("Đã Xóa xong!");
            }
            catch (SqlException a)
            {
                DialogResult result = MessageBox.Show(a.ToString(), "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                int r = tableQuanLySinhVien.CurrentCell.RowIndex;
                txtMaSV.Text = tableQuanLySinhVien.Rows[r].Cells[0].Value.ToString();
                txtHoTenLotSV.Text = tableQuanLySinhVien.Rows[r].Cells[1].Value.ToString();
                txtTenSV.Text = tableQuanLySinhVien.Rows[r].Cells[2].Value.ToString();
                dateNSinhSV.Value = DateTime.Parse(tableQuanLySinhVien.Rows[r].Cells[3].Value.ToString());
                rdNamSV.Checked = tableQuanLySinhVien.Rows[r].Cells[4].Value.ToString() == "Nam"? true: false;
                rdNuSV.Checked = tableQuanLySinhVien.Rows[r].Cells[4].Value.ToString() == "Nu" ? true : false;
                txtQueQuanSV.Text = tableQuanLySinhVien.Rows[r].Cells[5].Value.ToString();
                txtsdtSV.Text = tableQuanLySinhVien.Rows[r].Cells[6].Value.ToString();
                txtCCCDSV.Text = tableQuanLySinhVien.Rows[r].Cells[7].Value.ToString();
                txtKhoaSV.Text = tableQuanLySinhVien.Rows[r].Cells[8].Value.ToString();
                txtChuyenNganhSV.Text = tableQuanLySinhVien.Rows[r].Cells[9].Value.ToString();
                txtMaphongSV.Text = tableQuanLySinhVien.Rows[r].Cells[10].Value.ToString();
                dateHanPhongSV.Value = DateTime.Parse(tableQuanLySinhVien.Rows[r].Cells[12].Value.ToString());
            }
        }

        private void btnSuaSV_Click(object sender, EventArgs e)
        {
            chucnang = 2;
            this.btnSuaSV.Enabled = false;
            this.btnThemSV.Enabled = false;
            this.btnXoa.Enabled = false;
            this.pnTTSV.Enabled = true;
            this.btnLuaSV.Enabled = true;
            int r = tableQuanLySinhVien.CurrentCell.RowIndex;

            txtMaSV.Text = tableQuanLySinhVien.Rows[r].Cells[0].Value.ToString();
            txtMaSV.Enabled = false;
        }

        private void SuaSV()
        {
            try
            {
                blSinhVien.CạpNhatThongTinSinhVien(txtMaSV.Text, txtHoTenLotSV.Text, txtTenSV.Text, dateNSinhSV.Value.Date, txtQueQuanSV.Text, txtsdtSV.Text);
                MessageBox.Show("Đã Cập nhật thành công!");
                pnTTSV.Enabled = false;
                btnSuaSV.Enabled = true;
                btnLuaSV.Enabled = false;
                btnXoa.Enabled = true;
            }
            catch (SqlException a)
            {
                DialogResult result = MessageBox.Show(a.ToString(), "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    pnTTSV.Enabled = false;
                    btnSuaSV.Enabled = true;
                    btnLuaSV.Enabled = false;
                    btnXoa.Enabled = true;
                }
            }
        }

        private void clearAll()
        {
            txtCCCDSV.Text = string.Empty;
            txtCCCDSV.Text = string.Empty;
            txtChuyenNganhSV.Text = string.Empty;
            txtHoTenLotSV.Text = string.Empty;
            txtKhoaSV.Text = string.Empty;
            txtMaSV.Text = string.Empty;
            txtsdtSV.Text = string.Empty;
            txtMaphongSV.Text = string.Empty;
            txtQueQuanSV.Text = string.Empty;
            txtTenSV.Text = string.Empty;
            txtMaphongSV.Text = string.Empty;
        }

        private void ThemSV()
        {
            try
            {
                string a = rdNamSV.Checked ? "Nam" : "Nu";
                blSinhVien.themSV(txtMaSV.Text, txtChuyenNganhSV.Text, txtKhoaSV.Text, DateTime.Now.Date, dateHanPhongSV.Value.Date, txtMaphongSV.Text, txtHoTenLotSV.Text, txtTenSV.Text, dateNSinhSV.Value.Date, a, txtQueQuanSV.Text, txtsdtSV.Text, txtCCCDSV.Text);
                MessageBox.Show("Đã thêm xong!");
                chucnang = 0;

            }
            catch (SqlException a)
            {
                DialogResult result = MessageBox.Show(a.Message.ToString()  + ". Bạn còn muốn tiếp tục chỉnh sửa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    return;
                }
            }
            pnTTSV.Enabled = false;
            btnSuaSV.Enabled = true;
            btnLuaSV.Enabled = false;
            btnXoa.Enabled = true;
            btnThemSV.Enabled = true;
            clearAll();
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
            LoadThongTinSinhVien(tableQuanLySinhVien);
        }

        private void btnTaiSV_Click(object sender, EventArgs e)
        {
            LoadThongTinSinhVien(tableQuanLySinhVien);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void txtMaPhongHD_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = blHoaDon.XemThongTinHoaDonCuaPhong(this.txtMaPhongHD.Text);
            tableHoaDon.DataSource = dt;
            tableHoaDon.Columns["MaHD"].HeaderText = "Mã hóa đơn";
            tableHoaDon.Columns["MaPhong"].HeaderText = "Mã phòng";
            tableHoaDon.Columns["TienNuoc"].HeaderText = "Tiền điện";
            tableHoaDon.Columns["TienDien"].HeaderText = "Tiền nước";
            tableHoaDon.Columns["TongTien"].HeaderText = "Tổng tiền";
            tableHoaDon.Columns["NgayGhi"].HeaderText = "Ngày ghi";
            tableHoaDon.Columns["NuocThangTruoc"].HeaderText = "Nước tháng trước";
            tableHoaDon.Columns["DienThangTruoc"].HeaderText = "Điện tháng trước";
            tableHoaDon.Columns["NuocThangNay"].HeaderText = "Nước tháng này";
            tableHoaDon.Columns["DienThangNay"].HeaderText = "Điện tháng này";
            tableHoaDon.Columns["SoDienSuDung"].HeaderText = "Số điện sử dụng";
            tableHoaDon.Columns["SoNuocSuDung"].HeaderText = "Số nước sử dụng";
            tableHoaDon.Columns["DaThanhToan"].HeaderText = "Đã thanh toán";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            blHoaDon.GhiHoaDon(txtMaHD.Text, txtMaPhongHD.Text, int.Parse(txtM3Nuoc.Text), int.Parse(txtKgDienj.Text), (cbThanhtoan.Checked)? 1:0);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            blPhong.themPhong(txtMaPhong.Text, cbLoaiPhong.Text, txtMoTaphong.Text, cbToa.Text);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            blPhong.SuaThongTinPhong(txtMaPhong.Text, cbLoaiPhong.Text, txtMoTaphong.Text, cbToa.Text);
        }

        private void cbXemHDaTT_CheckedChanged(object sender, EventArgs e)
        {
            blHoaDon.XemHoaDonChuaThanhToan(txtMaPhong.Text);
        }
    }

}
