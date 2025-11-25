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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace QLCHThuocNongDuoc
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        SqlDataAdapter daKhachHang;
        private void KhachHang_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            string squerykhachhang = @"select makh,tenkh,sodienthoaikh, diachikh from khachhang where tinhtrang=1";
            daKhachHang = new SqlDataAdapter(squerykhachhang, conn);
            daKhachHang.Fill(ds, "tblKhachHang");
            dgDSKhachHang.DataSource = ds.Tables["tblKhachHang"];
            dgDSKhachHang.Columns["MaKH"].HeaderText = "Mã khách hàng";
            dgDSKhachHang.Columns["TenKH"].HeaderText = "Tên khách hàng";
            dgDSKhachHang.Columns["DiaChiKH"].HeaderText = "Địa chỉ";
            dgDSKhachHang.Columns["SoDienThoaiKH"].HeaderText = "Số điện thoại";
            dgDSKhachHang.Columns["MaKH"].Width = 60;
            dgDSKhachHang.Columns["TenKH"].Width = 160;
            dgDSKhachHang.Columns["DiaChiKH"].Width = 150;
            dgDSKhachHang.Columns["SoDienThoaiKH"].Width = 100;
            string sinsertkhachhang = @"insert into khachhang(MaKH,TenKH,DiaChiKH,SoDienThoaiKH)
                                        values (@MaKH,@TenKH,@DiaChiKH,@SoDienThoaiKH)";
            SqlCommand cmdInsertKhachHang = new SqlCommand(sinsertkhachhang, conn);
            cmdInsertKhachHang.Parameters.Add("@MaKH", SqlDbType.Char, 10, "MaKH");
            cmdInsertKhachHang.Parameters.Add("@TenKH", SqlDbType.NVarChar, 50, "TenKH");
            cmdInsertKhachHang.Parameters.Add("@DiaChiKH", SqlDbType.NVarChar, 50, "DiaChiKH");
            cmdInsertKhachHang.Parameters.Add("@SoDienThoaiKH", SqlDbType.Char, 11, "SoDienThoaiKH");
            daKhachHang.InsertCommand = cmdInsertKhachHang;
            string sUpdateKhachHang = @"update KhachHang set TenKH=@TenKH,DiaChiKH=@DiaChiKH, SoDienThoaiKH=@SoDienThoaiKH 
                                                        where MaKH=@MaKH";
            SqlCommand cmdUpdateKhachHang = new SqlCommand(sUpdateKhachHang, conn);
            cmdUpdateKhachHang.Parameters.Add("@MaKH", SqlDbType.Char, 10, "MaKH");
            cmdUpdateKhachHang.Parameters.Add("@TenKH", SqlDbType.NVarChar, 50, "TenKH");
            cmdUpdateKhachHang.Parameters.Add("@DiaChiKH", SqlDbType.NVarChar, 50, "DiaChiKH");
            cmdUpdateKhachHang.Parameters.Add("@SoDienThoaiKH", SqlDbType.Char, 11, "SoDienThoaiKH");
            daKhachHang.UpdateCommand = cmdUpdateKhachHang;
            string sDeleteKhachHang = @"delete from KhachHang where MaKH=@MaKH";
            SqlCommand cmdDeleteKhachHang = new SqlCommand(sDeleteKhachHang, conn);
            cmdDeleteKhachHang.Parameters.Add("@MaKH", SqlDbType.Char, 10, "MaKH");
            daKhachHang.DeleteCommand = cmdDeleteKhachHang;
            DataColumn[] primarykey = new DataColumn[1];
            primarykey[0] = ds.Tables["tblKhachHang"].Columns["MaKH"];
            ds.Tables["tblKhachHang"].PrimaryKey = primarykey;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            if (txtMaKH.Text == "" || txtTenKH.Text == "" || txtDiaChiKH.Text == "" || txtSDTKH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            txtMaKH.Text = txtMaKH.Text.Trim();
            if ( txtMaKH.Text.Length != 4||txtMaKH.Text[0] != 'K' || txtMaKH.Text[1] != 'H'  )
            {
                MessageBox.Show("Sai định dạng mã khách hàng(KH00)", "Thông báo");
                return;
            }
            for (int i = 2; i < 4; i++)
            {
                if (txtMaKH.Text[i] < 48 || txtMaKH.Text[i] > 57)
                {
                    MessageBox.Show("Sai định dạng mã khách hàng(KH00)", "Thông báo");
                    return;
                }
            }
            if (ds.Tables["tblKhachHang"].Rows.Find(txtMaKH.Text) != null)
            {
                MessageBox.Show("Mã khách hàng đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Clear();
                txtMaKH.Focus();
                return;
            }
            for (int i = 0; i < txtSDTKH.Text.Length; i++)
            {
                if (txtSDTKH.Text[i] < 48 || txtSDTKH.Text[i] > 57)
                {
                    MessageBox.Show("Số điện thoại phải là 1 chuỗi số", "Thông báo");
                    return;
                }
            }
            string check = "SELECT COUNT(*) FROM Khachhang WHERE MaKH = @MaKH AND tinhtrang = 0";
            SqlCommand cmdCheck = new SqlCommand(check, conn);
            cmdCheck.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
            conn.Open();
            int count = (int)cmdCheck.ExecuteScalar();
            if (count > 0)
            {
                string update = "UPDATE KhachHang SET TenKH = @TenKH, DiaChiKH = @DiaChiKH, sodienthoaikh = @sodienthoaikh, tinhtrang = 1 WHERE Makh = @MaKH";
                SqlCommand cmd = new SqlCommand(update, conn);
                cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                cmd.Parameters.AddWithValue("@TenKH", txtTenKH.Text);
                cmd.Parameters.AddWithValue("@DiaChiKH", txtDiaChiKH.Text);
                cmd.Parameters.AddWithValue("@sodienthoaikh", txtSDTKH.Text);
                cmd.ExecuteNonQuery();
                daKhachHang.Fill(ds, "tblKhachHang");
                return;
            }
            DataRow row = ds.Tables["tblKhachHang"].NewRow();
            row["MaKH"] = txtMaKH.Text;
            row["TenKH"] = txtTenKH.Text;
            row["DiaChiKH"] = txtDiaChiKH.Text;
            row["SoDienThoaiKH"] = txtSDTKH.Text;
            ds.Tables["tblKhachHang"].Rows.Add(row);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            frmXacNhan f = new frmXacNhan();
            DialogResult d2 = f.ShowDialog();
            if (d2 != DialogResult.OK)
            {
                MessageBox.Show("Xác nhận không thành công!", "Thông báo");
                return;
            }
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";

            if (dgDSKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            conn.Open();
            string sql = "SELECT MAX(P.Ngaymuahang) FROM PhieuMuaHang P WHERE p.makh= @MaKH";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaKH", dgDSKhachHang.SelectedRows[0].Cells["MaKH"].Value.ToString());
            object result= cmd.ExecuteScalar();
            DateTime today = DateTime.Now.AddMonths(-6);
            DateTime last;
            if (result != null && result != DBNull.Value)
            {
                last = (DateTime)result;
            }
            else
            {
                last = DateTime.Now.AddYears(-1);
            }
            if (last > today) 
            {
                MessageBox.Show($"Khách hàng có giao dịch gần nhất vào ngày {last.ToShortDateString()}. Không thể xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                string sql1 = "update khachhang set tinhtrang=0 where makh=@MaKH";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                cmd1.Parameters.AddWithValue("@MaKH", dgDSKhachHang.SelectedRows[0].Cells["MaKH"].Value.ToString());
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!");
            }
            DataGridViewRow d = dgDSKhachHang.SelectedRows[0];
            dgDSKhachHang.Rows.Remove(d);
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtDiaChiKH.Clear();
            txtSDTKH.Clear();
            txtMaKH.Focus();
            txtMaKH.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
            if (dgDSKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtMaKH.Text == "" || txtTenKH.Text == "" || txtDiaChiKH.Text == "" || txtSDTKH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            for (int i = 0; i < txtSDTKH.Text.Length; i++)
            {
                if (txtSDTKH.Text[i] < 48 || txtSDTKH.Text[i] > 57)
                {
                    MessageBox.Show("Số điện thoại phải là 1  chuỗi số", "Thông báo");
                    return;
                }
            }
            DataGridViewRow d = dgDSKhachHang.SelectedRows[0];
            DataRow row = ds.Tables["tblKhachHang"].Rows.Find(d.Cells["MaKH"].Value);
            row["MaKH"] = txtMaKH.Text;
            row["TenKH"] = txtTenKH.Text;
            row["DiaChiKH"] = txtDiaChiKH.Text;
            row["SoDienThoaiKH"] = txtSDTKH.Text;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                daKhachHang.Update(ds, "tblKhachHang");
                MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu dữ liệu thất bại! \n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            ds.Tables["tblKhachHang"].RejectChanges();
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtDiaChiKH.Clear();
            txtSDTKH.Clear();
            ds.Tables["tblKhachHang"].Clear();
            string sql = $"select makh,tenkh,sodienthoaikh, diachikh from khachhang where tinhtrang=1";
            daKhachHang = new SqlDataAdapter(sql, conn);
            daKhachHang.Fill(ds, "tblKhachHang");
            dgDSKhachHang.DataSource = ds.Tables["tblKhachHang"];
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
            for (int i = 0; i < dgDSKhachHang.RowCount - 1; i++)
                if (dgDSKhachHang.Rows[i].Cells[2].Value.ToString().Trim() == txtMaTim.Text)
                {
                    check = 1;
                    ds.Tables["tblKhachHang"].Clear();
                    ds.Tables.Remove("tblKhachHang");
                    string sql = $"select makh,tenkh,sodienthoaikh, diachikh from khachhang where tinhtrang=1 and sodienthoaikh='{txtMaTim.Text}'";
                    daKhachHang = new SqlDataAdapter(sql, conn);
                    daKhachHang.Fill(ds, "tblKhachHang");
                    dgDSKhachHang.DataSource = ds.Tables["tblKhachHang"];

                }
            if (check == 0)
            {
                MessageBox.Show("Không tìm thấy khách hàng có số điện thoại " + txtMaTim.Text, "Thông báo");
            }
        }

        private void dgDSKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow d = dgDSKhachHang.SelectedRows[0];
            txtMaKH.Text = d.Cells["MaKH"].Value.ToString();
            txtTenKH.Text = d.Cells["TenKH"].Value.ToString();
            txtDiaChiKH.Text = d.Cells["DiaChiKH"].Value.ToString();
            txtSDTKH.Text = d.Cells["SoDienThoaiKH"].Value.ToString();
            txtMaKH.Enabled = false;
        }
    }
}
