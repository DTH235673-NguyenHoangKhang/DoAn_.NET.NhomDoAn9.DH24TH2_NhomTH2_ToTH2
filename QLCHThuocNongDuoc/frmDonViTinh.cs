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

namespace QLCHThuocNongDuoc
{
    public partial class frmDonViTinh : Form
    {
        public frmDonViTinh()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        SqlDataAdapter daDonViTinh;
        private void frmDonViTinh_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            string sql = "SELECT * FROM DONVITINH";
            daDonViTinh = new SqlDataAdapter(sql, conn);
            daDonViTinh.Fill(ds, "tblDONVITINH");
            dgDSDVT.DataSource = ds.Tables["tblDONVITINH"];
            dgDSDVT.Columns["MaDVT"].HeaderText = "Mã đơn vị tính";
            dgDSDVT.Columns["TenDonVi"].HeaderText = "Tên đơn vị tính";
            string sInsert = "INSERT INTO DONVITINH(MaDVT, TenDonVi) VALUES(@MaDVT, @TenDonVi)";
            SqlCommand cmdInsert = new SqlCommand(sInsert, conn);
            cmdInsert.Parameters.Add("@MaDVT", SqlDbType.NVarChar, 10, "MaDVT");
            cmdInsert.Parameters.Add("@TenDonVi", SqlDbType.NVarChar, 50, "TenDonVi");
            daDonViTinh.InsertCommand = cmdInsert;
            string sUpdate = "UPDATE DONVITINH SET TenDonVi=@TenDonVi WHERE MaDVT=@MaDVT";
            SqlCommand cmdUpdate = new SqlCommand(sUpdate, conn);
            cmdUpdate.Parameters.Add("@MaDVT", SqlDbType.NVarChar, 10, "MaDVT");
            cmdUpdate.Parameters.Add("@TenDonVi", SqlDbType.NVarChar, 50, "TenDonVi");
            daDonViTinh.UpdateCommand = cmdUpdate;
            string sDelete = "DELETE FROM DONVITINH WHERE MaDVT=@MaDVT";
            SqlCommand cmdDelete = new SqlCommand(sDelete, conn);
            cmdDelete.Parameters.Add("@MaDVT", SqlDbType.NVarChar, 10, "MaDVT");
            daDonViTinh.DeleteCommand = cmdDelete;
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["tblDONVITINH"].Columns[0];
            ds.Tables["tblDONVITINH"].PrimaryKey = key;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtMaDVT.Text == "" || txtTenDVT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            txtMaDVT.Text = txtMaDVT.Text.Trim();
            if (ds.Tables["tblDONVITINH"].Rows.Find(txtMaDVT.Text) != null)
            {
                MessageBox.Show("Mã đơn vị tính đã tồn tại!");
                return;
            }
            DataRow row = ds.Tables["tblDONVITINH"].NewRow();
            row["MaDVT"] = txtMaDVT.Text;
            row["TenDonVi"] = txtTenDVT.Text;
            ds.Tables["tblDONVITINH"].Rows.Add(row);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            if (dgDSDVT.SelectedRows[0]==null)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính cần xóa!");
                return;
            }
            conn.Open();
            string madvt=dgDSDVT.SelectedRows[0].Cells[0].Value.ToString();
            string sql = $"select count(*) from thuoc  where madvt='{madvt}'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            object x=cmd.ExecuteScalar();
            if ((int)x > 0) 
            {
                MessageBox.Show("Tồn tại thuốc trong kho sử dụng đơn vị tính này!Không thể xóa", "Thông báo");
                return;
            }
            DataGridViewRow dr = dgDSDVT.SelectedRows[0];
            dgDSDVT.Rows.Remove(dr);
            txtMaDVT.Clear();
            txtTenDVT.Clear();
            MessageBox.Show("Xóa đơn vị tính thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(dgDSDVT.SelectedRows[0] == null)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính cần sửa!");
                return;
            }
            DataGridViewRow dr = dgDSDVT.SelectedRows[0];
            DataRow row = ds.Tables["tblDONVITINH"].Rows.Find(dr.Cells["MaDVT"].Value);
            row["MaDVT"] = txtMaDVT.Text;
            row["TenDonVi"]= txtTenDVT.Text;

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            daDonViTinh.Update(ds, "tblDONVITINH");
            MessageBox.Show("Lưu dữ liệu thành công!");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ds.Tables["tblDONVITINH"].RejectChanges();
            txtMaDVT.Clear();
            txtTenDVT.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgDSDVT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgDSDVT.SelectedRows[0];
            txtMaDVT.Text = dr.Cells["MaDVT"].Value.ToString();
            txtTenDVT.Text = dr.Cells["TenDonVi"].Value.ToString();
            txtMaDVT.Enabled = false;
        }
    }
}
