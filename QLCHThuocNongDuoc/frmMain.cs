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
    public partial class frmMain : Form
    {
        string user;
        public frmMain(string x)
        {
            InitializeComponent();
            DataSet ds =new DataSet();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            SqlDataAdapter daDangNhap = new SqlDataAdapter("SELECT * FROM users", conn);
            daDangNhap.Fill(ds, "tblusers");
            ds.Tables["tblusers"].PrimaryKey = new DataColumn[] { ds.Tables["tblusers"].Columns["TaiKhoan"] };
            int role= int.Parse(ds.Tables["tblusers"].Rows.Find(x)["role"].ToString());
            if (role== 0) {
                quảnLýThuốcToolStripMenuItem.Visible = false;
                báoCáoDoanhThuToolStripMenuItem.Visible = false;
                thốngKêToolStripMenuItem.Visible = false;
                tạoTàiKhoảnToolStripMenuItem.Visible = false;
                phiếuNhậpHàngToolStripMenuItem.Visible = false;
            }
            this.user = x;

        }

        private void ShowFormInPanel(Form childForm)
        {
            if (pnlContent.Controls.Count > 0)
            {
                var existingForm = pnlContent.Controls[0] as Form;
                if (existingForm != null)
                {
                    existingForm.Close();
                    existingForm.Dispose();
                }
            }
            pnlContent.Controls.Clear();
            childForm.TopLevel = false;         
            childForm.FormBorderStyle = FormBorderStyle.None; 
            childForm.Dock = DockStyle.Fill;    
            pnlContent.Controls.Add(childForm);
            childForm.Show();
        }
        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pnlContent.Controls.Count > 0)
            {
                var existingForm = pnlContent.Controls[0] as Form;
                if (existingForm != null)
                {
                    existingForm.Close();
                    existingForm.Dispose();
                }
            }
            pnlContent.Controls.Clear();
        }
        private void quảnLýThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new frmQuanLyThuocNongDuoc());
        }
        private void phiếuNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new frmPhieuNhapHang());
        }
        private void phiếuMuaHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new frmPhieuMuaHang(this.user));
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void doanhThuTheoNgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new frmDoanhThuTheoNgay());
        }
        private void doanhThuTheoThToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new frmDoanhThuTheoThang());

        }
        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new frmThongKe());
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangNhap f=new frmDangNhap();
            f.ShowDialog();

        }

        private void tạoTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaoTaiKhoan f=new frmTaoTaiKhoan();
            f.ShowDialog();

        }
    }
}
