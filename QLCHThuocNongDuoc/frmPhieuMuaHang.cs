using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using QLCHThuocNongDuoc;

namespace QLCHThuocNongDuoc
{
    public partial class frmPhieuMuaHang : Form
    {
        string user;
        public frmPhieuMuaHang(string user)
        {
            InitializeComponent();
            this.user = user;
        }
        DataSet ds = new DataSet();
        SqlDataAdapter daMaKH;
        SqlDataAdapter daMaNV;
        SqlDataAdapter daPhieuMuaHang;
        SqlDataAdapter daChitietphieumuahang;
        SqlDataAdapter dathuoc;
        private void frmPhieuMuaHang_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            string sQueryMaKH = @"select * from KhachHang where tinhtrang=1";
            daMaKH = new SqlDataAdapter(sQueryMaKH, conn);
            daMaKH.Fill(ds, "tblKhachHang");
            cboMaKH.DataSource = ds.Tables["tblKhachHang"];
            cboMaKH.DisplayMember = "MaKH";
            cboMaKH.ValueMember = "MaKH";
            string sQueryMaNV = @"select * from NhanVien where tinhtrang=1";
            daMaNV = new SqlDataAdapter(sQueryMaNV, conn);
            daMaNV.Fill(ds, "tblNhanVien");
            cboMaNV.DataSource = ds.Tables["tblNhanVien"];
            cboMaNV.DisplayMember = "MaNV";
            cboMaNV.ValueMember = "MaNV";
            cboMaNV.SelectedIndex = -1;
            if (this.user != "admin123")
            {
                cboMaNV.SelectedValue = this.user;
                object maNV = cboMaNV.SelectedValue;
                DataTable tblNV = ds.Tables["tblNhanVien"];
                DataRow[] rows = tblNV.Select($"MaNV = '{maNV}'");
                if (rows.Length > 0)
                {
                    txtTenNV.Text = rows[0]["TenNV"].ToString();
                }
                else
                {
                    txtTenNV.Text = "";
                }
                cboMaNV.Enabled = false;
                txtTenNV.Enabled = false;
                btnAlterNV.Visible = false;
            }
            string sQueryPhieuMuaHang = @"select distinct p.SoPhieuMuaHang,  p.MaNV, n.TenNV,p.MaKH,k.TenKH,k.SoDienThoaiKH,k.DiaChiKH, p.NgayMuaHang, p.TongTien
                             from Khachhang k,phieumuahang p,nhanvien n
                             where k.MaKH=p.MaKH and p.MaNV=n.MaNV ";
            daPhieuMuaHang = new SqlDataAdapter(sQueryPhieuMuaHang, conn);
            daPhieuMuaHang.Fill(ds, "tblPhieuMuaHang");
            dgDSPhieuMuaHnag.DataSource = ds.Tables["tblPhieuMuaHang"];
            dgDSPhieuMuaHnag.Columns["SoPhieuMuaHang"].HeaderText = "Số phiếu mua hàng";
            dgDSPhieuMuaHnag.Columns["MaNV"].HeaderText = "Mã nhân viên";
            dgDSPhieuMuaHnag.Columns["TenNV"].HeaderText = "Tên nhân viên";
            dgDSPhieuMuaHnag.Columns["MaKH"].HeaderText = "Mã khách hàng";
            dgDSPhieuMuaHnag.Columns["TenKH"].HeaderText = "Tên khách hàng";
            dgDSPhieuMuaHnag.Columns["SoDienThoaiKH"].HeaderText = "Số điện thoại";
            dgDSPhieuMuaHnag.Columns["DiaChiKH"].HeaderText = "Địa chỉ";
            dgDSPhieuMuaHnag.Columns["NgayMuaHang"].HeaderText = "Ngày mua hàng";
            dgDSPhieuMuaHnag.Columns["TongTien"].HeaderText = "Tổng tiền";
            dgDSPhieuMuaHnag.Columns["SoPhieuMuaHang"].Width = 70;
            dgDSPhieuMuaHnag.Columns["MaNV"].Width = 60;
            dgDSPhieuMuaHnag.Columns["TenNV"].Width = 150;
            dgDSPhieuMuaHnag.Columns["MaKH"].Width = 60;
            dgDSPhieuMuaHnag.Columns["TenKH"].Width = 150;
            dgDSPhieuMuaHnag.Columns["DiaChiKH"].Width = 180;
            dgDSPhieuMuaHnag.Columns["NgayMuaHang"].Width = 70;
            dgDSPhieuMuaHnag.Columns["NgayMuaHang"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgDSPhieuMuaHnag.Columns["TongTien"].Width = 100;
            string sInsertPhieuMuaHang = @"insert into PhieuMuaHang(SoPhieuMuaHang,MaKH,MaNV,NgayMuaHang,TongTien) 
                                                        values(@SoPhieuMuaHang,@MaKH,@MaNV,@NgayMuaHang,@TongTien)";
            SqlCommand cmdInsertPhieuMuaHang = new SqlCommand(sInsertPhieuMuaHang, conn);
            cmdInsertPhieuMuaHang.Parameters.Add("@SoPhieuMuaHang", SqlDbType.Int, 4, "SoPhieuMuaHang");
            cmdInsertPhieuMuaHang.Parameters.Add("@MaKH", SqlDbType.Char, 4, "MaKH");
            cmdInsertPhieuMuaHang.Parameters.Add("@MaNV", SqlDbType.Char, 4, "MaNV");
            cmdInsertPhieuMuaHang.Parameters.Add("@NgayMuaHang", SqlDbType.Date, 10, "NgayMuaHang");
            cmdInsertPhieuMuaHang.Parameters.Add("@TongTien", SqlDbType.Int, 10, "TongTien");
            daPhieuMuaHang.InsertCommand = cmdInsertPhieuMuaHang;
            string sUpdatePhieuMuaHang = @"update PhieuMuaHang set MaKH=@MaKH,MaNV=@MaNV,NgayMuaHang=@NgayMuaHang,TongTien=@TongTien
                                                        where SoPhieuMuaHang=@SoPhieuMuaHang";
            SqlCommand cmdUpdatePhieuMuaHang = new SqlCommand(sUpdatePhieuMuaHang, conn);
            cmdUpdatePhieuMuaHang.Parameters.Add("@SoPhieuMuaHang", SqlDbType.Int, 4, "SoPhieuMuaHang");
            cmdUpdatePhieuMuaHang.Parameters.Add("@MaKH", SqlDbType.Char, 4, "MaKH");
            cmdUpdatePhieuMuaHang.Parameters.Add("@MaNV", SqlDbType.Char, 4, "MaNV");
            cmdUpdatePhieuMuaHang.Parameters.Add("@NgayMuaHang", SqlDbType.Date, 10, "NgayMuaHang");
            cmdUpdatePhieuMuaHang.Parameters.Add("@TongTien", SqlDbType.Int, 10, "TongTien");
            daPhieuMuaHang.UpdateCommand = cmdUpdatePhieuMuaHang;
            string sDeletePhieuMuaHang = @"delete from chitietphieumuahang where SoPhieuMuaHang=@SoPhieuMuaHang
                                            delete from phieumuahang where SoPhieuMuaHang=@SoPhieuMuaHang";
            SqlCommand cmdDeletePhieuMuaHang = new SqlCommand(sDeletePhieuMuaHang, conn);
            cmdDeletePhieuMuaHang.Parameters.Add("@SoPhieuMuaHang", SqlDbType.Int, 4, "SoPhieuMuaHang");
            daPhieuMuaHang.DeleteCommand = cmdDeletePhieuMuaHang;
            DataColumn[] primarykey = new DataColumn[1];
            primarykey[0] = ds.Tables["tblPhieuMuaHang"].Columns["SoPhieuMuaHang"];
            ds.Tables["tblPhieuMuaHang"].PrimaryKey = primarykey;
            cboMaKH.SelectedIndex = -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSoPhieuMuaHang.Text == "" || cboMaKH.Text == "" || cboMaNV.Text == "")
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin");
                return;
            }
            DateTime today = DateTime.Now.Date;
            string dt = dtpNgayMua.Value.ToString("yyyy-MM-dd");
            if(dt!= today.ToString("yyyy-MM-dd"))
            {
                MessageBox.Show("Chỉ có thể tạo phiếu mua hàng trong ngày!", "Thông báo");
                return;
            }
            if (txtSoPhieuMuaHang.Text.Length != 8)
            {
                MessageBox.Show("Sai định dạng số phiếu mua hàng (10000000)", "Thông báo");
                return;
            }
            for (int i = 1; i < 8; i++)
            {
                if (txtSoPhieuMuaHang.Text[i] < 48 || txtSoPhieuMuaHang.Text[i] > 57)
                {
                    MessageBox.Show("Sai định dạng số phiếu mua hàng(10000000)", "Thông báo");
                    return;
                }
            }
            if (ds.Tables["tblPhieuMuaHang"].Rows.Find(txtSoPhieuMuaHang.Text) != null)
            {
                MessageBox.Show("Số phiếu mua hàng đã tồn tại");
                return;
            }
            DataRow row = ds.Tables["tblPhieuMuaHang"].NewRow();
            row["SoPhieuMuaHang"] = int.Parse(txtSoPhieuMuaHang.Text);
            row["MaKH"] = cboMaKH.SelectedValue;

            object maKH = cboMaKH.SelectedValue;
            DataTable tblKH = ds.Tables["tblKhachHang"];
            DataRow[] rowKH = tblKH.Select($"MaKH = '{maKH}'");
            row["TenKH"] = rowKH[0]["TenKH"].ToString();
            row["SoDienThoaiKH"] = rowKH[0]["SoDienThoaiKH"].ToString();
            row["DiaChiKH"] = rowKH[0]["DiaChiKH"].ToString();

            row["MaNV"] = cboMaNV.SelectedValue;
            object maNV = cboMaNV.SelectedValue;
            DataTable tblNV = ds.Tables["tblNhanVien"];
            DataRow[] rowNV = tblNV.Select($"MaNV = '{maNV}'");
            row["TenNV"] = rowNV[0]["TenNV"].ToString();

            row["NgayMuaHang"] = dtpNgayMua.Value;
            row["TongTien"] = 0;
            ds.Tables["tblPhieuMuaHang"].Rows.Add(row);
            try
            {
                daPhieuMuaHang.Update(ds, "tblPhieuMuaHang");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            frmChiTietPhieuMuaHang formChiTiet = new frmChiTietPhieuMuaHang(int.Parse(txtSoPhieuMuaHang.Text));
            formChiTiet.ShowDialog();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            dgDSPhieuMuaHnag.DataSource = null;
            ds.Tables["tblPhieuMuaHang"].Rows.Clear();
            string sQueryPhieuMuaHang = @"delete from phieumuahang where tongtien=0
                                select distinct p.SoPhieuMuaHang,  p.MaNV, n.TenNV,p.MaKH,k.TenKH,k.SoDienThoaiKH,k.DiaChiKH, p.NgayMuaHang, p.TongTien
                             from Khachhang k,phieumuahang p,nhanvien n
                             where k.MaKH=p.MaKH and p.MaNV=n.MaNV  ";
            daPhieuMuaHang = new SqlDataAdapter(sQueryPhieuMuaHang, conn);
            daPhieuMuaHang.Fill(ds, "tblPhieuMuaHang");
            dgDSPhieuMuaHnag.DataSource = ds.Tables["tblPhieuMuaHang"];
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now.Date;
            string dt = dtpNgayMua.Value.ToString("yyyy-MM-dd");
            if (dt != today.ToString("yyyy-MM-dd"))
            {
                MessageBox.Show("Chỉ có thể xóa phiếu mua hàng trong ngày!", "Thông báo");
                return;
            }
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            if (dgDSPhieuMuaHnag.SelectedRows[0] != null)
            {
                DialogResult d;
                d = MessageBox.Show("Thao tác xóa đồng nghĩa với việc giao dịch này sẽ bị hủy. Bạn có thật sự muốn xóa? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (d != DialogResult.Yes)
                { return; }
                frmXacNhan f = new frmXacNhan();
                DialogResult d2 = f.ShowDialog();
                if (d2 != DialogResult.OK)
                {
                    MessageBox.Show("Xác nhận không thành công!", "Thông báo");
                    return;
                }
                string sp = dgDSPhieuMuaHnag.SelectedRows[0].Cells["SoPhieuMuaHang"].Value.ToString();
                string ut = "UPDATE THUOC " +
                   $"SET SoLuongTon = SoLuongTon + (SELECT ct.SoLuong FROM ChiTietPhieuMuaHang ct  WHERE ct.SoPhieuMuaHang = '{sp}'" +
                   " AND ct.MaThuoc = THUOC.MaThuoc) " +
                   $"WHERE MaThuoc IN (SELECT MaThuoc FROM ChiTietPhieuMuaHang    WHERE SoPhieuMuaHang = '{sp}');";
                SqlCommand u = new SqlCommand(ut, conn);
                conn.Open();
                u.ExecuteNonQuery();
                conn.Close();
                DataGridViewRow dr = dgDSPhieuMuaHnag.SelectedRows[0];
                dgDSPhieuMuaHnag.Rows.Remove(dr);
                txtSoPhieuMuaHang.Clear();
                cboMaKH.SelectedIndex = -1;
                cboMaNV.SelectedIndex = -1;
                txtDiaChiKH.Clear();
                txtSDTKH.Clear();
                dtpNgayMua.Value = DateTime.Now;
                txtSoPhieuMuaHang.Enabled = true;
                txtSoPhieuMuaHang.Focus();
                try
                {
                    daPhieuMuaHang.Update(ds, "tblPhieuMuaHang");
                    MessageBox.Show("Xóa thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Bạn phải chọn dòng cần xóa");
                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            DateTime today = DateTime.Now.Date;
            string dt = dtpNgayMua.Value.ToString("yyyy-MM-dd");
            if (dt != today.ToString("yyyy-MM-dd"))
            {
                MessageBox.Show("Chỉ có thể sửa phiếu mua hàng trong ngày!", "Thông báo");
                return;
            }
            if (dgDSPhieuMuaHnag.SelectedRows.Count>0)
            {
                DataGridViewRow dr = dgDSPhieuMuaHnag.SelectedRows[0];
                DataRow row = ds.Tables["tblPhieuMuaHang"].Rows.Find(dr.Cells["SoPhieuMuaHang"].Value);
                row["SoPhieuMuaHang"] = int.Parse(txtSoPhieuMuaHang.Text);
                row["MaKH"] = cboMaKH.SelectedValue;
                object maKH = cboMaKH.SelectedValue;
                DataTable tblKH = ds.Tables["tblKhachHang"];
                DataRow[] rowKH = tblKH.Select($"MaKH = '{maKH}'");
                row["TenKH"] = rowKH[0]["TenKH"].ToString();
                row["SoDienThoaiKH"] = rowKH[0]["SoDienThoaiKH"].ToString();
                row["DiaChiKH"] = rowKH[0]["DiaChiKH"].ToString();
                row["MaNV"] = cboMaNV.SelectedValue;
                object maNV = cboMaNV.SelectedValue;
                DataTable tblNV = ds.Tables["tblNhanVien"];
                DataRow[] rowNV = tblNV.Select($"MaNV = '{maNV}'");
                row["TenNV"] = rowNV[0]["TenNV"].ToString();
                row["NgayMuaHang"] = dtpNgayMua.Value;
                row["TongTien"] = dr.Cells["TongTien"].Value;
                try
                {
                    daPhieuMuaHang.Update(ds, "tblPhieuMuaHang");
                    MessageBox.Show("Sửa thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Bạn phải chọn dòng cần sửa");
                return;
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
                this.Close();
        }
        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNV.SelectedValue != null)
            {
                object maNV = cboMaNV.SelectedValue;

                DataTable tblNV = ds.Tables["tblNhanVien"];

                DataRow[] rows = tblNV.Select($"MaNV = '{maNV}'");

                if (rows.Length > 0)
                {

                    txtTenNV.Text = rows[0]["TenNV"].ToString();
                }
                else
                {

                    txtTenNV.Text = "";
                }
            }
            else
            {
                txtTenNV.Text = "";
            }

        }
        private void cboMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaKH.SelectedValue != null)
            {
                object maKH = cboMaKH.SelectedValue;
                DataTable tblKH = ds.Tables["tblKhachHang"];
                DataRow[] rows = tblKH.Select($"MaKH = '{maKH}'");
                if (rows.Length > 0)
                {
                    txtTenKH.Text = rows[0]["TenKH"].ToString();
                    txtSDTKH.Text = rows[0]["SoDienThoaiKH"].ToString();
                    txtDiaChiKH.Text = rows[0]["DiaChiKH"].ToString();
                }
                else
                {
                    txtTenKH.Text = "";
                    txtDiaChiKH.Text = "";
                    txtDiaChiKH.Text = "";
                }
            }
            else
            {
                txtTenKH.Text = "";
                txtDiaChiKH.Text = "";
                txtDiaChiKH.Text = "";
            }
        }

        private void dgDSPhieuMuaHnag_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgDSPhieuMuaHnag.SelectedRows[0];
            txtSoPhieuMuaHang.Enabled = false;
            txtSoPhieuMuaHang.Text = dr.Cells["SoPhieuMuaHang"].Value.ToString();
            cboMaKH.SelectedValue = dr.Cells["MaKH"].Value;
            cboMaNV.SelectedValue = dr.Cells["MaNV"].Value;
            dtpNgayMua.Value = Convert.ToDateTime(dr.Cells["NgayMuaHang"].Value);
        }

        private void btnChiTietPhieuMuaHang_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtSoPhieuMuaHang.Text, out int soPhieu))
            {
                
                frmReportPhieuMuaHang f = new frmReportPhieuMuaHang(soPhieu);
                f.ShowDialog();
            }

        }

        private void btnAlterNV_Click(object sender, EventArgs e)
        {
            frmNhanVien f = new frmNhanVien();
            f.ShowDialog();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            cboMaNV.DataSource = null; 
            if (ds.Tables.Contains("tblNhanVien"))
            {
                ds.Tables["tblNhanVien"].Rows.Clear();
            }
            string sQueryMaNV = @"select * from NhanVien where tinhtrang=1";
            daMaNV = new SqlDataAdapter(sQueryMaNV, conn);
            daMaNV.Fill(ds, "tblNhanVien");
            cboMaNV.DataSource = ds.Tables["tblNhanVien"];
            cboMaNV.DisplayMember = "MaNV";
            cboMaNV.ValueMember = "MaNV";
        }

        private void btnAlterKH_Click(object sender, EventArgs e)
        {
            frmKhachHang f = new frmKhachHang();
            f.ShowDialog();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            cboMaKH.DataSource = null; 
            if (ds.Tables.Contains("tblKhachHang"))
            {
                ds.Tables["tblKhachHang"].Rows.Clear();
            }
            string sQueryMaKH = @"select * from KhachHang where tinhtrang=1";
            daMaKH = new SqlDataAdapter(sQueryMaKH, conn);
            daMaKH.Fill(ds, "tblKhachHang");
            cboMaKH.DataSource = ds.Tables["tblKhachHang"];
            cboMaKH.DisplayMember = "MaKH";
            cboMaKH.ValueMember = "MaKH";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            txtSoPhieuMuaHang.Clear();
            txtSoPhieuMuaHang.Enabled = true;
            cboMaKH.SelectedIndex = -1;
            if(this.user== "admin123")
                cboMaNV.SelectedIndex = -1;
            ds.Tables["tblPhieuMuaHang"].Clear();
            string sQueryPhieuMuaHang = $@"select distinct p.SoPhieuMuaHang,  p.MaNV, n.TenNV,p.MaKH,k.TenKH,k.SoDienThoaiKH,k.DiaChiKH, p.NgayMuaHang, p.TongTien
                             from Khachhang k,phieumuahang p,nhanvien n
                             where k.MaKH=p.MaKH and p.MaNV=n.MaNV";
            daPhieuMuaHang = new SqlDataAdapter(sQueryPhieuMuaHang, conn);
            daPhieuMuaHang.Fill(ds, "tblPhieuMuaHang");
            dgDSPhieuMuaHnag.DataSource = ds.Tables["tblPhieuMuaHang"];
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            int check = 0;
            for (int i = 0; i < dgDSPhieuMuaHnag.RowCount-1; i++)
                if (dgDSPhieuMuaHnag.Rows[i].Cells[0].Value.ToString() == txtMaTim.Text)
                {
                    check = 1;
                    ds.Tables["tblPhieuMuaHang"].Clear();
                    ds.Tables.Remove("tblPhieuMuaHang");
                    string sQueryPhieuMuaHang = $@"select distinct p.SoPhieuMuaHang,  p.MaNV, n.TenNV,p.MaKH,k.TenKH,k.SoDienThoaiKH,k.DiaChiKH, p.NgayMuaHang, p.TongTien
                             from Khachhang k,phieumuahang p,nhanvien n
                             where k.MaKH=p.MaKH and p.MaNV=n.MaNV and sophieumuahang={Convert.ToInt32(txtMaTim.Text)}";
                    daPhieuMuaHang = new SqlDataAdapter(sQueryPhieuMuaHang, conn);
                    daPhieuMuaHang.Fill(ds, "tblPhieuMuaHang");
                    dgDSPhieuMuaHnag.DataSource = ds.Tables["tblPhieuMuaHang"];
                }
            if (check == 0)
            {
                MessageBox.Show("Không tìm thấy phiếu mua hàng có mã " + txtMaTim.Text, "Thông báo");
            }

        }
    }
}

