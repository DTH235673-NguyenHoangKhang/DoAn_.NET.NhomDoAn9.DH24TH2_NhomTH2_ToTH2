using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLCHThuocNongDuoc
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        DataSet ds=new DataSet();
        SqlDataAdapter daNhanVien;
        private void frmNhanVien1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            string squerynhanvien = @"select manv,tennv,diachinv,sodienthoai from nhanvien where tinhtrang=1";
            daNhanVien= new SqlDataAdapter(squerynhanvien,conn);
            daNhanVien.Fill(ds, "tblNhanVien");
            dgDSNhanVien.DataSource = ds.Tables["tblNhanVien"];
            dgDSNhanVien.Columns["MaNV"].HeaderText = "Mã nhân viên";
            dgDSNhanVien.Columns["TenNV"].HeaderText = "Tên nhân viên";
            dgDSNhanVien.Columns["DiaChiNV"].HeaderText = "Địa chỉ";
            dgDSNhanVien.Columns["sodienthoai"].HeaderText = "Số điện thoại";
            dgDSNhanVien.Columns["MaNV"].Width = 60;
            dgDSNhanVien.Columns["TenNV"].Width=160;
            dgDSNhanVien.Columns["DiachiNV"].Width = 150;
            dgDSNhanVien.Columns["sodienthoai"].Width = 100;
            string sinsertnhanvien = @"insert into nhanvien(MaNV,TenNV,DiaChiNV,sodienthoai)
                                        values (@MaNV,@TenNV,@DiaChiNV,@sodienthoai)";
            SqlCommand cmdInsertNhanVien = new SqlCommand(sinsertnhanvien, conn);
            cmdInsertNhanVien.Parameters.Add("@MaNV", SqlDbType.Char,10, "MaNV");
            cmdInsertNhanVien.Parameters.Add("@TenNV", SqlDbType.NVarChar, 50, "TenNV");
            cmdInsertNhanVien.Parameters.Add("@DiaChiNV",SqlDbType.NVarChar,50,"DiaChiNV");
            cmdInsertNhanVien.Parameters.Add("@sodienthoai", SqlDbType.Char, 11, "sodienthoai");
            daNhanVien.InsertCommand = cmdInsertNhanVien;
            string sUpdateNhanVien = @"update NhanVien set TenNV=@TenNV,DiaChiNv=@DiaChiNV, sodienthoai=@sodienthoai
                                                        where MaNV=@MaNV and tinhtrang=1 "; 
            SqlCommand cmdUpdateNhanVien = new SqlCommand(sUpdateNhanVien, conn);
            cmdUpdateNhanVien.Parameters.Add("@MaNV", SqlDbType.Char, 10, "MaNV");
            cmdUpdateNhanVien.Parameters.Add("@TenNV", SqlDbType.NVarChar, 50, "TenNV");
            cmdUpdateNhanVien.Parameters.Add("@DiaChiNV", SqlDbType.NVarChar, 50, "DiaChiNV");
            cmdUpdateNhanVien.Parameters.Add("@sodienthoai", SqlDbType.Char, 11, "sodienthoai");
            daNhanVien.UpdateCommand = cmdUpdateNhanVien;
            string sDeleteNhanVien = @"delete from NhanVien where MaNV=@MaNV";
            SqlCommand cmdDeleteNhanVien= new SqlCommand(sDeleteNhanVien, conn);
            daNhanVien.DeleteCommand = cmdDeleteNhanVien;
            cmdDeleteNhanVien.Parameters.Add("@MaNV", SqlDbType.Char, 10, "MaNV");
            DataColumn[] primarykey = new DataColumn[1];
            primarykey[0] = ds.Tables["tblNhanVien"].Columns["MaNV"];
            ds.Tables["tblNhanVien"].PrimaryKey = primarykey;
        }
        private void dgDSNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr= dgDSNhanVien.SelectedRows[0];
            txtMaNV.Enabled = false;
            txtMaNV.Text = dr.Cells["MaNV"].Value.ToString();
            txtTen.Text = dr.Cells["TenNV"].Value.ToString();
            txtDiaChi.Text = dr.Cells["DiaChiNV"].Value.ToString();
            txtSDT.Text = dr.Cells["sodienthoai"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            if (txtMaNV.Text==""||txtTen.Text==""||txtDiaChi.Text==""||txtSDT.Text=="")
            {
                MessageBox.Show("Bạn vui lòng nhập đầy đủ thông tin");
                return;
            }
            txtMaNV.Text = txtMaNV.Text.Trim();
            if (txtMaNV.Text.Length != 4 || txtMaNV.Text[0] != 'N' || txtMaNV.Text[1] != 'V')
            {

                MessageBox.Show("Sai định dạng mã nhân viên(NV00)", "Thông báo");
                return;
            }
            for (int i = 2; i < 4; i++)
            {
                if (txtMaNV.Text[i] < 48 || txtMaNV.Text[i] > 57)
                {
                    MessageBox.Show("Sai định dạng mã nhân viên(NV00)", "Thông báo");
                    return;
                }
            }
            if (ds.Tables["tblNhanVien"].Rows.Find(txtMaNV.Text)!=null )
            {
                MessageBox.Show("Mã nhân viên đã tồn tại");
                return;
            }
            for (int i = 0; i < txtSDT.Text.Length; i++)
            {
                if (txtSDT.Text[i] < 48 || txtSDT.Text[i] > 57)
                {
                    MessageBox.Show("Số điện thoại phải là 1 chuỗi số", "Thông báo");
                    return;
                }
            }
            string check = "SELECT COUNT(*) FROM NhanVien WHERE MaNV = @MaNV AND tinhtrang = 0";
            SqlCommand cmdCheck = new SqlCommand(check, conn);
            cmdCheck.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
            conn.Open();
            int count = (int)cmdCheck.ExecuteScalar();
            if(count > 0) 
            {
                string update = "UPDATE NhanVien SET TenNV = @TenNV, DiaChiNV = @DiaChiNV, sodienthoai = @sodienthoai, tinhtrang = 1 WHERE MaNV = @MaNV";
                SqlCommand cmd = new SqlCommand(update, conn);
                cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                cmd.Parameters.AddWithValue("@TenNV", txtTen.Text);
                cmd.Parameters.AddWithValue("@DiaChiNV", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@sodienthoai", txtSDT.Text);
                cmd.ExecuteNonQuery();
                daNhanVien.Fill(ds, "tblNhanVien");
                return;
            }
            DataRow row= ds.Tables["tblNhanVien"].NewRow();
            row["MaNV"] = txtMaNV.Text;
            row["TenNV"] = txtTen.Text;
            row["DiaChiNV"] = txtDiaChi.Text;
            row["sodienthoai"] = txtSDT.Text;
            ds.Tables["tblNhanVien"].Rows.Add(row);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            if (dgDSNhanVien.SelectedRows.Count > 0)
            {
                conn.Open();
                string sql = "SELECT MAX(P.Ngaymuahang) FROM PhieuMuaHang P WHERE p.manv= @MaNV";
                string sql1 = "SELECT MAX(P.Ngaylapphieunhap) FROM PhieuNhapHang P WHERE p.manv= @MaNV";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                cmd.Parameters.AddWithValue("@MaNV", dgDSNhanVien.SelectedRows[0].Cells["MaNV"].Value.ToString());
                cmd1.Parameters.AddWithValue("@MaNV", dgDSNhanVien.SelectedRows[0].Cells["MaNV"].Value.ToString());
                object result = cmd.ExecuteScalar();
                object result1= cmd1.ExecuteScalar();
                DateTime today = DateTime.Now.AddMonths(-1);
                DateTime last;
                DateTime last1;
                if (result != null && result != DBNull.Value)
                {

                    last = (DateTime)result;
                }
                else
                {
                    last = DateTime.Now.AddYears(-1);

                }
                if (result1 != null && result1 != DBNull.Value)
                {

                    last1 = (DateTime)result1;
                }
                else
                {
                    last1 = DateTime.Now.AddYears(-1);

                }
                DateTime last2= last1> last ? last1 : last;
                if (last2 > today)
                {
                    MessageBox.Show($"Nhân viên có thao tác gần nhất vào ngày {last2.ToShortDateString()}. Không thể xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    string sql2 = "update nhanvien set tinhtrang=0 where manv=@MaNV";
                    SqlCommand cmd2 = new SqlCommand(sql2, conn);
                    cmd2.Parameters.AddWithValue("@MaNV", dgDSNhanVien.SelectedRows[0].Cells["MaNV"].Value.ToString());
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!");
                }
                DataGridViewRow d = dgDSNhanVien.SelectedRows[0];
                dgDSNhanVien.Rows.Remove(d);
                txtMaNV.Clear();
                txtTen.Clear();
                txtDiaChi.Clear();
                txtSDT.Clear();
                txtMaNV.Focus();
                txtMaNV.Enabled = true;
            }
            else
            {
                MessageBox.Show("Bạn phải chọn dòng cần xóa");
                return;
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgDSNhanVien.SelectedRows.Count > 0)
            {
                if (txtMaNV.Text == "" || txtTen.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "")
                {
                    MessageBox.Show("Bạn vui lòng nhập đầy đủ thông tin");
                    return;
                }
                for (int i = 0; i < txtSDT.Text.Trim().Length; i++)
                {
                    if (txtSDT.Text[i] < 48 || txtSDT.Text[i] > 57)
                    {
                        MessageBox.Show("Số điện thoại phải là 1 chuỗi số", "Thông báo");
                        return;
                    }
                }
                DataGridViewRow d = dgDSNhanVien.SelectedRows[0];
                DataRow row = ds.Tables["tblNhanVien"].Rows.Find(d.Cells["MaNV"].Value);
                row["MaNV"] = txtMaNV.Text;
                row["TenNV"] = txtTen.Text;
                row["DiaChiNV"] = txtDiaChi.Text;
                row["sodienthoai"] = txtSDT.Text;
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Bạn phải chọn dòng cần sửa");
                return;
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                daNhanVien.Update(ds, "tblNhanVien");
                MessageBox.Show("Lưu thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";

            ds.Tables["tblNhanVien"].RejectChanges();
            txtMaNV.Clear();
            txtTen.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtMaNV.Enabled = true;
            txtMaNV.Focus();
            ds.Tables["tblNhanVien"].Clear();
            string sql = $"select manv,tennv,diachinv,sodienthoai from nhanvien where tinhtrang=1 ";
            SqlDataAdapter tam = new SqlDataAdapter(sql, conn);
            tam.Fill(ds, "tblNhanVien");
            dgDSNhanVien.DataSource = ds.Tables["tblNhanVien"];
            MessageBox.Show("Hủy thành công");

        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
                this.Close();
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            int check = 0;
            for (int i = 0; i < dgDSNhanVien.RowCount - 1; i++)
                if (dgDSNhanVien.Rows[i].Cells[0].Value.ToString().Trim() == txtMaTim.Text)
                {
                    check = 1;
                    ds.Tables["tblNhanVien"].Clear();
                    string sql = $"select manv,tennv,diachinv,sodienthoai from nhanvien where tinhtrang=1 and manv='{txtMaTim.Text}'";
                    SqlDataAdapter tam= new SqlDataAdapter(sql, conn);
                    tam.Fill(ds, "tblNhanVien");
                    dgDSNhanVien.DataSource = ds.Tables["tblNhanVien"];
                }
            if (check == 0)
            {
                MessageBox.Show("Không tìm thấy nhân viên có mã " + txtMaTim.Text, "Thông báo");
            }
        }
    }
}
