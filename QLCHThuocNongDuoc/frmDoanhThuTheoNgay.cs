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
    public partial class frmDoanhThuTheoNgay : Form
    {
        public frmDoanhThuTheoNgay()
        {
            InitializeComponent();
        }
        DataSet ds=new DataSet();
        SqlDataAdapter da;
        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (ds.Tables.Contains("tblDT"))
            {
                ds.Tables["tblDT"].Clear();
                ds.Tables.Remove("tblDT");
            }
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";
            string dt = dtp.Value.ToString("yyyy-MM-dd");

            string sql = "SELECT t.TenThuoc,SUM(c.SoLuong) AS TongSoLuong,giaban,gianhap,giamgia,SUM(c.ThanhTien) AS TongDoanhThu," +
                " SUM(c.SoLuong * t.GiaNhap) AS TongCOS " +
                " FROM chitietphieumuahang c  " +
                " JOIN " +
                " phieumuahang p ON c.SoPhieuMuaHang = p.SoPhieuMuaHang " +
                " JOIN " +
                " thuoc t ON c.MaThuoc = t.MaThuoc " +
                " where ngaymuahang=@NgayMuaHang  " +
                " GROUP BY t.TenThuoc,t.GiaBan,t.GiaNhap,giamgia;";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@NgayMuaHang", dt);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tblDT");
            dgDS.DataSource = ds.Tables["tblDT"];
            dgDS.Columns["TenThuoc"].HeaderText = "Tên thuốc";
            dgDS.Columns["TongSoLuong"].HeaderText = "Số lượng";
            dgDS.Columns["giaban"].HeaderText = "Giá bán";
            dgDS.Columns["gianhap"].HeaderText = "Giá nhập";
            dgDS.Columns["giamgia"].HeaderText = "Giảm giá";
            dgDS.Columns["TongDoanhThu"].HeaderText = "Thành tiền";
            dgDS.Columns["TongCOS"].HeaderText = "Vốn";
            dgDS.Columns["TenThuoc"].Width=150;
            dgDS.Columns["TongSoLuong"].Width=50;
            dgDS.Columns["giaban"].Width=80;
            dgDS.Columns["gianhap"].Width=80;
            dgDS.Columns["giamgia"].Width=80;
            dgDS.Columns["TongDoanhThu"].Width=100;
            dgDS.Columns["TongCOS"].Width=100;
            int tongdt = 0;
            int tongcos = 0;
            for (int i=0;i<dgDS.Rows.Count-1;i++)
            {
                tongdt= tongdt+ Convert.ToInt32(dgDS.Rows[i].Cells[5].Value.ToString());
                tongcos = tongcos + Convert.ToInt32(dgDS.Rows[i].Cells[6].Value.ToString());
            }
            double thue = tongdt * 0.08;
            double loinhuan= tongdt-tongcos-thue;
            txtDoanhThu.Text = tongdt.ToString();
            txtThue.Text = thue.ToString();
            txtLoiNhuan.Text=loinhuan.ToString();
        }
    }
}
