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
    public partial class frmTaoTaiKhoan : Form
    {
        public frmTaoTaiKhoan()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        SqlDataAdapter daTaoTaiKhoan;
        SqlDataAdapter daNhanVien;

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            
            if (txtTaiKhoan.Text=="" || txtMatKhau.Text=="" ||txtMatKhau_check.Text=="")
            {
                MessageBox.Show("Vui lòng nhập đủ dữ liệu!", "Thông báo");
                return;
            }
            if (ds.Tables["tblusers"].Rows.Find(txtTaiKhoan.Text) != null)
            {
                MessageBox.Show("Tài khoản đã tồn tại!");
                return;
            }
            else if (txtMatKhau.Text != txtMatKhau_check.Text)
            {
                MessageBox.Show("Mật khẩu không khớp!");
                return;
            }
            else if(ds.Tables["tblNhanVien"].Rows.Find(txtTaiKhoan.Text)==null)
            {
                MessageBox.Show("Nhân viên chưa được thêm vào hệ thống!", "Thông báo");
                return;
            }
            else
            {
                this.Hide();
                string sql = "insert into users values(@TaiKhoan,@MatKhau,0)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TaiKhoan", txtTaiKhoan.Text);
                cmd.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Tạo tài khoản thành công!", "Thông báo");

            }
        }

        private void frmTaoTaiKhoan_Load(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            daTaoTaiKhoan = new SqlDataAdapter("SELECT * FROM users", conn);
            daTaoTaiKhoan.Fill(ds, "tblusers");
            ds.Tables["tblusers"].PrimaryKey = new DataColumn[] { ds.Tables["tblusers"].Columns["TaiKhoan"] };

            daNhanVien = new SqlDataAdapter("select * from nhanvien where tinhtrang=1", conn);
            daNhanVien.Fill(ds, "tblNhanVien");
            ds.Tables["tblNhanVien"].PrimaryKey = new DataColumn[] { ds.Tables["tblNhanVien"].Columns["MaNV"] };

        }
    }
}
