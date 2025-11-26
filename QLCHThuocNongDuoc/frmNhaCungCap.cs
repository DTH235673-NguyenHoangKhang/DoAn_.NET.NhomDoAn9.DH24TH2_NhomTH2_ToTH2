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

namespace QLCHThuocNongDuoc
{
    public partial class frmNhaCungCap : Form
    {
        public frmNhaCungCap()
        {
            InitializeComponent();
        }
        DataSet ds= new DataSet();
        SqlDataAdapter daNCC;
        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            daNCC = new SqlDataAdapter("SELECT manhacungcap,tenncc,diachincc,sodienthoaincc FROM NhaCungCap where tinhtrang=1", conn);
            daNCC.Fill(ds, "tblNhaCungCap");
            dgDSNhaCungCap.DataSource = ds.Tables["tblNhaCungCap"];
            dgDSNhaCungCap.Columns["MaNhaCungCap"].HeaderText = "Mã nhà cung cấp";
            dgDSNhaCungCap.Columns["TenNCC"].HeaderText = "Tên nhà cung cấp";
            dgDSNhaCungCap.Columns["DiaChiNCC"].HeaderText = "Địa chỉ";
            dgDSNhaCungCap.Columns["SoDienThoaiNCC"].HeaderText = "Điện thoại";
            dgDSNhaCungCap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string sInsert = "INSERT INTO NhaCungCap(MaNhaCungCap, TenNCC, DiaChiNCC, SoDienThoaiNCC)" +
                " VALUES(@MaNhaCungCap, @TenNCC, @DiaChiNCC, @SoDienThoaiNCC)";
            SqlCommand cmdInsert = new SqlCommand(sInsert, conn);
            cmdInsert.Parameters.Add("@MaNhaCungCap", SqlDbType.NVarChar, 10, "MaNhaCungCap");
            cmdInsert.Parameters.Add("@TenNCC", SqlDbType.NVarChar, 50, "TenNCC");
            cmdInsert.Parameters.Add("@DiaChiNCC", SqlDbType.NVarChar, 100, "DiaChiNCC");
            cmdInsert.Parameters.Add("@SoDienThoaiNCC", SqlDbType.Char, 15, "SoDienThoaiNCC");
            daNCC.InsertCommand = cmdInsert;
            string sUpdate = "UPDATE NhaCungCap SET TenNCC=@TenNCC, DiaChiNCC=@DiaChiNCC, SoDienThoaiNCC=@SoDienThoaiNCC " +
                "WHERE MaNhaCungCap=@MaNhaCungCap";
            SqlCommand cmdUpdate = new SqlCommand(sUpdate, conn);
            cmdUpdate.Parameters.Add("@MaNhaCungCap", SqlDbType.NVarChar, 10, "MaNhaCungCap");
            cmdUpdate.Parameters.Add("@TenNCC", SqlDbType.NVarChar, 50, "TenNCC");
            cmdUpdate.Parameters.Add("@DiaChiNCC", SqlDbType.NVarChar, 100, "DiaChiNCC");
            cmdUpdate.Parameters.Add("@SoDienThoaiNCC", SqlDbType.Char, 15, "SoDienThoaiNCC");
            daNCC.UpdateCommand = cmdUpdate;
            string sDelete = "DELETE FROM NhaCungCap WHERE MaNhaCungCap=@MaNhacungCap";
            SqlCommand cmdDelete = new SqlCommand(sDelete, conn);
            cmdDelete.Parameters.Add("@MaNhaCungCap", SqlDbType.NVarChar, 10, "MaNhacungCap");
            daNCC.DeleteCommand = cmdDelete;
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["tblNhaCungCap"].Columns["MaNhaCungCap"];
            ds.Tables["tblNhaCungCap"].PrimaryKey = key;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            if (txtMaNCC.Text == "" || txtTenNCC.Text == ""||txtDiaChiNCC.Text==""||txtSDTNCC.Text=="")
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            txtMaNCC.Text = txtMaNCC.Text.Trim();
            if (txtMaNCC.Text.Length != 5 || txtMaNCC.Text[0] != 'N' || txtMaNCC.Text[1] != 'C'|| txtMaNCC.Text[2]!='C')
            {
                MessageBox.Show("Sai định dạng mã nhà cung cấp(NCC00)", "Thông báo");
                return;
            }
            for (int i = 3; i < 5; i++)
            {
                if (txtMaNCC.Text[i] < 48 || txtMaNCC.Text[i] > 57)
                {
                    MessageBox.Show("Sai định dạng mã nhà cung cấp(NCC00)", "Thông báo");
                    return;
                }
            }
            if (ds.Tables["tblNhaCungCap"].Rows.Find(txtMaNCC.Text) != null)
            {
                MessageBox.Show("Mã nhà cung cấp đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            for (int i = 0; i < txtSDTNCC.Text.Length; i++)
            {
                if (txtSDTNCC.Text[i] < 48 || txtSDTNCC.Text[i] > 57)
                {
                    MessageBox.Show("Số điện thoại phải là 1 chuỗi số", "Thông báo");
                    return;
                }
            }
            string check = "SELECT COUNT(*) FROM nhacungcap WHERE MaNhaCungCap = @MaNhaCungCap AND tinhtrang = 0";
            SqlCommand cmdCheck = new SqlCommand(check, conn);
            cmdCheck.Parameters.AddWithValue("@MaNhaCungCap", txtMaNCC.Text);
            conn.Open();
            int count = (int)cmdCheck.ExecuteScalar();
            if (count > 0)
            {
                string update = "UPDATE NhaCungCap SET Tenncc = @Tenncc, DiaChincc = @DiaChincc, sodienthoaincc = @sodienthoaincc, tinhtrang = 1 WHERE Manhacungcap = @Manhacungcap";
                SqlCommand cmd = new SqlCommand(update, conn);
                cmd.Parameters.AddWithValue("@Manhacungcap", txtMaNCC.Text);
                cmd.Parameters.AddWithValue("@Tenncc", txtTenNCC.Text);
                cmd.Parameters.AddWithValue("@DiaChincc", txtDiaChiNCC.Text);
                cmd.Parameters.AddWithValue("@sodienthoaincc", txtSDTNCC.Text);
                cmd.ExecuteNonQuery();
                daNCC.Fill(ds, "tblNhaCungCap");
                return;
            }
            DataRow row = ds.Tables["tblNhaCungCap"].NewRow();
            row["MaNhaCungCap"] = txtMaNCC.Text;
            row["TenNCC"] = txtTenNCC.Text;
            row["DiaChiNCC"] = txtDiaChiNCC.Text;
            row["SoDienThoaiNCC"] = txtSDTNCC.Text;
            ds.Tables["tblNhaCungCap"].Rows.Add(row);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            if (dgDSNhaCungCap.SelectedRows[0]==null)
            {
                MessageBox.Show("Bạn phải chọn nhà cung cấp cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            conn.Open();
            string sql = "SELECT MAX(P.Ngaylapphieunhap) FROM PhieuNhapHang P WHERE p.manhacungcap=@MaNCC";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaNCC", dgDSNhaCungCap.SelectedRows[0].Cells["MaNhaCungCap"].Value.ToString());
            object result = cmd.ExecuteScalar();
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
                MessageBox.Show($"Nhà cung cấp có giao dịch gần nhất vào ngày {last.ToShortDateString()}. Không thể xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                string sql1 = "update nhacungcap set tinhtrang=0 where manhacungcap=@MaNhaCungCap";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                cmd1.Parameters.AddWithValue("@MaNhaCungCap", dgDSNhaCungCap.SelectedRows[0].Cells["MaNhaCungCap"].Value.ToString());
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!");
            }
            DataGridViewRow dr = dgDSNhaCungCap.SelectedRows[0];
            dgDSNhaCungCap.Rows.Remove(dr);
            txtSDTNCC.Clear();
            txtDiaChiNCC.Clear();
            txtTenNCC.Clear();
            txtMaNCC.Clear();
            txtMaNCC.Enabled = true;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if(dgDSNhaCungCap.SelectedRows[0] == null)
            {
                MessageBox.Show("Bạn phải chọn nhà cung cấp cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtMaNCC.Text == "" || txtTenNCC.Text == "" || txtDiaChiNCC.Text == "" || txtSDTNCC.Text == "")
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            for (int i = 0; i < txtSDTNCC.Text.Trim().Length; i++)
            {
                if (txtSDTNCC.Text[i] < 48 || txtSDTNCC.Text[i] > 57)
                {
                    MessageBox.Show("Số điện thoại phải là 1 chuỗi số", "Thông báo");
                    return;
                }
            }
            DataGridViewRow dr = dgDSNhaCungCap.SelectedRows[0];
            dr.Cells["MaNhaCungCap"].Value = txtMaNCC.Text;
            dr.Cells["TenNCC"].Value = txtTenNCC.Text;
            dr.Cells["DiaChiNCC"].Value = txtDiaChiNCC.Text;
            dr.Cells["SoDienThoaiNCC"].Value = txtSDTNCC.Text;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            daNCC.Update(ds, "tblNhaCungCap");
            MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            ds.Tables["tblNhaCungCap"].RejectChanges();
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtDiaChiNCC.Clear();
            txtSDTNCC.Clear();
            txtMaNCC.Enabled = true;
            ds.Tables["tblNhaCungCap"].Clear();
            string sql = $"SELECT manhacungcap,tenncc,diachincc,sodienthoaincc FROM NhaCungCap where tinhtrang=1";
            SqlDataAdapter tam = new SqlDataAdapter(sql, conn);
            tam.Fill(ds, "tblNhaCungCap");
            dgDSNhaCungCap.DataSource = ds.Tables["tblNhaCungCap"];
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void dgDSNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgDSNhaCungCap.SelectedRows[0];
            txtMaNCC.Text = dr.Cells["MaNhaCungCap"].Value.ToString();
            txtTenNCC.Text = dr.Cells["TenNCC"].Value.ToString();
            txtDiaChiNCC.Text = dr.Cells["DiaChiNCC"].Value.ToString();
            txtSDTNCC.Text = dr.Cells["SoDienThoaiNCC"].Value.ToString();
            txtMaNCC.Enabled = false;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            int check = 0;
            for (int i = 0; i < dgDSNhaCungCap.RowCount - 1; i++)
                if (dgDSNhaCungCap.Rows[i].Cells[0].Value.ToString().Trim() == txtMaTim.Text)
                {
                    check = 1;
                    ds.Tables["tblNHaCungCap"].Clear();
                    string sql = $"SELECT manhacungcap,tenncc,diachincc,sodienthoaincc FROM NhaCungCap where tinhtrang=1 and manhacungcap='{txtMaTim.Text}'";
                    SqlDataAdapter tam = new SqlDataAdapter(sql, conn);
                    tam.Fill(ds, "tblNhaCungCap");
                    dgDSNhaCungCap.DataSource = ds.Tables["tblNhaCungCap"];

                }
            if (check == 0)
            {
                MessageBox.Show("Không tìm thấy nhà cung cấp có mã " + txtMaTim.Text, "Thông báo");
            }
        }
    }
}
