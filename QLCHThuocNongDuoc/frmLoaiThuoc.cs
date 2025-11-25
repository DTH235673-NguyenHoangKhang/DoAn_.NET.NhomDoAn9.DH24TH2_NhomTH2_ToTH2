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
    public partial class frmLoaiThuoc : Form
    {
        public frmLoaiThuoc()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        SqlDataAdapter daLoaiThuoc;
        private void frmLoaiThuoc_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            string sql = "SELECT * FROM LOAITHUOC";
            daLoaiThuoc = new SqlDataAdapter(sql, conn);
            daLoaiThuoc.Fill(ds, "tblLOAITHUOC");
            dgDSLoaiThuoc.DataSource = ds.Tables["tblLOAITHUOC"];
            dgDSLoaiThuoc.Columns["MaLT"].HeaderText = "Mã loại thuốc";
            dgDSLoaiThuoc.Columns["TenLoaiThuoc"].HeaderText = "Tên loại thuốc";
            dgDSLoaiThuoc.Columns["MaLT"].Width = 50;
            dgDSLoaiThuoc.Columns["TenLoaiThuoc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            string sInsert = "INSERT INTO LOAITHUOC(MaLT, TenLoaiThuoc) VALUES(@MaLT, @TenLoaiThuoc)";
            SqlCommand cmdInsert = new SqlCommand(sInsert, conn);
            cmdInsert.Parameters.Add("@MaLT", SqlDbType.NVarChar, 10, "MaLT");
            cmdInsert.Parameters.Add("@TenLoaiThuoc", SqlDbType.NVarChar, 50, "TenLoaiThuoc");
            daLoaiThuoc.InsertCommand = cmdInsert;
            string sUpdate = "UPDATE LOAITHUOC SET TenLoaiThuoc=@TenLoaiThuoc WHERE MaLT=@MaLT";
            SqlCommand cmdUpdate = new SqlCommand(sUpdate, conn);
            cmdUpdate.Parameters.Add("@MaLT", SqlDbType.NVarChar, 10, "MaLT");
            cmdUpdate.Parameters.Add("@TenLoaiThuoc", SqlDbType.NVarChar, 50, "TenLoaiThuoc");
            daLoaiThuoc.UpdateCommand = cmdUpdate;
            string sDelete = "DELETE FROM LOAITHUOC WHERE MaLT=@MaLT";
            SqlCommand cmdDelete = new SqlCommand(sDelete, conn);
            cmdDelete.Parameters.Add("@MaLT", SqlDbType.NVarChar, 10, "MaLT");
            daLoaiThuoc.DeleteCommand = cmdDelete;
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["tblLOAITHUOC"].Columns[0];
            ds.Tables["tblLOAITHUOC"].PrimaryKey = key;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtMaLT.Text == "" || txtTenLoaiThuoc.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            txtMaLT.Text = txtMaLT.Text.Trim();
            if (ds.Tables["tblLOAITHUOC"].Rows.Find(txtMaLT.Text) != null)
            {
                MessageBox.Show("Mã loại thuốc đã tồn tại!");
                return;
            }
            DataRow row = ds.Tables["tblLOAITHUOC"].NewRow();
            row["MaLT"] = txtMaLT.Text;
            row["TenLoaiThuoc"] = txtTenLoaiThuoc.Text;
            ds.Tables["tblLOAITHUOC"].Rows.Add(row);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";

            if (dgDSLoaiThuoc.SelectedRows[0]==null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
                return;
            }
            conn.Open();
            string malt = dgDSLoaiThuoc.SelectedRows[0].Cells[0].Value.ToString();
            string sql = $"select count(*) from thuoc  where malt='{malt}'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            object x = cmd.ExecuteScalar();
            if ((int)x > 0)
            {
                MessageBox.Show("Tồn tại thuốc trong kho sử dụng loại thuốc này!Không thể xóa", "Thông báo");
                return;
            }
            dgDSLoaiThuoc.Rows.RemoveAt(dgDSLoaiThuoc.SelectedRows[0].Index);
            txtMaLT.Clear();
            txtTenLoaiThuoc.Clear();
            MessageBox.Show("Xóa loại thuốc thành công!");
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if(dgDSLoaiThuoc.SelectedRows[0] == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!");
                return;
            }
            DataGridViewRow d = dgDSLoaiThuoc.SelectedRows[0];
            DataRow row=ds.Tables["tblLOAITHUOC"].Rows.Find(d.Cells["MaLT"].Value);
            row["MaLT"] = txtMaLT.Text;
            row["TenLoaiThuoc"]= txtTenLoaiThuoc.Text;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            daLoaiThuoc.Update(ds, "tblLOAITHUOC");
            MessageBox.Show("Lưu dữ liệu thành công!");
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ds.Tables["tblLOAITHUOC"].RejectChanges();
            txtMaLT.Clear();
            txtTenLoaiThuoc.Clear();
            txtMaLT.Enabled = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgDSLoaiThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgDSLoaiThuoc.SelectedRows[0];
            txtMaLT.Text = row.Cells["MaLT"].Value.ToString();
            txtTenLoaiThuoc.Text = row.Cells["TenLoaiThuoc"].Value.ToString();
            txtMaLT.Enabled = false;
        }
    }
}
