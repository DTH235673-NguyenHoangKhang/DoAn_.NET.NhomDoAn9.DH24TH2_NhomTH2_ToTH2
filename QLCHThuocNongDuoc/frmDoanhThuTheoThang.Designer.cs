namespace QLCHThuocNongDuoc
{
    partial class frmDoanhThuTheoThang
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
            this.txtLoiNhuan = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtThue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDoanhThu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXuat = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgDS = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cboThang = new System.Windows.Forms.ComboBox();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgDS)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLoiNhuan
            // 
            this.txtLoiNhuan.Location = new System.Drawing.Point(863, 478);
            this.txtLoiNhuan.Name = "txtLoiNhuan";
            this.txtLoiNhuan.Size = new System.Drawing.Size(148, 22);
            this.txtLoiNhuan.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(715, 475);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 25);
            this.label5.TabIndex = 21;
            this.label5.Text = "Lợi nhuận gộp:";
            // 
            // txtThue
            // 
            this.txtThue.Location = new System.Drawing.Point(533, 477);
            this.txtThue.Name = "txtThue";
            this.txtThue.Size = new System.Drawing.Size(167, 22);
            this.txtThue.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(463, 475);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 25);
            this.label4.TabIndex = 19;
            this.label4.Text = "Thuế:";
            // 
            // txtDoanhThu
            // 
            this.txtDoanhThu.Location = new System.Drawing.Point(293, 477);
            this.txtDoanhThu.Name = "txtDoanhThu";
            this.txtDoanhThu.Size = new System.Drawing.Size(151, 22);
            this.txtDoanhThu.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(130, 475);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "Tổng doanh thu:";
            // 
            // btnXuat
            // 
            this.btnXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuat.Location = new System.Drawing.Point(786, 103);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(84, 31);
            this.btnXuat.TabIndex = 16;
            this.btnXuat.Text = "Xuất";
            this.btnXuat.UseVisualStyleBackColor = true;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(392, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(389, 32);
            this.label2.TabIndex = 15;
            this.label2.Text = "DOANH THU THEO THÁNG";
            // 
            // dgDS
            // 
            this.dgDS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDS.Location = new System.Drawing.Point(130, 148);
            this.dgDS.Name = "dgDS";
            this.dgDS.RowHeadersWidth = 51;
            this.dgDS.RowTemplate.Height = 24;
            this.dgDS.Size = new System.Drawing.Size(881, 298);
            this.dgDS.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(351, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Chọn tháng: ";
            // 
            // cboThang
            // 
            this.cboThang.FormattingEnabled = true;
            this.cboThang.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cboThang.Location = new System.Drawing.Point(482, 104);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(83, 24);
            this.cboThang.TabIndex = 23;
            // 
            // cboNam
            // 
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Items.AddRange(new object[] {
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025"});
            this.cboNam.Location = new System.Drawing.Point(695, 104);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(83, 24);
            this.cboNam.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(575, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 25);
            this.label6.TabIndex = 24;
            this.label6.Text = "Chọn năm: ";
            // 
            // frmDoanhThuTheoThang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 594);
            this.Controls.Add(this.cboNam);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboThang);
            this.Controls.Add(this.txtLoiNhuan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtThue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDoanhThu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgDS);
            this.Controls.Add(this.label1);
            this.Name = "frmDoanhThuTheoThang";
            this.Text = "frmDoanhThuTheoThang";
            ((System.ComponentModel.ISupportInitialize)(this.dgDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLoiNhuan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtThue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDoanhThu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgDS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboThang;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.Label label6;
    }
}