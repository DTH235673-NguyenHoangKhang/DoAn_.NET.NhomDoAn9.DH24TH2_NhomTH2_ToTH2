using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHThuocNongDuoc
{
    public partial class frmPhieuNhapHang : Form
    {
        string user;
        public frmPhieuNhapHang()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        SqlDataAdapter daNhanVien;
        SqlDataAdapter daNhaCungCap;
        SqlDataAdapter daPhieuNhapHang;
        private void PhieuNhapHang_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True");
            daNhanVien = new SqlDataAdapter("SELECT * FROM NhanVien where tinhtrang=1", conn);
            daNhanVien.Fill(ds, "tblNhanVien");
            cboMaNV.DataSource = ds.Tables["tblNhanVien"];
            cboMaNV.DisplayMember = "MaNV";
            cboMaNV.ValueMember = "MaNV";
           
            daNhaCungCap = new SqlDataAdapter("SELECT * FROM NhaCungCap where tinhtrang=1", conn);
            daNhaCungCap.Fill(ds, "tblNhaCungCap");
            cboMaNhaCungCap.DataSource = ds.Tables["tblNhaCungCap"];
            cboMaNhaCungCap.DisplayMember = "MaNhaCungCap";
            cboMaNhaCungCap.ValueMember = "MaNhaCungCap";
            string sql = "select distinct p.trangthai,p.SoPhieuNhapHang,  p.MaNV, n.TenNV,p.MaNhaCungCap,ncc.TenNCC,ncc.SoDienThoaiNCC,ncc.DiaChiNCC,p.NgaylapphieuNhap,p.tongtien  " +
                " from NhaCungCap ncc,PhieuNhapHang p,nhanvien n " +
                " where p.MaNhaCungCap=ncc.MaNhaCungCap and p.MaNV=n.MaNV  order by sophieunhaphang asc";
            daPhieuNhapHang = new SqlDataAdapter(sql, conn);
            daPhieuNhapHang.Fill(ds, "tblPhieuNhapHang");
            dgDSPhieuNhapHang.DataSource = ds.Tables["tblPhieuNhapHang"];
            dgDSPhieuNhapHang.Columns["trangthai"].HeaderText = "Trạng thái";
            dgDSPhieuNhapHang.Columns["SoPhieuNhapHang"].HeaderText = "Số phiếu nhập hàng";
            dgDSPhieuNhapHang.Columns["MaNV"].HeaderText = "Mã nhân viên";
            dgDSPhieuNhapHang.Columns["TenNV"].HeaderText = "Nhân viên";
            dgDSPhieuNhapHang.Columns["MaNhaCungCap"].HeaderText = "Mã nhà cung cấp";
            dgDSPhieuNhapHang.Columns["TenNCC"].HeaderText = "Nhà cung cấp";
            dgDSPhieuNhapHang.Columns["SoDienThoaiNCC"].HeaderText = "Số điện thoại";
            dgDSPhieuNhapHang.Columns["DiaChiNCC"].HeaderText = "Địa chỉ";
            dgDSPhieuNhapHang.Columns["NgaylapphieuNhap"].HeaderText = "Ngày lập";
            dgDSPhieuNhapHang.Columns["tongtien"].HeaderText = "Tổng tiền";
            dgDSPhieuNhapHang.Columns["trangthai"].Width = 80;
            dgDSPhieuNhapHang.Columns["SoPhieuNhapHang"].Width = 60;
            dgDSPhieuNhapHang.Columns["MaNV"].Width = 50;
            dgDSPhieuNhapHang.Columns["TenNV"].Width = 100;
            dgDSPhieuNhapHang.Columns["MaNhaCungCap"].Width = 80;
            dgDSPhieuNhapHang.Columns["TenNCC"].Width = 100;
            dgDSPhieuNhapHang.Columns["SoDienThoaiNCC"].Width = 100;
            dgDSPhieuNhapHang.Columns["DiaChiNCC"].Width = 200;
            dgDSPhieuNhapHang.Columns["NgaylapphieuNhap"].Width = 100;
            dgDSPhieuNhapHang.Columns["tongtien"].Width = 100;
            string sqlinsert = "INSERT INTO PhieuNhapHang(trangthai,SoPhieuNhapHang,MaNV,MaNhaCungCap,NgaylapphieuNhap,tongtien) " +
                "VALUES(@trangthai,@SoPhieuNhapHang,@MaNV,@MaNhaCungCap,@NgaylapphieuNhap,@tongtien)";
            SqlCommand cmdinsert = new SqlCommand(sqlinsert, conn);
            cmdinsert.Parameters.Add("@SoPhieuNhapHang", SqlDbType.Int, 5, "SoPhieuNhapHang");
            cmdinsert.Parameters.Add("@MaNV", SqlDbType.Char,10 , "MaNV");
            cmdinsert.Parameters.Add("@MaNhaCungCap", SqlDbType.Char, 10, "MaNhaCungCap");
            cmdinsert.Parameters.Add("@NgaylapphieuNhap", SqlDbType.Date, 10, "NgaylapphieuNhap");
            cmdinsert.Parameters.Add("@trangthai", SqlDbType.NVarChar ,20, "trangthai");
            cmdinsert.Parameters.Add("@tongtien", SqlDbType.Int, 10, "tongtien");
            daPhieuNhapHang.InsertCommand = cmdinsert;
            string sqlupdate = "UPDATE PhieuNhapHang SET MaNV=@MaNV,MaNhaCungCap=@MaNhaCungCap,NgaylapphieuNhap=@NgaylapphieuNhap,trangthai=@trangthai,tongtien=@tongtien " +
                "WHERE SoPhieuNhapHang=@SoPhieuNhapHang";
            SqlCommand cmdupdate = new SqlCommand(sqlupdate, conn);
            cmdupdate.Parameters.Add("@SoPhieuNhapHang", SqlDbType.Int, 5, "SoPhieuNhapHang");
            cmdupdate.Parameters.Add("@MaNV", SqlDbType.Char, 10, "MaNV");
            cmdupdate.Parameters.Add("@MaNhaCungCap", SqlDbType.Char, 10, "MaNhaCungCap");
            cmdupdate.Parameters.Add("@NgaylapphieuNhap", SqlDbType.Date, 10, "NgaylapphieuNhap");
            cmdupdate.Parameters.Add("@trangthai", SqlDbType.NVarChar, 20, "trangthai");
            cmdupdate.Parameters.Add("@tongtien", SqlDbType.Int, 10, "tongtien");
            daPhieuNhapHang.UpdateCommand = cmdupdate;
            string sqldelete = "DELETE FROM ChiTietPhieuNhapHang WHERE SoPhieuNhapHang=@SoPhieuNhapHang " +
                " DELETE FROM PhieuNhapHang WHERE SoPhieuNhapHang=@SoPhieuNhapHang";
            SqlCommand cmddelete = new SqlCommand(sqldelete, conn);
            cmddelete.Parameters.Add("@SoPhieuNhapHang", SqlDbType.Int, 5, "SoPhieuNhapHang");
            daPhieuNhapHang.DeleteCommand = cmddelete;
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["tblPhieuNhapHang"].Columns["SoPhieuNhapHang"];
            ds.Tables["tblPhieuNhapHang"].PrimaryKey = key;
            cboMaNhaCungCap.SelectedIndex = -1;
            cboMaNV.SelectedIndex = -1;
        }

        private void dgDSPhieuNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgDSPhieuNhapHang.SelectedRows[0];
            txtSoPhieuNhapHang.Text = row.Cells["SoPhieuNhapHang"].Value.ToString();
            cboMaNV.SelectedValue = row.Cells["MaNV"].Value.ToString();
            cboMaNhaCungCap.SelectedValue = row.Cells["MaNhaCungCap"].Value.ToString();
            dtpNgayNhap.Value = Convert.ToDateTime(row.Cells["NgaylapphieuNhap"].Value);
            txtSoPhieuNhapHang.Enabled = false;

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

        private void cboMaNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNhaCungCap.SelectedValue != null)
            {
                object maNCC=cboMaNhaCungCap.SelectedValue;
                DataTable dtNCC=ds.Tables["tblNhaCungCap"];
                DataRow[] rows = dtNCC.Select($"MaNhaCungCap='{maNCC}'");
                if(rows.Length > 0)
                {
                    txtTenNCC.Text = rows[0]["TenNCC"].ToString();
                    txtDiaChiNCC.Text = rows[0]["DiaChiNCC"].ToString();
                    txtSDTNCC.Text = rows[0]["SoDienThoaiNCC"].ToString();
                }
                else
                {
                    txtTenNCC.Text = "";
                    txtDiaChiNCC.Text = "";
                    txtSDTNCC.Text = "";
                }
            }
            else
            {
                txtTenNCC.Text = "";
                txtDiaChiNCC.Text = "";
                txtSDTNCC.Text = "";
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtSoPhieuNhapHang.Text == "" || cboMaNV.SelectedIndex == -1 || cboMaNhaCungCap.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin");
                return;
            }
            DateTime today = DateTime.Now.Date;
            string dt = dtpNgayNhap.Value.ToString("yyyy-MM-dd");
            if (dt != today.ToString("yyyy-MM-dd"))
            {
                MessageBox.Show("Chỉ có thể thêm phiếu nhập hàng trong ngày!", "Thông báo");
                return;
            }
            if (txtSoPhieuNhapHang.Text.Length != 8)
            {
                MessageBox.Show("Sai định dạng số phiếu nhập hàng (20000000)", "Thông báo");
                return;
            }
            for (int i = 1; i < 8; i++)
            {
                if (txtSoPhieuNhapHang.Text[i] < 48 || txtSoPhieuNhapHang.Text[i] > 57)
                {
                    MessageBox.Show("Sai định dạng số phiếu nhập hàng(20000000)", "Thông báo");
                    return;
                }
            }
            if (ds.Tables["tblPhieuNhapHang"].Rows.Find(int.Parse(txtSoPhieuNhapHang.Text)) != null)
            {
                MessageBox.Show("Số phiếu nhập hàng đã tồn tại");
                return;
            }
            DataRow row = ds.Tables["tblPhieuNhapHang"].NewRow();
            row["SoPhieuNhapHang"] = int.Parse(txtSoPhieuNhapHang.Text);
            row["MaNV"] = cboMaNV.SelectedValue;
            object manv = cboMaNV.SelectedValue;
            DataTable dtNV = ds.Tables["tblNhanVien"];
            DataRow[] r = dtNV.Select($"MaNV='{manv}'");
            row["TenNv"] = r[0]["TenNV"].ToString();
            row["MaNhaCungCap"] = cboMaNhaCungCap.SelectedValue;
            object mancc = cboMaNhaCungCap.SelectedValue;
            DataTable dtNCC = ds.Tables["tblNhaCungCap"];
            DataRow[] r1 = dtNCC.Select($"MaNhaCungCap='{mancc}'");
            row["TenNCC"] = r1[0]["TenNCC"].ToString();
            row["SoDienThoaiNCC"] = r1[0]["SoDienThoaiNCC"].ToString();
            row["DiaChiNCC"] = r1[0]["DiaChiNCC"].ToString();
            row["trangthai"] = "Chưa duyệt";
            row["NgaylapphieuNhap"] = dtpNgayNhap.Value;
            row["tongtien"] = 0;
            ds.Tables["tblPhieuNhapHang"].Rows.Add(row);
            daPhieuNhapHang.Update(ds, "tblPhieuNhapHang");
            frmChiTietPhieuNhapHang fctpn = new frmChiTietPhieuNhapHang(txtSoPhieuNhapHang.Text);
            fctpn.ShowDialog();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            string soPhieu = txtSoPhieuNhapHang.Text;
            string sUpdateTongTien = $@"
        UPDATE PhieuNhapHang
        SET TongTien = ISNULL((
            SELECT SUM(SoLuong * GiaBan) 
            FROM ChiTietPhieuNhapHang,thuoc 
            WHERE ChiTietPhieuNhapHang.MaThuoc = thuoc.MaThuoc 
            AND SoPhieuNhapHang = '{soPhieu}'), 0)
        WHERE SoPhieuNhapHang = '{soPhieu}';";
            SqlCommand cmdUpdateTongTien = new SqlCommand(sUpdateTongTien, conn);
            cmdUpdateTongTien.ExecuteNonQuery();
            dgDSPhieuNhapHang.DataSource = null;
            string sdelete= $@" delete from chitietphieunhaphang where sophieunhaphang='{txtSoPhieuNhapHang.Text}'
                                delete from phieunhaphang where tongtien=0";
            SqlCommand cmddelete = new SqlCommand(sdelete, conn);
            try
            {
                cmddelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa phiếu nhập hàng trống: " + ex.Message);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            ds.Tables["tblPhieuNhapHang"].Rows.Clear();
            string sQueryPhieuNhapHang = @"select distinct p.trangthai,p.SoPhieuNhapHang,  p.MaNV, n.TenNV,p.MaNhaCungCap,ncc.TenNCC,ncc.SoDienThoaiNCC,ncc.DiaChiNCC,p.NgaylapphieuNhap ,p.tongtien " +
                " from NhaCungCap ncc,PhieuNhapHang p,nhanvien n " +
                " where p.MaNhaCungCap=ncc.MaNhaCungCap and p.MaNV=n.MaNV   ";
            SqlCommand cmdSelect = new SqlCommand(sQueryPhieuNhapHang, conn);
            SqlDataAdapter tempDa = new SqlDataAdapter(cmdSelect);
            tempDa.Fill(ds, "tblPhieuNhapHang"); 
            dgDSPhieuNhapHang.DataSource = ds.Tables["tblPhieuNhapHang"];
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            frmXacNhan fxn = new frmXacNhan();
            DialogResult r=fxn.ShowDialog();
            if (r != DialogResult.OK)
                return;
            
            if (dgDSPhieuNhapHang.SelectedRows[0] != null)
            {
                DataGridViewRow dr = dgDSPhieuNhapHang.SelectedRows[0];
                dgDSPhieuNhapHang.Rows.Remove(dr);
                txtSoPhieuNhapHang.Enabled = true;
                txtSoPhieuNhapHang.Clear();
                cboMaNhaCungCap.SelectedIndex = -1;
                cboMaNV.SelectedIndex = -1;
                try
                {
                    daPhieuNhapHang.Update(ds, "tblPhieuNHapHang");
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
            if(dgDSPhieuNhapHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn phải chọn phiếu nhập hàng cần sửa");
                return;
            }
            if (dgDSPhieuNhapHang.SelectedRows[0].Cells["trangthai"].Value.ToString()=="Đã duyệt")
            {
                MessageBox.Show("Phiếu đã duyệt không thể chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataGridViewRow dr= dgDSPhieuNhapHang.SelectedRows[0];
            DataRow row = ds.Tables["tblPhieuNhapHang"].Rows.Find(int.Parse(dr.Cells["SoPhieuNhapHang"].Value.ToString()));
            row["SoPhieuNhapHang"] = int.Parse(txtSoPhieuNhapHang.Text);
            row["MaNV"] = cboMaNV.SelectedValue;
            object manv = cboMaNV.SelectedValue;
            DataTable dtNV=ds.Tables["tblNhanVien"];
            DataRow[] r=dtNV.Select($"MaNV='{manv}'");
            row["TenNv"] = r[0]["TenNV"].ToString();
            row["MaNhaCungCap"] = cboMaNhaCungCap.SelectedValue;
            object mancc = cboMaNhaCungCap.SelectedValue;
            DataTable dtNCC = ds.Tables["tblNhaCungCap"];
            DataRow[] r1 = dtNCC.Select($"MaNhaCungCap='{mancc}'");
            row["TenNCC"] = r1[0]["TenNCC"].ToString();
            row["SoDienThoaiNCC"] = r1[0]["SoDienThoaiNCC"].ToString();
            row["DiaChiNCC"] = r1[0]["DiaChiNCC"].ToString();
            row["NgaylapphieuNhap"] = dtpNgayNhap.Value;
            object maphieu = int.Parse(txtSoPhieuNhapHang.Text);
            DataTable dtPNH = ds.Tables["tblPhieuNhapHang"];
            DataRow[] r2 = dtPNH.Select($"SoPhieuNhapHang='{maphieu}'");
            row["trangthai"] = r2[0]["trangthai"].ToString();
            daPhieuNhapHang.Update(ds, "tblPhieuNhapHang");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
               this.Close();
        }

        private void btnChiTietPhieuNhapHang_Click(object sender, EventArgs e)
        {
            frmReportPhieuNhapHang frptPNH = new frmReportPhieuNhapHang(int.Parse(txtSoPhieuNhapHang.Text));
            frptPNH.ShowDialog();
        }

        private void btnDuyetPhieuNhapHang_Click(object sender, EventArgs e)
        {
            if(dgDSPhieuNhapHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn phải chọn phiếu nhập hàng cần duyệt");
                return;
            }
            DataGridViewRow selectedRow = dgDSPhieuNhapHang.SelectedRows[0];
            if(selectedRow.Cells["trangthai"].Value.ToString() == "Đã duyệt")
            {
                MessageBox.Show("Phiếu nhập hàng đã được duyệt.");
                return;
            }
            DialogResult rs;
            rs = MessageBox.Show("Bạn có chắc chắn muốn duyệt, phiếu nhập sau khi duyệt sẽ không thể chỉnh sửa!","Thông báo",MessageBoxButtons.YesNo);
            if (rs != DialogResult.Yes)
                return;
            string maPhieuNhapHang = txtSoPhieuNhapHang.Text;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";

            string strUpdateThuoc = @"UPDATE thuoc
                                    SET SoLuongTon = SoLuongTon + (
                                    SELECT SUM(ct.SoLuong)
                                    FROM chitietphieunhaphang ct
                                    WHERE ct.MaThuoc = thuoc.MaThuoc 
                                    AND ct.SoPhieuNhapHang = @MaPhieu)
                                    WHERE MaThuoc IN (
                                    SELECT DISTINCT MaThuoc
                                    FROM chitietphieunhaphang
                                    WHERE SoPhieuNhapHang = @MaPhieu);";
            SqlCommand cmdUpdateThuoc = new SqlCommand(strUpdateThuoc, conn);
            cmdUpdateThuoc.Parameters.AddWithValue("@MaPhieu", maPhieuNhapHang);
            try
            {
                conn.Open();
                int rowsAffected = cmdUpdateThuoc.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật số lượng tồn: " + ex.Message);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            dtpNgayNhap.Value = DateTime.Now;
            DataGridViewRow dr=dgDSPhieuNhapHang.SelectedRows[0];
            DataRow r = ds.Tables["tblPhieuNhapHang"].Rows.Find(int.Parse(dr.Cells["SoPhieuNhapHang"].Value.ToString()));
            r["trangthai"] = "Đã duyệt";
            daPhieuNhapHang.Update(ds, "tblPhieuNhapHang");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            txtSoPhieuNhapHang.Enabled = true;
            txtSoPhieuNhapHang.Clear();
            cboMaNhaCungCap.SelectedIndex = -1;
            cboMaNV.SelectedIndex = -1;
            ds.Tables["tblPhieuNhapHang"].Clear();
            string sql = "select distinct p.trangthai,p.SoPhieuNhapHang,  p.MaNV, n.TenNV,p.MaNhaCungCap,ncc.TenNCC,ncc.SoDienThoaiNCC,ncc.DiaChiNCC,p.NgaylapphieuNhap,p.tongtien  " +
                         " from NhaCungCap ncc,PhieuNhapHang p,nhanvien n " +
                        $" where p.MaNhaCungCap=ncc.MaNhaCungCap and p.MaNV=n.MaNV";
            SqlCommand cmdSelect = new SqlCommand(sql, conn);
            SqlDataAdapter tempDa = new SqlDataAdapter(cmdSelect);
            tempDa.Fill(ds, "tblPhieuNhapHang");
            dgDSPhieuNhapHang.DataSource = ds.Tables["tblPhieuNhapHang"];
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
            daNhanVien= new SqlDataAdapter(sQueryMaNV, conn);
            daNhanVien.Fill(ds, "tblNhanVien");
            cboMaNV.DataSource = ds.Tables["tblNhanVien"];
            cboMaNV.DisplayMember = "MaNV";
            cboMaNV.ValueMember = "MaNV";
        }
        private void btnAlterNCC_Click(object sender, EventArgs e)
        {
            frmNhaCungCap f = new frmNhaCungCap();
            f.ShowDialog();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            cboMaNhaCungCap.DataSource = null; 
            if (ds.Tables.Contains("tblNhaCungCap"))
            {
                ds.Tables["tblNhaCungCap"].Rows.Clear();
            }
            daNhaCungCap = new SqlDataAdapter("SELECT * FROM NhaCungCap where tinhtrang=1", conn);
            daNhaCungCap.Fill(ds, "tblNhaCungCap");
            cboMaNhaCungCap.DataSource = ds.Tables["tblNhaCungCap"];
            cboMaNhaCungCap.DisplayMember = "MaNhaCungCap";
            cboMaNhaCungCap.ValueMember = "MaNhaCungCap";
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            int check = 0;
            for (int i = 0; i < dgDSPhieuNhapHang.RowCount - 1; i++)
                if (dgDSPhieuNhapHang.Rows[i].Cells[1].Value.ToString() == txtMaTim.Text)
                {
                    check = 1;
                    ds.Tables["tblPhieuNhapHang"].Clear();
                    string sql = "select distinct p.trangthai,p.SoPhieuNhapHang,  p.MaNV, n.TenNV,p.MaNhaCungCap,ncc.TenNCC,ncc.SoDienThoaiNCC,ncc.DiaChiNCC,p.NgaylapphieuNhap,p.tongtien  " +
                                 " from NhaCungCap ncc,PhieuNhapHang p,nhanvien n " +
                                 $" where p.MaNhaCungCap=ncc.MaNhaCungCap and p.MaNV=n.MaNV and sophieunhaphang={Convert.ToInt32(txtMaTim.Text)}";
                    SqlCommand cmdSelect = new SqlCommand(sql, conn);
                    SqlDataAdapter tempDa = new SqlDataAdapter(cmdSelect);
                    tempDa.Fill(ds, "tblPhieuNhapHang");
                    dgDSPhieuNhapHang.DataSource = ds.Tables["tblPhieuNhapHang"];
                }
            if (check == 0)
            {
                MessageBox.Show("Không tìm thấy phiếu nhập hàng có mã " + txtMaTim.Text, "Thông báo");
            }
        }
    }
}
