using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
using System.Windows.Forms;
namespace QLCHThuocNongDuoc
{
    public partial class frmChiTietPhieuNhapHang : Form
    {
        public frmChiTietPhieuNhapHang(string s)
        {
            InitializeComponent();
            txtSoPhieuNhapHang.Text = s;
            txtSoPhieuNhapHang.Enabled = false;
        }
        DataSet ds = new DataSet();
        SqlDataAdapter daLoaiThuoc;
        SqlDataAdapter daTenThuoc;
        SqlDataAdapter daChiTietPhieuNhapHang;
        private void frmChiTietPhieuNhapHang_Load(object sender, EventArgs e)
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
            string sql = "SELECT c.stt,c.SoPhieuNhapHang,t.MaThuoc,l.TenLoaiThuoc,t.TenThuoc,c.SoLuong,t.gianhap,c.thanhtien" +
                    " FROM Thuoc t,loaithuoc l,chitietphieunhaphang c" +
                   $" where t.MaThuoc=c.MaThuoc and t.MaLT=l.MaLT and c.SoPhieuNhapHang='{txtSoPhieuNhapHang.Text}'";
            daChiTietPhieuNhapHang = new SqlDataAdapter(sql, conn);
            daChiTietPhieuNhapHang.Fill(ds, "tblChiTietPhieuNhapHang");
            dgDSCTPNH.DataSource = ds.Tables["tblChiTietPhieuNhapHang"];
            dgDSCTPNH.Columns["stt"].HeaderText = "STT";
            dgDSCTPNH.Columns["SoPhieuNhapHang"].HeaderText = "Số Phiếu Nhập Hàng";
            dgDSCTPNH.Columns["MaThuoc"].HeaderText = "Mã Thuốc";
            dgDSCTPNH.Columns["TenLoaiThuoc"].HeaderText = "Loại Thuốc";
            dgDSCTPNH.Columns["TenThuoc"].HeaderText = "Tên Thuốc";
            dgDSCTPNH.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgDSCTPNH.Columns["gianhap"].HeaderText = "Giá Nhập";
            dgDSCTPNH.Columns["thanhtien"].HeaderText = "Thành Tiền";
            dgDSCTPNH.Columns["stt"].Width = 20;
            dgDSCTPNH.Columns["SoPhieuNhapHang"].Width = 50;
            dgDSCTPNH.Columns["MaThuoc"].Width = 80;
            dgDSCTPNH.Columns["TenLoaiThuoc"].Width = 100;
            dgDSCTPNH.Columns["TenThuoc"].Width = 100;
            dgDSCTPNH.Columns["SoLuong"].Width = 80;
            dgDSCTPNH.Columns["gianhap"].Width = 100;
            dgDSCTPNH.Columns["thanhtien"].Width = 100;
            string strInsert = "INSERT INTO ChiTietPhieuNhapHang(stt,SoPhieuNhapHang,MaThuoc,SoLuong,thanhtien) " +
                "VALUES(@stt,@SoPhieuNhapHang,@MaThuoc,@SoLuong,@thanhtien)";
            SqlCommand cmdInsert = new SqlCommand(strInsert, conn);
            cmdInsert.Parameters.Add("@SoPhieuNhapHang", SqlDbType.Int, 10, "SoPhieuNhapHang");
            cmdInsert.Parameters.Add("@MaThuoc", SqlDbType.Char, 10, "MaThuoc");
            cmdInsert.Parameters.Add("@SoLuong", SqlDbType.Int, 10, "SoLuong");
            cmdInsert.Parameters.Add("@stt", SqlDbType.Int, 10, "stt");
            cmdInsert.Parameters.Add("@thanhtien", SqlDbType.Int, 10, "thanhtien");
            daChiTietPhieuNhapHang.InsertCommand = cmdInsert;
            string strDelete = "DELETE FROM ChiTietPhieuNhapHang WHERE SoPhieuNhapHang=@SoPhieuNhapHang and MaThuoc=@MaThuoc";
            SqlCommand cmdDelete = new SqlCommand(strDelete, conn);
            cmdDelete.Parameters.Add("@SoPhieuNhapHang", SqlDbType.Int, 10, "SoPhieuNhapHang");
            cmdDelete.Parameters.Add("@MaThuoc", SqlDbType.Char, 10, "MaThuoc");
            daChiTietPhieuNhapHang.DeleteCommand = cmdDelete;
            string strUpdate = "UPDATE ChiTietPhieuNhapHang SET stt=@stt,SoLuong=@SoLuong,thanhtien=@thanhtien " +
                "WHERE SoPhieuNhapHang=@SoPhieuNhapHang and MaThuoc=@MaThuoc";
            SqlCommand cmdUpdate = new SqlCommand(strUpdate, conn);
            cmdUpdate.Parameters.Add("@SoPhieuNhapHang", SqlDbType.Int, 10, "SoPhieuNhapHang");
            cmdUpdate.Parameters.Add("@MaThuoc", SqlDbType.Char, 10, "MaThuoc");
            cmdUpdate.Parameters.Add("@SoLuong", SqlDbType.Int, 10, "SoLuong");
            cmdUpdate.Parameters.Add("@stt", SqlDbType.Int, 10, "stt");
            cmdUpdate.Parameters.Add("@thanhtien", SqlDbType.Int, 10, "thanhtien");
            daChiTietPhieuNhapHang.UpdateCommand = cmdUpdate;
            DataColumn[] key = new DataColumn[2];
            key[0] = ds.Tables["tblChiTietPhieuNhapHang"].Columns["MaThuoc"];
            key[1] = ds.Tables["tblChiTietPhieuNhapHang"].Columns["SoPhieuNhapHang"];
            ds.Tables["tblChiTietPhieuNhapHang"].PrimaryKey = key;
            cboLoaiThuoc.SelectedIndex = -1;
            cboTenThuoc.SelectedIndex = -1;
        }
        private void cboLoaiThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            if (cboLoaiThuoc.SelectedValue != null && cboLoaiThuoc.SelectedValue is string)
            {
                cboTenThuoc.DataSource = null; 
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
        private void dgDSCTPNH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgDSCTPNH.SelectedRows[0];
            cboLoaiThuoc.Text = row.Cells["TenLoaiThuoc"].Value.ToString();
            cboTenThuoc.Text = row.Cells["TenThuoc"].Value.ToString();
            txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
            txtSoPhieuNhapHang.Enabled = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.Text == "" || cboTenThuoc.SelectedIndex < 0 || cboLoaiThuoc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ds.Tables["tblChiTietPhieuNhapHang"].Rows.Find(new object[] { cboTenThuoc.SelectedValue.ToString(), txtSoPhieuNhapHang.Text }) != null)
            {
                MessageBox.Show("Thuốc đã tồn tại trong phiếu nhập hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataRow row = ds.Tables["tblChiTietPhieuNhapHang"].NewRow();
            row["stt"] = ds.Tables["tblChiTietPhieuNhapHang"].Rows.Count + 1;
            row["SoPhieuNhapHang"] = txtSoPhieuNhapHang.Text;
            row["MaThuoc"] = cboTenThuoc.SelectedValue.ToString();
            row["TenLoaiThuoc"] = cboLoaiThuoc.Text;
            row["TenThuoc"] = cboTenThuoc.Text;
            row["SoLuong"] = txtSoLuong.Text;
            row["gianhap"] = txtGiaNhap.Text;
            row["thanhtien"] = int.Parse(txtGiaNhap.Text) * int.Parse(txtSoLuong.Text);
            ds.Tables["tblChiTietPhieuNhapHang"].Rows.Add(row);
            int tongtien = 0;
            DataTable d = ds.Tables["tblChiTietPhieuNhapHang"];
            if (d.Rows.Count > 0)
            {
                for (int i = 0; i < d.Rows.Count; i++)
                {
                    string mp = d.Rows[i]["SoPhieuNhapHang"].ToString();
                    DataRow[] rows = d.Select($"SoPhieuNhapHang='{mp}'");
                    tongtien += int.Parse(rows[i]["ThanhTien"].ToString());
                }

            }
            txtTongTien.Text = tongtien.ToString();
            daChiTietPhieuNhapHang.Update(ds, "tblChiTietPhieuNhapHang");
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgDSCTPNH.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn thuốc cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataGridViewRow row = dgDSCTPNH.SelectedRows[0];
            dgDSCTPNH.Rows.Remove(row);
            daChiTietPhieuNhapHang.Update(ds, "tblChiTietPhieuNhapHang");
            cboLoaiThuoc.SelectedIndex = -1;
            cboTenThuoc.SelectedIndex = -1;
            txtSoLuong.Clear();
            txtGiaNhap.Clear();
            txtSoPhieuNhapHang.Enabled = true;
            DataTable dt = ds.Tables["tblChiTietPhieuNhapHang"];
            DataRow[] r = dt.Select($"SoPhieuNhapHang={txtSoPhieuNhapHang.Text}");
            int vitri = int.Parse(r[0]["stt"].ToString());
            for (int i = vitri; i <= dgDSCTPNH.Rows.Count; i++)
            {
                dgDSCTPNH.Rows[i].Cells["stt"].Value = i;
            }
            daChiTietPhieuNhapHang.Update(ds, "tblChiTietPhieuNhapHang");
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgDSCTPNH.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn thuốc cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataGridViewRow row = dgDSCTPNH.SelectedRows[0];
            DataRow drow = ds.Tables["tblChiTietPhieuNhapHang"].Rows.Find(new object[] { cboTenThuoc.SelectedValue.ToString(), txtSoPhieuNhapHang.Text });
            drow["stt"] = row.Cells["stt"].Value.ToString();
            drow["SoPhieuNhapHang"] = txtSoPhieuNhapHang.Text;
            drow["MaThuoc"] = cboTenThuoc.SelectedValue.ToString();
            drow["TenLoaiThuoc"] = cboLoaiThuoc.Text;
            drow["TenThuoc"] = cboTenThuoc.Text;
            drow["SoLuong"] = txtSoLuong.Text;
            drow["gianhap"] = txtGiaNhap.Text;
            drow["thanhtien"] = int.Parse(txtGiaNhap.Text) * int.Parse(txtSoLuong.Text);
            daChiTietPhieuNhapHang.Update(ds, "tblChiTietPhieuNhapHang");
            int tongtien = 0;
            DataTable d = ds.Tables["tblChiTietPhieuNhapHang"];
            if (d.Rows.Count > 0)
            {
                for (int i = 0; i < d.Rows.Count; i++)
                {
                    string mp = d.Rows[i]["SoPhieuNhapHang"].ToString();
                    DataRow[] rows = d.Select($"SoPhieuNhapHang='{mp}'");
                    tongtien += int.Parse(rows[i]["ThanhTien"].ToString());
                }

            }
            txtTongTien.Text = tongtien.ToString();
            daChiTietPhieuNhapHang.Update(ds, "tblChiTietPhieuNhapHang");

        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
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
                    txtGiaNhap.Text = rowTT[0]["GiaNhap"].ToString();
                }
                else
                {
                    txtGiaNhap.Text = "";
                }
            }
            else
                txtGiaNhap.Text = "";
        }
        private void btnXuatPhieuNhap_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            string strUpdate = "UPDATE PhieuNhapHang SET TongTien=@TongTien " +
                "WHERE SoPhieuNhapHang=@SoPhieuNhapHang";
            SqlCommand cmdUpdate = new SqlCommand(strUpdate, conn);
            cmdUpdate.Parameters.AddWithValue("@SoPhieuNhapHang", txtSoPhieuNhapHang.Text);
            cmdUpdate.Parameters.AddWithValue("@TongTien", int.Parse(txtTongTien.Text));
            conn.Open();
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
            frmReportPhieuNhapHang f = new frmReportPhieuNhapHang(int.Parse(txtSoPhieuNhapHang.Text));
            f.ShowDialog();
            this.Close();
        }
    }
}
