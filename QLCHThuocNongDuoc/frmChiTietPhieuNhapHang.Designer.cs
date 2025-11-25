namespace QLCHThuocNongDuoc
{
    partial class frmChiTietPhieuNhapHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgDSCTPNH = new System.Windows.Forms.DataGridView();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboTenThuoc = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboLoaiThuoc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSoPhieuNhapHang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.btnDanhSachthuoc = new System.Windows.Forms.Button();
            this.btnXuatPhieuNhap = new System.Windows.Forms.Button();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgDSCTPNH)).BeginInit();
            this.SuspendLayout();
            // 
            // dgDSCTPNH
            // 
            this.dgDSCTPNH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDSCTPNH.Location = new System.Drawing.Point(32, 256);
            this.dgDSCTPNH.Name = "dgDSCTPNH";
            this.dgDSCTPNH.RowHeadersWidth = 51;
            this.dgDSCTPNH.RowTemplate.Height = 24;
            this.dgDSCTPNH.Size = new System.Drawing.Size(837, 269);
            this.dgDSCTPNH.TabIndex = 41;
            this.dgDSCTPNH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDSCTPNH_CellClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(769, 209);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 37);
            this.btnThoat.TabIndex = 40;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(403, 209);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 37);
            this.btnSua.TabIndex = 38;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(206, 209);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 37);
            this.btnXoa.TabIndex = 37;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(28, 209);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 37);
            this.btnThem.TabIndex = 36;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(140, 174);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(141, 22);
            this.txtSoLuong.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 25);
            this.label6.TabIndex = 32;
            this.label6.Text = "Số lượng: ";
            // 
            // cboTenThuoc
            // 
            this.cboTenThuoc.FormattingEnabled = true;
            this.cboTenThuoc.Location = new System.Drawing.Point(475, 104);
            this.cboTenThuoc.Name = "cboTenThuoc";
            this.cboTenThuoc.Size = new System.Drawing.Size(168, 24);
            this.cboTenThuoc.TabIndex = 29;
            this.cboTenThuoc.SelectedIndexChanged += new System.EventHandler(this.cboTenThuoc_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(358, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 25);
            this.label4.TabIndex = 28;
            this.label4.Text = "Tên thuốc: ";
            // 
            // cboLoaiThuoc
            // 
            this.cboLoaiThuoc.FormattingEnabled = true;
            this.cboLoaiThuoc.Location = new System.Drawing.Point(138, 103);
            this.cboLoaiThuoc.Name = "cboLoaiThuoc";
            this.cboLoaiThuoc.Size = new System.Drawing.Size(168, 24);
            this.cboLoaiThuoc.TabIndex = 27;
            this.cboLoaiThuoc.SelectedIndexChanged += new System.EventHandler(this.cboLoaiThuoc_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 25);
            this.label3.TabIndex = 26;
            this.label3.Text = "Loại thuốc: ";
            // 
            // txtSoPhieuNhapHang
            // 
            this.txtSoPhieuNhapHang.Location = new System.Drawing.Point(226, 59);
            this.txtSoPhieuNhapHang.Name = "txtSoPhieuNhapHang";
            this.txtSoPhieuNhapHang.Size = new System.Drawing.Size(308, 22);
            this.txtSoPhieuNhapHang.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 25);
            this.label2.TabIndex = 24;
            this.label2.Text = "Số phiếu nhập hàng: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(276, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 32);
            this.label1.TabIndex = 23;
            this.label1.Text = "Danh mục thuốc nông dược";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(367, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 25);
            this.label5.TabIndex = 42;
            this.label5.Text = "Giá nhập: ";
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Enabled = false;
            this.txtGiaNhap.Location = new System.Drawing.Point(471, 175);
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.Size = new System.Drawing.Size(141, 22);
            this.txtGiaNhap.TabIndex = 43;
            // 
            // btnDanhSachthuoc
            // 
            this.btnDanhSachthuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDanhSachthuoc.Location = new System.Drawing.Point(670, 96);
            this.btnDanhSachthuoc.Name = "btnDanhSachthuoc";
            this.btnDanhSachthuoc.Size = new System.Drawing.Size(185, 37);
            this.btnDanhSachthuoc.TabIndex = 44;
            this.btnDanhSachthuoc.Text = "Danh sách thuốc";
            this.btnDanhSachthuoc.UseVisualStyleBackColor = true;
            // 
            // btnXuatPhieuNhap
            // 
            this.btnXuatPhieuNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatPhieuNhap.Location = new System.Drawing.Point(623, 552);
            this.btnXuatPhieuNhap.Name = "btnXuatPhieuNhap";
            this.btnXuatPhieuNhap.Size = new System.Drawing.Size(187, 37);
            this.btnXuatPhieuNhap.TabIndex = 47;
            this.btnXuatPhieuNhap.Text = "Xuất phiếu nhập";
            this.btnXuatPhieuNhap.UseVisualStyleBackColor = true;
            this.btnXuatPhieuNhap.Click += new System.EventHandler(this.btnXuatPhieuNhap_Click);
            // 
            // txtTongTien
            // 
            this.txtTongTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtTongTien.Enabled = false;
            this.txtTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.Location = new System.Drawing.Point(287, 550);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(216, 30);
            this.txtTongTien.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(176, 555);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 25);
            this.label8.TabIndex = 45;
            this.label8.Text = "Tổng tiền: ";
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(582, 209);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 37);
            this.btnHuy.TabIndex = 48;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // frmChiTietPhieuNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 609);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXuatPhieuNhap);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnDanhSachthuoc);
            this.Controls.Add(this.txtGiaNhap);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgDSCTPNH);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboTenThuoc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboLoaiThuoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSoPhieuNhapHang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmChiTietPhieuNhapHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết phiếu nhập hàng";
            this.Load += new System.EventHandler(this.frmChiTietPhieuNhapHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDSCTPNH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgDSCTPNH;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboTenThuoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboLoaiThuoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSoPhieuNhapHang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGiaNhap;
        private System.Windows.Forms.Button btnDanhSachthuoc;
        private System.Windows.Forms.Button btnXuatPhieuNhap;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnHuy;
    }
}