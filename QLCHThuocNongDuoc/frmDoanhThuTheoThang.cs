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
using static System.Net.WebRequestMethods;

namespace QLCHThuocNongDuoc
{
    public partial class frmDoanhThuTheoThang : Form
    {
        public frmDoanhThuTheoThang()
        {
            InitializeComponent();
        }
        DataSet ds=new DataSet();
        SqlDataAdapter da;
        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (cboThang.SelectedItem == null || cboNam.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Tháng và Năm trước khi xuất báo cáo.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            if (ds.Tables.Contains("tblDT"))
            {
                ds.Tables["tblDT"].Clear();
                ds.Tables.Remove("tblDT");
            }
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            string sql = "SELECT CONVERT(DATE, p.ngaymuahang) AS NgayMuaHang, "
            +" SUM(c.ThanhTien) AS TongDoanhThu,"
            +" SUM(c.SoLuong * t.GiaNhap) AS TongCOS,"
            +" SUM(thanhtien * 0.08) AS VAT,"
            +" SUM(c.ThanhTien) -SUM(c.SoLuong * t.GiaNhap + thanhtien * 0.08) AS LoiNhuanGop"
            +" FROM chitietphieumuahang c"
            +" JOIN phieumuahang p ON c.SoPhieuMuaHang = p.SoPhieuMuaHang"
            +" JOIN thuoc t ON c.MaThuoc = t.MaThuoc"
            +" where month(ngaymuahang)=@Thang and year(ngaymuahang) =@Nam"
            +" GROUP BY p.ngaymuahang"
            +" ORDER BY p.ngaymuahang; ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Thang", Convert.ToInt32(cboThang.SelectedItem.ToString()));
            cmd.Parameters.AddWithValue("@Nam", Convert.ToInt32(cboNam.SelectedItem.ToString()));
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tblDT");
            dgDS.DataSource = ds.Tables["tblDT"];
            dgDS.Columns["NgayMuaHang"].HeaderText = "Ngày";
            dgDS.Columns["TongDoanhThu"].HeaderText = "DoanhThu";
            dgDS.Columns["TongCOS"].HeaderText = "Vốn";
            dgDS.Columns["VAT"].HeaderText = "Thuế";
            dgDS.Columns["LoiNhuanGop"].HeaderText = "Lợi nhuận gốp";
            dgDS.Columns["NgayMuaHang"].Width=120;
            dgDS.Columns["TongDoanhThu"].Width=120;
            dgDS.Columns["TongCOS"].Width=120;
            dgDS.Columns["VAT"].Width=120;
            dgDS.Columns["LoiNhuanGop"].Width=120;
            int tongdt = 0;
            int tongcos = 0;
            for (int i = 0; i < dgDS.Rows.Count - 1; i++)
            {
                tongdt = tongdt + Convert.ToInt32(dgDS.Rows[i].Cells[1].Value.ToString());
                tongcos = tongcos + Convert.ToInt32(dgDS.Rows[i].Cells[2].Value.ToString());
            }
            double thue = tongdt * 0.08;
            double loinhuan = tongdt - tongcos - thue;
            txtDoanhThu.Text = tongdt.ToString();
            txtThue.Text = thue.ToString();
            txtLoiNhuan.Text = loinhuan.ToString();
        }
    }
}
