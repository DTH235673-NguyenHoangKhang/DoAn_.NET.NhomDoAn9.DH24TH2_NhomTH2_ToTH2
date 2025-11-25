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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace QLCHThuocNongDuoc
{
    public partial class frmReportPhieuNhapHang : Form
    {
        private int _soPhieuNhapHang; 

        public frmReportPhieuNhapHang(int soPhieu) 
        {
            InitializeComponent();
            this._soPhieuNhapHang = soPhieu;

        }
        private void frmReportPhieuNhapHang_Load(object sender, EventArgs e)
        {
            ReportDocument rptDoc = new ReportPhieuNhapHang(); 
            string connectionString = "Data Source=ACER\\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True;";
            DataTable dtReportData = new DataTable();
            string sqlQuery = @"select distinct c.SoPhieuNhapHang,n.TenNV,ncc.TenNCC,p.ngaylapphieunhap,c.stt,t.TenThuoc,t.GiaNhap,c.SoLuong,d.TenDonVi,c.thanhtien,p.tongtien
                                from thuoc t join ChiTietPhieuNhapHang c on t.MaThuoc=c.MaThuoc, PhieuNhapHang p,nhanvien n,nhacungcap ncc,donvitinh d
                                where p.SoPhieuNhapHang=c.SoPhieuNhapHang and t.MaDVt=d.MaDVT and n.MaNV=p.MaNv and ncc.MaNhaCungCap=p.MaNhaCungCap
                                and p.SoPhieuNhapHang=@SoPhieu";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@SoPhieu", _soPhieuNhapHang);
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dtReportData);
                    }
                }
                rptDoc.SetDataSource(dtReportData);
                ParameterFields paramFields = new ParameterFields();
                ParameterField paramField = new ParameterField();
                ParameterDiscreteValue discreteVal = new ParameterDiscreteValue();
                paramField.Name = "paraSoPNH"; 
                discreteVal.Value = this._soPhieuNhapHang;
                paramField.CurrentValues.Add(discreteVal);
                paramFields.Add(paramField);
                crystalReportViewer1.ParameterFieldInfo = paramFields;
                crystalReportViewer1.ReportSource = rptDoc;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load Crystal Report: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
