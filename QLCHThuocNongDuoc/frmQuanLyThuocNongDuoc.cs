using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLCHThuocNongDuoc
{
    public partial class frmQuanLyThuocNongDuoc : Form
    {
        public frmQuanLyThuocNongDuoc()
        {
            InitializeComponent();
        }
        public frmQuanLyThuocNongDuoc(int x)
        {
            InitializeComponent();
            btnXoa.Enabled = false;
        }
        DataSet ds = new DataSet("dsQLCHThuocNongDuoc");
        SqlDataAdapter daLoaiThuoc;
        SqlDataAdapter daDonViTinh;
        SqlDataAdapter daNhaCungCap;
        SqlDataAdapter daThuoc;
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            string sQueryLoaiThuoc = @"select * from LoaiThuoc";
            daLoaiThuoc = new SqlDataAdapter(sQueryLoaiThuoc, conn);
            daLoaiThuoc.Fill(ds, "tblLoaiThuoc");
            cboLoaiThuoc.DataSource = ds.Tables["tblLoaiThuoc"];
            cboLoaiThuoc.DisplayMember = "TenLoaiThuoc";
            cboLoaiThuoc.ValueMember = "MaLT";
            string sQueryDonViTinh = @"select * from DonViTinh";
            daDonViTinh = new SqlDataAdapter(sQueryDonViTinh, conn);
            daDonViTinh.Fill(ds, "tblDonViTinh");
            cboDonViTinh.DataSource = ds.Tables["tblDonViTinh"];
            cboDonViTinh.DisplayMember = "TenDonVi";
            cboDonViTinh.ValueMember = "MaDVT";
            string sQueryNhaCungCap = @"select * from NhaCungCap where tinhtrang=1";
            daNhaCungCap = new SqlDataAdapter(sQueryNhaCungCap, conn);
            daNhaCungCap.Fill(ds, "tblNhaCungCap");
            cboNhaCungCap.DataSource = ds.Tables["tblNhaCungCap"];
            cboNhaCungCap.DisplayMember = "TenNCC";
            cboNhaCungCap.ValueMember = "MaNhaCungCap";
            string sQueryThuoc = @"select t.*, l.TenLoaiThuoc, d.TenDonVi, n.TenNCC from Thuoc t, LoaiThuoc l, DonViTinh d, NhaCungCap n where t.MaLT=l.MaLT and t.MaDVT=d.MaDVT and t.MaNhaCungCap=n.MaNhaCungCap";
            daThuoc = new SqlDataAdapter(sQueryThuoc, conn);
            daThuoc.Fill(ds, "tblDSThuoc");
            dgDSThuocNongDuoc.DataSource = ds.Tables["tblDSThuoc"];
            dgDSThuocNongDuoc.Columns["MaThuoc"].HeaderText = "Mã Thuốc";
            dgDSThuocNongDuoc.Columns["TenThuoc"].HeaderText = "Tên Thuốc";
            dgDSThuocNongDuoc.Columns["TenNCC"].HeaderText = "Nhà cung cấp";
            dgDSThuocNongDuoc.Columns["TenLoaiThuoc"].HeaderText = "Loại Thuốc";
            dgDSThuocNongDuoc.Columns["TenDonVi"].HeaderText = "Đơn vị tính";
            dgDSThuocNongDuoc.Columns["SoLuongTon"].HeaderText = "Số Lượng Tồn";
            dgDSThuocNongDuoc.Columns["GiaBan"].HeaderText = "Giá Bán";
            dgDSThuocNongDuoc.Columns["GiaNhap"].HeaderText = "Giá Nhập";
            dgDSThuocNongDuoc.Columns["MaLT"].Visible = false;
            dgDSThuocNongDuoc.Columns["MaDVT"].Visible = false;
            dgDSThuocNongDuoc.Columns["MaNhaCungCap"].Visible = false;
            dgDSThuocNongDuoc.Columns["MaThuoc"].Width = 80;
            dgDSThuocNongDuoc.Columns["TenThuoc"].Width = 150;
            dgDSThuocNongDuoc.Columns["TenNCC"].Width = 230;
            dgDSThuocNongDuoc.Columns["TenLoaiThuoc"].Width = 100;
            dgDSThuocNongDuoc.Columns["TenDonVi"].Width = 50;
            dgDSThuocNongDuoc.Columns["SoLuongTon"].Width = 50;
            dgDSThuocNongDuoc.Columns["GiaBan"].Width = 70;
            dgDSThuocNongDuoc.Columns["GiaNhap"].Width = 70;
            string sThemThuoc = @"INSERT INTO Thuoc(MaThuoc, TenThuoc, MaNhaCungCap, MaLT, MaDVT, SoLuongTon, GiaBan, GiaNhap)
                            VALUES (@MaThuoc, @TenThuoc, @MaNhaCungCap, @MaLT, @MaDVT, @SoLuongTon, @GiaBan, @GiaNhap)";
            SqlCommand cmThemThuoc = new SqlCommand(sThemThuoc, conn);
            cmThemThuoc.Parameters.Add("@MaThuoc", SqlDbType.NVarChar, 10, "MaThuoc");
            cmThemThuoc.Parameters.Add("@TenThuoc", SqlDbType.NVarChar, 50, "TenThuoc");
            cmThemThuoc.Parameters.Add("@MaNhaCungCap", SqlDbType.NVarChar, 5, "MaNhaCungCap");
            cmThemThuoc.Parameters.Add("@MaLT", SqlDbType.NVarChar, 5, "MaLT");
            cmThemThuoc.Parameters.Add("@MaDVT", SqlDbType.NVarChar, 10, "MaDVT");
            cmThemThuoc.Parameters.Add("@SoLuongTon", SqlDbType.Int, 0, "SoLuongTon");
            cmThemThuoc.Parameters.Add("@GiaBan", SqlDbType.Int, 0, "GiaBan");
            cmThemThuoc.Parameters.Add("@GiaNhap", SqlDbType.Int, 0, "GiaNhap");
            string sXoaThuoc = @"DELETE FROM Thuoc WHERE MaThuoc = @MaThuoc";
            SqlCommand cmXoaThuoc = new SqlCommand(sXoaThuoc, conn);
            string sSuaThuoc = @"UPDATE Thuoc SET TenThuoc=@TenThuoc, MaNhaCungCap=@MaNhaCungCap, MaLT=@MaLT, MaDVT=@MaDVT, SoLuongTon=@SoLuongTon, GiaBan=@GiaBan, GiaNhap=@GiaNhap WHERE MaThuoc=@MaThuoc";
            SqlCommand cmSuaThuoc = new SqlCommand(sSuaThuoc, conn);
            cmSuaThuoc.Parameters.Add("@MaThuoc", SqlDbType.NVarChar, 10, "MaThuoc");
            cmSuaThuoc.Parameters.Add("@TenThuoc", SqlDbType.NVarChar, 50, "TenThuoc");
            cmSuaThuoc.Parameters.Add("@MaNhaCungCap", SqlDbType.NVarChar, 5, "MaNhaCungCap");
            cmSuaThuoc.Parameters.Add("@MaLT", SqlDbType.NVarChar, 5, "MaLT");
            cmSuaThuoc.Parameters.Add("@MaDVT", SqlDbType.NVarChar, 10, "MaDVT");
            cmSuaThuoc.Parameters.Add("@SoLuongTon", SqlDbType.Int, 0, "SoLuongTon");
            cmSuaThuoc.Parameters.Add("@GiaBan", SqlDbType.Int, 0, "GiaBan");
            cmSuaThuoc.Parameters.Add("@GiaNhap", SqlDbType.Int, 0, "GiaNhap");
            daThuoc.UpdateCommand = cmSuaThuoc;
            cmXoaThuoc.Parameters.Add("@MaThuoc", SqlDbType.NVarChar, 10, "MaThuoc");
            daThuoc.DeleteCommand = cmXoaThuoc;
            daThuoc.InsertCommand = cmThemThuoc;
            DataColumn[] primaryKey = new DataColumn[1];
            primaryKey[0] = ds.Tables["tblDSThuoc"].Columns["MaThuoc"];
            ds.Tables["tblDSThuoc"].PrimaryKey = primaryKey;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtGiaBan.Text == "" || txtGiaNhap.Text == "" || txtMaThuoc.Text == "" || txtSoLuongTon.Text == "" || txtTenThuoc.Text == "")
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin");
                return;
            }
            if (ds.Tables["tblDSThuoc"].Rows.Find(txtMaThuoc.Text) != null)
            {
                MessageBox.Show("Mã thuốc đã tồn tại!");
                txtMaThuoc.Clear();
                txtMaThuoc.Focus();
                return;
            }
            if (txtMaThuoc.Text[0] != 'T' || txtMaThuoc.Text[1] != 'N' || txtMaThuoc.Text[2] != 'D' || txtMaThuoc.Text.Length != 5)
            {

                MessageBox.Show("Sai định dạng mã thuốc(TND00)", "Thông báo");
                return;
            }
            for (int i=3;i<5;i++)
            {
                if (txtMaThuoc.Text[i] < 48 || txtMaThuoc.Text[i] > 57)
                {
                    MessageBox.Show("Sai định dạng mã thuốc(TND00)", "Thông báo");
                    return;
                }
            }
            for (int i = 0; i < txtGiaBan.Text.Length; i++)
            {
                if (txtGiaBan.Text[i] < 48 || txtGiaBan.Text[i] > 57)
                {
                    MessageBox.Show("Giá bán phải là 1 con số dương", "Thông báo");
                    return;
                }
            }
            for (int i = 0; i < txtGiaNhap.Text.Length; i++)
            {
                if (txtGiaNhap.Text[i] < 48 || txtGiaNhap.Text[i] > 57)
                {
                    MessageBox.Show("Giá nhập phải là 1 con số dương", "Thông báo");
                    return;
                }
                
            }
            for (int i = 0; i < txtSoLuongTon.Text.Length; i++)
            {
                if (txtSoLuongTon.Text[i] < 48 || txtSoLuongTon.Text[i] > 57)
                {
                    MessageBox.Show("Số lượng tồn phải là 1 con số không âm", "Thông báo");
                    return;
                }
            }
            if(Convert.ToInt32(txtGiaBan.Text) <= Convert.ToInt32(txtGiaNhap.Text))
            {
                MessageBox.Show("Giá bán phải lớn hơn giá nhập","Thông báo");
                return;
            }
            DataRow row = ds.Tables["tblDSThuoc"].NewRow();
            row["MaThuoc"] = txtMaThuoc.Text;
            row["TenThuoc"] = txtTenThuoc.Text;
            row["MaNhaCungCap"] = cboNhaCungCap.SelectedValue;
            row["TenNCC"] = cboNhaCungCap.Text;
            row["MaLT"] = cboLoaiThuoc.SelectedValue;
            row["TenLoaiThuoc"] = cboLoaiThuoc.Text;
            row["MaDVT"] = cboDonViTinh.SelectedValue;
            row["TenDonVi"] = cboDonViTinh.Text;
            row["SoLuongTon"] = int.Parse(txtSoLuongTon.Text);
            row["GiaBan"] = int.Parse(txtGiaBan.Text);
            row["GiaNhap"] = int.Parse(txtGiaNhap.Text);
            if(int.Parse(txtSoLuongTon.Text) < 0 || int.Parse(txtGiaBan.Text) < 0 || int.Parse(txtGiaNhap.Text) < 0)
            {
                MessageBox.Show("Số lượng tồn, giá bán và giá nhập phải là số dương!");
                return;
            }
            else if(int.Parse(txtGiaBan.Text) < int.Parse(txtGiaNhap.Text))
            {
                MessageBox.Show("Giá bán phải lớn hơn hoặc bằng giá nhập!");
                return;
            }
            
            ds.Tables["tblDSThuoc"].Rows.Add(row);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            
                this.Close();
        }
        private void dgDSThuocNongDuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgDSThuocNongDuoc.SelectedRows[0];
            txtMaThuoc.Enabled = false;
            txtMaThuoc.Text = dr.Cells["MaThuoc"].Value.ToString().Trim();
            txtTenThuoc.Text = dr.Cells["TenThuoc"].Value.ToString();
            cboNhaCungCap.Text = dr.Cells["TenNCC"].Value.ToString();
            cboLoaiThuoc.Text = dr.Cells["TenLoaiThuoc"].Value.ToString();
            cboDonViTinh.Text = dr.Cells["TenDonVi"].Value.ToString();
            txtSoLuongTon.Text = dr.Cells["SoLuongTon"].Value.ToString();
            txtGiaBan.Text = dr.Cells["GiaBan"].Value.ToString();
            txtGiaNhap.Text = dr.Cells["GiaNhap"].Value.ToString();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgDSThuocNongDuoc.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn phải chọn thuốc cần sửa", "Thông báo");
                return;
            }
            else
            {
                if (txtMaThuoc.Text[0] != 'T' || txtMaThuoc.Text[1] != 'N' || txtMaThuoc.Text[2] != 'D' || txtMaThuoc.Text.Length != 5)
                {

                    MessageBox.Show("Sai định dạng mã thuốc(TND00)", "Thông báo");
                    return;
                }
                for (int i = 3; i < 5; i++)
                {
                    if (txtMaThuoc.Text[i] < 48 || txtMaThuoc.Text[i] > 57)
                    {
                        MessageBox.Show("Sai định dạng mã thuốc(TND00)", "Thông báo");
                        return;
                    }
                }
                for (int i = 0; i < txtGiaBan.Text.Length; i++)
                {
                    if (txtGiaBan.Text[i] < 48 || txtGiaBan.Text[i] > 57)
                    {
                        MessageBox.Show("Giá bán phải là 1 con số", "Thông báo");
                        return;
                    }

                    if (Convert.ToInt32(txtGiaBan.Text) <= 0)
                    {
                        MessageBox.Show("Giá bán phải là 1 số dương", "Thông báo");
                        return;
                    }
                }
                for (int i = 0; i < txtGiaNhap.Text.Length; i++)
                {
                    if (txtGiaNhap.Text[i] < 48 || txtGiaNhap.Text[i] > 57)
                    {
                        MessageBox.Show("Giá nhập phải là 1 con số", "Thông báo");
                        return;
                    }
                    if (Convert.ToInt32(txtGiaNhap.Text) <= 0)
                    {
                        MessageBox.Show("Giá nhập phải là 1 số dương", "Thông báo");
                        return;
                    }
                }
                for (int i = 0; i < txtSoLuongTon.Text.Length; i++)
                {
                    if (txtSoLuongTon.Text[i] < 48 || txtSoLuongTon.Text[i] > 57)
                    {
                        MessageBox.Show("Số lượng tồn phải là 1 con số", "Thông báo");
                        return;
                    }
                    if (Convert.ToInt32(txtSoLuongTon.Text) < 0)
                    {
                        MessageBox.Show("Số lượng tồn phải là 1 số không âm", "Thông báo");
                        return;
                    }
                }
                DataGridViewRow dr = dgDSThuocNongDuoc.SelectedRows[0];
                DataRow row = ds.Tables["tblDSThuoc"].Rows.Find(dr.Cells["MaThuoc"].Value.ToString());
                row["TenThuoc"] = txtTenThuoc.Text;
                row["MaNhaCungCap"] = cboNhaCungCap.SelectedValue;
                row["TenNCC"] = cboNhaCungCap.Text;
                row["MaLT"] = cboLoaiThuoc.SelectedValue;
                row["TenLoaiThuoc"] = cboLoaiThuoc.Text;
                row["MaDVT"] = cboDonViTinh.SelectedValue;
                row["SoLuongTon"] = int.Parse(txtSoLuongTon.Text);
                row["GiaBan"] = int.Parse(txtGiaBan.Text);
                row["GiaNhap"] = int.Parse(txtGiaNhap.Text);
                MessageBox.Show("Sửa thông tin thuốc thành công", "Thông báo");
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                daThuoc.Update(ds, "tblDSThuoc");
                MessageBox.Show("Lưu dữ liệu thành công", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(dgDSThuocNongDuoc.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn phải chọn thuốc cần xóa", "Thông báo");
                return;
            }
            DataGridViewRow d = dgDSThuocNongDuoc.SelectedRows[0];
            if(Convert.ToInt32(d.Cells["SoLuongTon"].Value) > 0)
            {
                MessageBox.Show(d.Cells["TenThuoc"].Value.ToString() + "còn số lượng tồn trong kho, không thể xóa!");
                return;
            }
            else
            {
                    DataGridViewRow dr = dgDSThuocNongDuoc.SelectedRows[0];
                    dgDSThuocNongDuoc.Rows.Remove(dr);
                    txtMaThuoc.Clear();
                    txtTenThuoc.Clear();
                    txtSoLuongTon.Clear();
                    txtGiaBan.Clear();
                    txtGiaNhap.Clear();
                    cboNhaCungCap.SelectedIndex = -1;
                    cboLoaiThuoc.SelectedIndex = -1;
                    cboDonViTinh.SelectedIndex = -1;
                    MessageBox.Show("Xóa thuốc thành công", "Thông báo");
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            ds.Tables["tblDSThuoc"].RejectChanges();
            txtMaThuoc.Clear();
            txtTenThuoc.Clear();
            txtSoLuongTon.Clear();
            txtGiaBan.Clear();
            txtGiaNhap.Clear();
            cboNhaCungCap.SelectedIndex = -1;
            cboLoaiThuoc.SelectedIndex = -1;
            cboDonViTinh.SelectedIndex = -1;
            txtMaThuoc.Enabled = true;
            ds.Tables["tblDSThuoc"].Clear();
            string sql = @"select t.*, l.TenLoaiThuoc, d.TenDonVi, n.TenNCC from Thuoc t, LoaiThuoc l, DonViTinh d, NhaCungCap n "
                          + $"where t.MaLT=l.MaLT and t.MaDVT=d.MaDVT and t.MaNhaCungCap=n.MaNhaCungCap ";
            SqlDataAdapter tam = new SqlDataAdapter(sql, conn);
            tam.Fill(ds, "tblDSThuoc");
            dgDSThuocNongDuoc.DataSource = ds.Tables["tblDSThuoc"];
            MessageBox.Show("Hủy thay đổi thành công", "Thông báo");
        }
        private void btnAlterNCC_Click(object sender, EventArgs e)
        {
            string conn = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            frmNhaCungCap fNCC = new frmNhaCungCap();
            fNCC.ShowDialog();
            cboNhaCungCap.DataSource = null;
            if(ds.Tables["tblNhaCungCap"] != null)
                ds.Tables["tblNhaCungCap"].Rows.Clear();
            string sQueryNhaCungCap = @"select * from NhaCungCap where tinhtrang=1";
            daNhaCungCap = new SqlDataAdapter(sQueryNhaCungCap, conn);
            daNhaCungCap.Fill(ds, "tblNhaCungCap");
            cboNhaCungCap.DataSource = ds.Tables["tblNhaCungCap"];
            cboNhaCungCap.DisplayMember = "TenNCC";
            cboNhaCungCap.ValueMember = "MaNhaCungCap";
        }
        private void btnAlterLoaiThuoc_Click(object sender, EventArgs e)
        {
            frmLoaiThuoc fLoaiThuoc = new frmLoaiThuoc();
            fLoaiThuoc.ShowDialog();
            cboLoaiThuoc.DataSource = null;
            if (ds.Tables["tblLoaiThuoc"] != null)
                ds.Tables["tblLoaiThuoc"].Rows.Clear();
            string conn = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            string sQueryLoaiThuoc = @"select * from LoaiThuoc";
            daLoaiThuoc = new SqlDataAdapter(sQueryLoaiThuoc, conn);
            daLoaiThuoc.Fill(ds, "tblLoaiThuoc");
            cboLoaiThuoc.DataSource = ds.Tables["tblLoaiThuoc"];
            cboLoaiThuoc.DisplayMember = "TenLoaiThuoc";
            cboLoaiThuoc.ValueMember = "MaLT";
        }
        private void btnAlterDVT_Click(object sender, EventArgs e)
        {
            frmDonViTinh fDVT = new frmDonViTinh();
            fDVT.ShowDialog();
            cboDonViTinh.DataSource = null;
            if (ds.Tables["tblDonViTinh"] != null)
                ds.Tables["tblDonViTinh"].Rows.Clear();
            string conn = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            string sQueryDonViTinh = @"select * from DonViTinh";
            daDonViTinh = new SqlDataAdapter(sQueryDonViTinh, conn);
            daDonViTinh.Fill(ds, "tblDonViTinh");
            cboDonViTinh.DataSource = ds.Tables["tblDonViTinh"];
            cboDonViTinh.DisplayMember = "TenDonVi";
            cboDonViTinh.ValueMember = "MaDVT";
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            int check = 0;
            for (int i = 0; i < dgDSThuocNongDuoc.RowCount - 1; i++)
                if (dgDSThuocNongDuoc.Rows[i].Cells[0].Value.ToString().Trim() == txtMaTim.Text)
                {
                    check = 1;
                    ds.Tables["tblDSThuoc"].Clear();
                    string sql = @"select t.*, l.TenLoaiThuoc, d.TenDonVi, n.TenNCC from Thuoc t, LoaiThuoc l, DonViTinh d, NhaCungCap n "
                                  +$"where t.MaLT=l.MaLT and t.MaDVT=d.MaDVT and t.MaNhaCungCap=n.MaNhaCungCap and mathuoc='{txtMaTim.Text}'";
                    SqlDataAdapter tam = new SqlDataAdapter(sql, conn);
                    tam.Fill(ds, "tblDSThuoc");
                    dgDSThuocNongDuoc.DataSource = ds.Tables["tblDSThuoc"];
                }
            if (check == 0)
            {
                MessageBox.Show("Không tìm thấy thuốc có mã " + txtMaTim.Text, "Thông báo");
            }
        }
    }
}
