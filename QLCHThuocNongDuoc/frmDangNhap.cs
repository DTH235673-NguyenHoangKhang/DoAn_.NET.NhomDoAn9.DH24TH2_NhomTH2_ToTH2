using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QLCHThuocNongDuoc
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        SqlDataAdapter daDangNhap;
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (ds.Tables["tblusers"].Rows.Find(txtTaiKhoan.Text) == null)
            {
                MessageBox.Show("Tài khoản không tồn tại!");
                return;
            }
            else if(txtMatKhau.Text != ds.Tables["tblusers"].Rows.Find(txtTaiKhoan.Text)["MatKhau"].ToString().Trim())
            {
                MessageBox.Show("Mật khẩu không đúng!");
                return;
            }
            else
            {
                this.Hide();
                frmMain main = new frmMain(txtTaiKhoan.Text);
                main.Show();
            }
        }
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            SqlConnection conn=new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            daDangNhap = new SqlDataAdapter("SELECT * FROM users", conn);
            daDangNhap.Fill(ds, "tblusers");
            ds.Tables["tblusers"].PrimaryKey = new DataColumn[] { ds.Tables["tblusers"].Columns["TaiKhoan"] };
        }
    }
}
