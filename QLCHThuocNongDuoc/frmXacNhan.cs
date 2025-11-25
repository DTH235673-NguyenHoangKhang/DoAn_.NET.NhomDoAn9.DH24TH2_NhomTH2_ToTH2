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
    public partial class frmXacNhan : Form
    {
        public frmXacNhan()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        SqlDataAdapter daXacNhan;
        private void frmXacNhan_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            daXacNhan = new SqlDataAdapter("SELECT * FROM users", conn);
            daXacNhan.Fill(ds, "tblusers");
            ds.Tables["tblusers"].PrimaryKey = new DataColumn[] { ds.Tables["tblUsers"].Columns["TaiKhoan"] };
            txtTaiKhoan.Focus();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string mk= ds.Tables["tblusers"].Rows.Find(txtTaiKhoan.Text)["MatKhau"].ToString().Trim();
            if (ds.Tables["tblusers"].Rows.Find(txtTaiKhoan.Text).ToString()==null || txtMatKhau.Text!=mk)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!");
                return;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
