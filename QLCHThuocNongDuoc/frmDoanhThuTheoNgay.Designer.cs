namespace QLCHThuocNongDuoc
{
    partial class frmDoanhThuTheoNgay
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.dgDS = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXuat = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDoanhThu = new System.Windows.Forms.TextBox();
            this.txtThue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLoiNhuan = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgDS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(371, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn ngày: ";
            // 
            // dtp
            // 
            this.dtp.Location = new System.Drawing.Point(497, 77);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(247, 22);
            this.dtp.TabIndex = 1;
            // 
            // dgDS
            // 
            this.dgDS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDS.Location = new System.Drawing.Point(150, 120);
            this.dgDS.Name = "dgDS";
            this.dgDS.RowHeadersWidth = 51;
            this.dgDS.RowTemplate.Height = 24;
            this.dgDS.Size = new System.Drawing.Size(881, 298);
            this.dgDS.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(412, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(370, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "DOANH THU THEO NGÀY";
            // 
            // btnXuat
            // 
            this.btnXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuat.Location = new System.Drawing.Point(750, 72);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(84, 31);
            this.btnXuat.TabIndex = 5;
            this.btnXuat.Text = "Xuất";
            this.btnXuat.UseVisualStyleBackColor = true;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(150, 447);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tổng doanh thu:";
            // 
            // txtDoanhThu
            // 
            this.txtDoanhThu.Location = new System.Drawing.Point(313, 449);
            this.txtDoanhThu.Name = "txtDoanhThu";
            this.txtDoanhThu.Size = new System.Drawing.Size(151, 22);
            this.txtDoanhThu.TabIndex = 7;
            // 
            // txtThue
            // 
            this.txtThue.Location = new System.Drawing.Point(553, 449);
            this.txtThue.Name = "txtThue";
            this.txtThue.Size = new System.Drawing.Size(167, 22);
            this.txtThue.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(483, 447);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Thuế:";
            // 
            // txtLoiNhuan
            // 
            this.txtLoiNhuan.Location = new System.Drawing.Point(883, 450);
            this.txtLoiNhuan.Name = "txtLoiNhuan";
            this.txtLoiNhuan.Size = new System.Drawing.Size(148, 22);
            this.txtLoiNhuan.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(735, 447);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Lợi nhuận gộp:";
            // 
            // frmDoanhThuTheoNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 520);
            this.Controls.Add(this.txtLoiNhuan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtThue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDoanhThu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgDS);
            this.Controls.Add(this.dtp);
            this.Controls.Add(this.label1);
            this.Name = "frmDoanhThuTheoNgay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Doanh Thu Theo Ngày";
            ((System.ComponentModel.ISupportInitialize)(this.dgDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.DataGridView dgDS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDoanhThu;
        private System.Windows.Forms.TextBox txtThue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLoiNhuan;
        private System.Windows.Forms.Label label5;
    }
}