using System;
using System.Data;
using System.Data.SqlClient; 
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
namespace QLCHThuocNongDuoc
{
    public partial class frmReportPhieuMuaHang : Form
    {
        private int _soPhieuMuaHang; 
        public frmReportPhieuMuaHang(int soPhieu) 
        {
            InitializeComponent();
            this._soPhieuMuaHang = soPhieu;
        }
        private void frmReportPhieuMuaHang_Load(object sender, EventArgs e)
        {
            ReportDocument rptDoc = new ReportPhieuMuaHang();
            string connectionString = "Data Source=ACER\\SQLEXPRESS;Initial Catalog=QLCHMBTND;Integrated Security=True;";
            DataTable dtReportData = new DataTable();
            string sqlQuery = @"SELECT CTMH.stt, CTMH.SoPhieuMuaHang,NV.TenNV,KH.TenKH,KH.SoDienThoaiKH,T.TenThuoc,
                                T.GiaBan,CTMH.SoLuong,DVT.TenDonVi,CTMH.GiamGia,CTMH.ThanhTien,PMH.ngaymuahang
                                FROM dbo.ChiTietPhieuMuaHang AS CTMH 
                                INNER JOIN dbo.PhieuMuaHang AS PMH ON CTMH.SoPhieuMuaHang = PMH.SoPhieuMuaHang
                                INNER JOIN dbo.NhanVien AS NV ON PMH.MaNV = NV.MaNV 
                                INNER JOIN dbo.KhachHang AS KH ON PMH.MaKH = KH.MaKH
                                INNER JOIN dbo.THUOC AS T ON CTMH.MaThuoc = T.MaThuoc
                                INNER JOIN dbo.DonViTinh AS DVT ON T.MaDVT = DVT.MaDVT
                                WHERE CTMH.SoPhieuMuaHang = @SoPhieu";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@SoPhieu", _soPhieuMuaHang);
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dtReportData);
                    }
                }
                rptDoc.SetDataSource(dtReportData);
                ParameterFields paramFields = new ParameterFields();
                ParameterField paramField = new ParameterField();
                ParameterDiscreteValue discreteVal = new ParameterDiscreteValue();
                paramField.Name = "paraSoPMH";
                discreteVal.Value = this._soPhieuMuaHang;
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
