using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHThuocNongDuoc
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }
        DataSet ds=new DataSet();
        SqlDataAdapter da;

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (cboThang.SelectedItem == null || cboNam.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Tháng và Năm trước khi xuất thống kê.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ds.Tables.Contains("tblDT"))
            {
                ds.Tables["tblDT"].Clear();
                ds.Tables.Remove("tblDT");
            }
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ACER\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True";

            string sql = "WITH TongDoanhThu AS (SELECT SUM(c.ThanhTien) AS TongThanhTien "
                        +" FROM chitietphieumuahang c)"
                        +" SELECT t.TenThuoc,"
                        +" (SUM(c.ThanhTien) * 100.0 / (SELECT TongThanhTien FROM TongDoanhThu)) AS PhanTramDoanhThu,"
                        +" SUM(c.SoLuong) AS SoLuongBan, t.SoLuongTon"
                        +" FROM chitietphieumuahang c"
                        +" JOIN thuoc t ON c.MaThuoc = t.MaThuoc, phieumuahang p"
                        +" where p.SoPhieuMuaHang = c.SoPhieuMuaHang and month(ngaymuahang)=@Thang and year(ngaymuahang) =@Nam"
                        +" GROUP BY t.TenThuoc, t.SoLuongTon"
                        +" ORDER BY PhanTramDoanhThu DESC; ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Thang", Convert.ToInt32(cboThang.SelectedItem.ToString()));
            cmd.Parameters.AddWithValue("@Nam", Convert.ToInt32(cboNam.SelectedItem.ToString()));
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tblDT");
            dgDS.DataSource = ds.Tables["tblDT"];
            dgDS.Columns["TenThuoc"].HeaderText = "Tên Thuốc";
            dgDS.Columns["PhanTramDoanhThu"].HeaderText = "% Doanh thu";
            dgDS.Columns["SoLuongBan"].HeaderText = "Số lượng bán";
            dgDS.Columns["SoLuongTon"].HeaderText = "Số lượng tồn";
            dgDS.Columns["TenThuoc"].Width=160;
            dgDS.Columns["PhanTramDoanhThu"].Width=160;
            dgDS.Columns["SoLuongBan"].Width = 160;
            dgDS.Columns["SoLuongTon"].Width=160;
            double max = 0;
            int vitrimax = 0;
            double min = 100;
            int vitrimin = 0;
            for (int i=0;i<dgDS.Rows.Count-1;i++)
            {
                if (max < Convert.ToDouble(dgDS.Rows[i].Cells[1].Value.ToString()))
                {
                    max = Convert.ToDouble(dgDS.Rows[i].Cells[1].Value.ToString());
                    vitrimax = i;
                }
                if (min > Convert.ToDouble(dgDS.Rows[i].Cells[1].Value.ToString()))
                {
                    min = Convert.ToDouble(dgDS.Rows[i].Cells[1].Value.ToString());
                    vitrimin = i;
                }
            }
            txtMax.Text = dgDS.Rows[vitrimax].Cells[0].Value.ToString();
            txtMin.Text = dgDS.Rows[vitrimin].Cells[0].Value.ToString();

        }
    }
}
