using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
namespace QLCHThuocNongDuoc
{
    public partial class frmChiTietPhieuMuaHang : Form
    {
        public frmChiTietPhieuMuaHang(string s)
        {
            InitializeComponent();
            txtSoPhieuMuaHang.Text = s;
            btnThanhToan.Enabled = false;
            btnThanhToan.Text = "Phiếu đã thanh toán";
        }
        public frmChiTietPhieuMuaHang(int Sophieu)
        {
            InitializeComponent();
            txtSoPhieuMuaHang.Text = Sophieu.ToString();
            txtSoPhieuMuaHang.Enabled = false;
        }
        DataSet ds = new DataSet();
        SqlDataAdapter daLoaiThuoc;
        SqlDataAdapter daTenThuoc;
        SqlDataAdapter daChiTietPhieuMuaHang;
        private void frmChiTietPhieuMuaHang_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            string strSQL = "SELECT * FROM LOAITHUOC";
            daLoaiThuoc = new SqlDataAdapter(strSQL, conn);
            daLoaiThuoc.Fill(ds, "tblLoaiThuoc");
            cboLoaiThuoc.DataSource = ds.Tables["tblLoaiThuoc"];
            cboLoaiThuoc.DisplayMember = "TenLoaiThuoc";
            cboLoaiThuoc.ValueMember = "MaLT";
            string sSQL = "select * from thuoc t,loaithuoc l where t.MaLT=l.MaLT";
            daTenThuoc = new SqlDataAdapter(sSQL, conn);
            daTenThuoc.Fill(ds, "tblThuoc");
            cboTenThuoc.DataSource = ds.Tables["tblThuoc"];
            cboTenThuoc.DisplayMember = "TenThuoc";
            cboTenThuoc.ValueMember = "MaThuoc";
            strSQL = "SELECT c.stt,c.SoPhieuMuaHang,t.MaThuoc,l.TenLoaiThuoc,t.TenThuoc,c.SoLuong,t.GiaBan,c.GiamGia,c.ThanhTien" +
                    " FROM Thuoc t,loaithuoc l,chitietphieumuahang c" +
                   $" where t.MaThuoc=c.MaThuoc and t.MaLT=l.MaLT and c.SoPhieuMuaHang='{txtSoPhieuMuaHang.Text}'";
            daChiTietPhieuMuaHang = new SqlDataAdapter(strSQL, conn);
            daChiTietPhieuMuaHang.Fill(ds, "tblChiTietPhieuMuaHang");
            dgDSCTPMH.DataSource = ds.Tables["tblChiTietPhieuMuaHang"];
            dgDSCTPMH.Columns["stt"].HeaderText = "STT";
            dgDSCTPMH.Columns["SoPhieuMuaHang"].HeaderText = "Số phiếu mua";
            dgDSCTPMH.Columns["MaThuoc"].HeaderText = "Mã thuốc";
            dgDSCTPMH.Columns["TenLoaiThuoc"].HeaderText = "Loại thuốc";
            dgDSCTPMH.Columns["TenThuoc"].HeaderText = "Tên thuốc";
            dgDSCTPMH.Columns["SoLuong"].HeaderText = "Số lượng";
            dgDSCTPMH.Columns["GiaBan"].HeaderText = "Đơn giá";
            dgDSCTPMH.Columns["GiamGia"].HeaderText = "Giảm giá";
            dgDSCTPMH.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dgDSCTPMH.Columns["stt"].Width = 30;
            dgDSCTPMH.Columns["SoPhieuMuaHang"].Width = 50;
            dgDSCTPMH.Columns["MaThuoc"].Width = 60;
            dgDSCTPMH.Columns["TenThuoc"].Width = 150;
            dgDSCTPMH.Columns["TenLoaiThuoc"].Width = 100;
            dgDSCTPMH.Columns["SoLuong"].Width = 100;
            dgDSCTPMH.Columns["GiaBan"].Width = 100;
            dgDSCTPMH.Columns["GiamGia"].Width = 100;
            dgDSCTPMH.Columns["ThanhTien"].Width = 180;
            string strInsert = "INSERT INTO ChiTietPhieuMuaHang(stt,SoPhieuMuaHang,MaThuoc,SoLuong,GiamGia,ThanhTien) " +
                                "VALUES(@stt,@SoPhieuMuaHang,@MaThuoc,@SoLuong,@GiamGia,@ThanhTien)";
            SqlCommand cmdInsert = new SqlCommand(strInsert, conn);
            cmdInsert.Parameters.Add("@stt", SqlDbType.Int, 10, "stt");
            cmdInsert.Parameters.Add("@SoPhieuMuaHang", SqlDbType.Int, 10, "SoPhieuMuaHang");
            cmdInsert.Parameters.Add("@MaThuoc", SqlDbType.Char, 10, "MaThuoc");
            cmdInsert.Parameters.Add("@SoLuong", SqlDbType.Int, 10, "SoLuong");
            cmdInsert.Parameters.Add("@GiamGia", SqlDbType.Int, 10, "GiamGia");
            cmdInsert.Parameters.Add("@ThanhTien", SqlDbType.Int, 10, "ThanhTien");
            daChiTietPhieuMuaHang.InsertCommand = cmdInsert;
            string strDelete = "DELETE FROM ChiTietPhieuMuaHang WHERE SoPhieuMuaHang=@SoPhieuMuaHang and MaThuoc=@MaThuoc";
            SqlCommand cmdDelete = new SqlCommand(strDelete, conn);
            cmdDelete.Parameters.Add("@SoPhieuMuaHang", SqlDbType.Int, 10, "SoPhieuMuaHang");
            cmdDelete.Parameters.Add("@MaThuoc", SqlDbType.Char, 10, "MaThuoc");
            daChiTietPhieuMuaHang.DeleteCommand = cmdDelete;
            string strUpdate = "UPDATE ChiTietPhieuMuaHang SET stt=@stt,SoLuong=@SoLuong,GiamGia=@GiamGia WHERE SoPhieuMuaHang=@SoPhieuMuaHang and MaThuoc=@MaThuoc";
            SqlCommand cmdUpdate = new SqlCommand(strUpdate, conn);
            cmdUpdate.Parameters.Add("@stt", SqlDbType.Int, 10, "stt");
            cmdUpdate.Parameters.Add("@SoPhieuMuaHang", SqlDbType.Int, 10, "SoPhieuMuaHang");
            cmdUpdate.Parameters.Add("@MaThuoc", SqlDbType.Char, 10, "MaThuoc");
            cmdUpdate.Parameters.Add("@SoLuong", SqlDbType.Int, 10, "SoLuong");
            cmdUpdate.Parameters.Add("@GiamGia", SqlDbType.Int, 10, "GiamGia");
            cmdUpdate.Parameters.Add("@ThanhTien", SqlDbType.Int, 10, "ThanhTien");
            daChiTietPhieuMuaHang.UpdateCommand = cmdUpdate;
            DataColumn[] primarykey = new DataColumn[2];
            primarykey[0] = ds.Tables["tblChiTietPhieuMuaHang"].Columns["SoPhieuMuaHang"];
            primarykey[1] = ds.Tables["tblChiTietPhieuMuaHang"].Columns["MaThuoc"];
            ds.Tables["tblChiTietPhieuMuaHang"].PrimaryKey = primarykey;
            cboLoaiThuoc.SelectedIndex = -1;
            cboTenThuoc.SelectedIndex = -1;
            txtGiamGia.Text = "0";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.Text == "" || txtGiamGia.Text == "" || cboLoaiThuoc.SelectedIndex < 0 || cboTenThuoc.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin");
                return;
            }
            if (int.Parse(txtSoLuong.Text) <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!", "Thông báo");
                return;
            }
            if (int.Parse(txtGiamGia.Text) < 0 || int.Parse(txtGiamGia.Text)>50)
            {
                MessageBox.Show("Chỉ có thể giảm từ 0-50%", "Thông báo");
                return;
            }

            if (ds.Tables["tblChiTietPhieuMuaHang"].Rows.Find(new object[] { int.Parse(txtSoPhieuMuaHang.Text), cboTenThuoc.SelectedValue.ToString() }) != null)
            {
                MessageBox.Show("Đã tồn tại thuốc này trong phiếu mua hàng");
                return;
            }
            DataRow row = ds.Tables["tblChiTietPhieuMuaHang"].NewRow();
            row["stt"] = ds.Tables["tblChiTietPhieuMuaHang"].Rows.Count + 1;
            row["SoPhieuMuaHang"] = int.Parse(txtSoPhieuMuaHang.Text);
            row["MaThuoc"] = cboTenThuoc.SelectedValue;
            row["TenLoaiThuoc"] = cboLoaiThuoc.Text;
            row["TenThuoc"] = cboTenThuoc.Text;
            row["SoLuong"] = int.Parse(txtSoLuong.Text);
            row["GiaBan"] = int.Parse(txtDonGia.Text);
            row["GiamGia"] = int.Parse(txtGiamGia.Text);
            if (int.Parse(txtGiamGia.Text) == 0)
                row["ThanhTien"] = int.Parse(txtSoLuong.Text) * int.Parse(txtDonGia.Text);
            else
                row["ThanhTien"] = int.Parse(txtSoLuong.Text) * int.Parse(txtDonGia.Text)*(100-int.Parse(txtGiamGia.Text))/100;
            object maphieu = txtSoPhieuMuaHang.Text;
            DataTable dt = ds.Tables["tblChiTietPhieuMuaHang"];
            DataRow[] r = dt.Select($"SoPhieuMuaHang='{maphieu}'");
            object mathuoc = cboTenThuoc.SelectedValue;
            DataTable dtthuoc = ds.Tables["tblThuoc"];
            DataRow[] rowT = dtthuoc.Select($"MaThuoc = '{mathuoc}'");
            int tongtien = 0;
            if (rowT != null && int.Parse(rowT[0]["SoLuongTon"].ToString()) >= int.Parse(txtSoLuong.Text))
            {
                ds.Tables["tblChiTietPhieuMuaHang"].Rows.Add(row);
                DataTable d = ds.Tables["tblChiTietPhieuMuaHang"];
                if (d.Rows.Count > 0)
                {
                    for (int i = 0; i < d.Rows.Count; i++)
                    {
                        string mp = d.Rows[i]["SoPhieuMuaHang"].ToString();
                        DataRow[] rows = d.Select($"SoPhieuMuaHang='{mp}'");
                        tongtien += int.Parse(rows[i]["ThanhTien"].ToString());
                    }
                }
                txtTongTien.Text = tongtien.ToString();
            }
            else
            {
                
                MessageBox.Show(cboTenThuoc.Text + " không đủ số lượng!", "Thông báo");
                return;
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgDSCTPMH.SelectedRows.Count > 0)
            {
                DataGridViewRow d = dgDSCTPMH.SelectedRows[0];
                dgDSCTPMH.Rows.Remove(d);
                daChiTietPhieuMuaHang.Update(ds, "tblChiTietPhieuMuaHang");
                cboLoaiThuoc.SelectedIndex = 0;
                cboTenThuoc.SelectedIndex = 0;
                txtDonGia.Clear();
                txtSoLuong.Clear();
                txtGiamGia.Clear();
                int tongtien = 0;
                DataTable dt = ds.Tables["tblChiTietPhieuMuaHang"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string maphieu = dt.Rows[i]["SoPhieuMuaHang"].ToString();
                        DataRow[] rows = dt.Select($"SoPhieuMuaHang='{maphieu}'");
                        tongtien += int.Parse(rows[0]["ThanhTien"].ToString());
                    }

                }
                txtTongTien.Text = tongtien.ToString();
                MessageBox.Show("Xóa thành công");
                DataRow[] r=dt.Select($"SoPhieuMuaHang={txtSoPhieuMuaHang.Text}");
                int vitri = int.Parse(r[0]["stt"].ToString());
                for (int i = vitri; i <= dgDSCTPMH.Rows.Count; i++)
                {
                    dgDSCTPMH.Rows[i].Cells["stt"].Value = i;
                }
                daChiTietPhieuMuaHang.Update(ds, "tblChiTietPhieuMuaHang");
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgDSCTPMH.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dgDSCTPMH.SelectedRows[0];
                DataRow row = ds.Tables["tblChiTietPhieuMuaHang"].Rows.Find(new object[] { int.Parse(dr.Cells["SoPhieuMuaHang"].Value.ToString()), dr.Cells["MaThuoc"].Value.ToString() });
                row["SoPhieuMuaHang"] = int.Parse(txtSoPhieuMuaHang.Text);
                row["MaThuoc"] = cboTenThuoc.SelectedValue;
                row["TenLoaiThuoc"] = cboLoaiThuoc.SelectedValue;
                object maLT = cboLoaiThuoc.SelectedValue;
                DataTable tblLT = ds.Tables["tblThuoc"];
                DataRow[] rowLT = tblLT.Select($"MaLT = '{maLT}'");
                row["TenThuoc"] = rowLT[0]["TenThuoc"].ToString();
                row["SoLuong"] = int.Parse(txtSoLuong.Text);
                row["GiaBan"] = int.Parse(txtDonGia.Text);
                row["GiamGia"] = int.Parse(txtGiamGia.Text);
                if (int.Parse(txtGiamGia.Text) == 0)
                    row["ThanhTien"] = int.Parse(txtSoLuong.Text) * int.Parse(txtDonGia.Text);
                else
                    row["ThanhTien"] = int.Parse(txtSoLuong.Text) * int.Parse(txtDonGia.Text) * (100 - int.Parse(txtGiamGia.Text)) / 100;
                int tongtien = 0;
                DataTable d = ds.Tables["tblChiTietPhieuMuaHang"];
                if (d.Rows.Count > 0)
                {
                    for (int i = 0; i < d.Rows.Count; i++)
                    {
                        string maphieu = d.Rows[i]["SoPhieuMuaHang"].ToString();
                        DataRow[] rows = d.Select($"SoPhieuMuaHang='{maphieu}'");
                        tongtien += int.Parse(rows[0]["ThanhTien"].ToString());
                    }

                }
                txtTongTien.Text = tongtien.ToString();
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";

                string strUpdateThuoc = @"UPDATE phieumuahang
                                        SET TongTien = @TongTien
                                        WHERE SoPhieuMuaHang IN (
                                        SELECT DISTINCT sophieumuahang
                                        FROM chitietphieumuahang
                                        WHERE SoPhieuMuaHang = @MaPhieu);";
                string maPhieuMuaHang = txtSoPhieuMuaHang.Text;
                SqlCommand cmdUpdateThuoc = new SqlCommand(strUpdateThuoc, conn);
                cmdUpdateThuoc.Parameters.AddWithValue("@MaPhieu", maPhieuMuaHang);
                cmdUpdateThuoc.Parameters.AddWithValue("@TongTien", tongtien);
                   conn.Open();
                int rowsAffected = cmdUpdateThuoc.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                MessageBox.Show("Bạn phải chọn dòng cần sửa");
                return;
            }
        }
        private void LuuVaCapNhatTongTienPhieuMuaHang()
        {
            daChiTietPhieuMuaHang.Update(ds, "tblChiTietPhieuMuaHang");
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";

            string strUpdateThuoc = @"UPDATE phieumuahang
                                      SET TongTien = @TongTien
                                      WHERE SoPhieuMuaHang IN (
                                      SELECT DISTINCT sophieumuahang
                                      FROM chitietphieumuahang
                                      WHERE SoPhieuMuaHang = @MaPhieu);";
            string maPhieuMuaHang = txtSoPhieuMuaHang.Text;
            int tongtien = int.Parse(txtTongTien.Text);
            SqlCommand cmdUpdateThuoc = new SqlCommand(strUpdateThuoc, conn);
            cmdUpdateThuoc.Parameters.AddWithValue("@MaPhieu", maPhieuMuaHang);
            cmdUpdateThuoc.Parameters.AddWithValue("@TongTien", tongtien);
            conn.Open();
            int rowsAffected = cmdUpdateThuoc.ExecuteNonQuery();
            conn.Close();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.Close();
        }
        private void dgDSCTPMH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgDSCTPMH.SelectedRows[0];
            txtDonGia.Text = dr.Cells["GiaBan"].Value.ToString();
            txtSoLuong.Text = dr.Cells["SoLuong"].Value.ToString();
            txtGiamGia.Text = dr.Cells["GiamGia"].Value.ToString();
            cboLoaiThuoc.Text = dr.Cells["TenLoaiThuoc"].Value.ToString();
            cboTenThuoc.Text = dr.Cells["TenThuoc"].Value.ToString();
        }
        private void cboLoaiThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            if (cboLoaiThuoc.SelectedValue != null && cboLoaiThuoc.SelectedValue is string)
            {
                cboTenThuoc.DataSource = null; // Ngắt ràng buộc
                if (ds.Tables.Contains("tblThuoc"))
                {
                    ds.Tables["tblThuoc"].Rows.Clear();
                }
                string strSQL = $"select * from thuoc t,loaithuoc l where t.MaLT=l.MaLT and t.MaLT ='{cboLoaiThuoc.SelectedValue.ToString()}'";
                daTenThuoc = new SqlDataAdapter(strSQL, conn);
                daTenThuoc.Fill(ds, "tblThuoc");
                cboTenThuoc.DataSource = ds.Tables["tblThuoc"];
                cboTenThuoc.DisplayMember = "TenThuoc";
                cboTenThuoc.ValueMember = "MaThuoc";
            }
        }
        private void cboTenThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTenThuoc.SelectedValue != null)
            {
                object mathuoc = cboTenThuoc.SelectedValue;
                DataTable dt = ds.Tables["tblThuoc"];
                DataRow[] rowTT = dt.Select($"MaThuoc='{mathuoc}'");
                if (rowTT.Length > 0)
                {
                    txtDonGia.Text = rowTT[0]["GiaBan"].ToString();
                }
                else
                {
                    txtDonGia.Text = "";
                }
            }
            else
                txtDonGia.Text = "";
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có chắc chắn muốn thanh toán không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                LuuVaCapNhatTongTienPhieuMuaHang();
                string maPhieuMuaHang = txtSoPhieuMuaHang.Text;
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
                string strUpdateThuoc = @"UPDATE thuoc
                                        SET SoLuongTon = SoLuongTon - (
                                        SELECT SUM(ct.SoLuong)
                                        FROM chitietphieumuahang ct
                                        WHERE ct.MaThuoc = thuoc.MaThuoc 
                                        AND ct.SoPhieuMuaHang = @MaPhieu)
                                        WHERE MaThuoc IN (
                                        SELECT DISTINCT MaThuoc
                                        FROM chitietphieumuahang
                                        WHERE SoPhieuMuaHang = @MaPhieu);";
                SqlCommand cmdUpdateThuoc = new SqlCommand(strUpdateThuoc, conn);
                cmdUpdateThuoc.Parameters.AddWithValue("@MaPhieu", maPhieuMuaHang);
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
                this.Close();
                frmReportPhieuMuaHang f = new frmReportPhieuMuaHang(int.Parse(maPhieuMuaHang));
                f.ShowDialog();
            }
            else
            {
                return;
            }
        }
    }
}
