
namespace QLBH_NoiThatViwood
{
    partial class Frm_ThongKe
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DonDatHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new QLBH_NoiThatViwood.DataSet1();
            this.NhapHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HoaDonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnThongKe_DDH = new System.Windows.Forms.Button();
            this.dtpDenNgay_DDH = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTuNgay_DDH = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.dtpDenNgay_PN = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpTuNgay_PN = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnThongKe_HD = new System.Windows.Forms.Button();
            this.dtpDenNgay_HD = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpTuNgay_HD = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.DonDatHangTableAdapter = new QLBH_NoiThatViwood.DataSet1TableAdapters.DonDatHangTableAdapter();
            this.NhapHangTableAdapter = new QLBH_NoiThatViwood.DataSet1TableAdapters.NhapHangTableAdapter();
            this.HoaDonTableAdapter = new QLBH_NoiThatViwood.DataSet1TableAdapters.HoaDonTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DonDatHangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NhapHangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoaDonBindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // DonDatHangBindingSource
            // 
            this.DonDatHangBindingSource.DataMember = "DonDatHang";
            this.DonDatHangBindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // NhapHangBindingSource
            // 
            this.NhapHangBindingSource.DataMember = "NhapHang";
            this.NhapHangBindingSource.DataSource = this.DataSet1;
            // 
            // HoaDonBindingSource
            // 
            this.HoaDonBindingSource.DataMember = "HoaDon";
            this.HoaDonBindingSource.DataSource = this.DataSet1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1068, 646);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.reportViewer1);
            this.tabPage1.Controls.Add(this.btnThongKe_DDH);
            this.tabPage1.Controls.Add(this.dtpDenNgay_DDH);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dtpTuNgay_DDH);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1060, 613);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Đơn Đặt Hàng";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DonDatHangBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLBH_NoiThatViwood.Report.ReportDonDatHang.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(63, 103);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(958, 459);
            this.reportViewer1.TabIndex = 5;
            // 
            // btnThongKe_DDH
            // 
            this.btnThongKe_DDH.Location = new System.Drawing.Point(421, 60);
            this.btnThongKe_DDH.Name = "btnThongKe_DDH";
            this.btnThongKe_DDH.Size = new System.Drawing.Size(133, 29);
            this.btnThongKe_DDH.TabIndex = 4;
            this.btnThongKe_DDH.Text = "THỐNG KÊ";
            this.btnThongKe_DDH.UseVisualStyleBackColor = true;
            this.btnThongKe_DDH.Click += new System.EventHandler(this.btnThongKe_DDH_Click);
            // 
            // dtpDenNgay_DDH
            // 
            this.dtpDenNgay_DDH.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDenNgay_DDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDenNgay_DDH.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay_DDH.Location = new System.Drawing.Point(595, 18);
            this.dtpDenNgay_DDH.Name = "dtpDenNgay_DDH";
            this.dtpDenNgay_DDH.Size = new System.Drawing.Size(155, 26);
            this.dtpDenNgay_DDH.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(504, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến ngày";
            // 
            // dtpTuNgay_DDH
            // 
            this.dtpTuNgay_DDH.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTuNgay_DDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTuNgay_DDH.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay_DDH.Location = new System.Drawing.Point(299, 17);
            this.dtpTuNgay_DDH.Name = "dtpTuNgay_DDH";
            this.dtpTuNgay_DDH.Size = new System.Drawing.Size(155, 26);
            this.dtpTuNgay_DDH.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(208, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.reportViewer2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.dtpDenNgay_PN);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.dtpTuNgay_PN);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1060, 613);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Phiếu Nhập";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // reportViewer2
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.NhapHangBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "QLBH_NoiThatViwood.Report.ReportNhapHang.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(46, 115);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(972, 445);
            this.reportViewer2.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(472, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 29);
            this.button1.TabIndex = 9;
            this.button1.Text = "THỐNG KÊ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtpDenNgay_PN
            // 
            this.dtpDenNgay_PN.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDenNgay_PN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDenNgay_PN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay_PN.Location = new System.Drawing.Point(646, 21);
            this.dtpDenNgay_PN.Name = "dtpDenNgay_PN";
            this.dtpDenNgay_PN.Size = new System.Drawing.Size(155, 26);
            this.dtpDenNgay_PN.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(555, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Đến ngày";
            // 
            // dtpTuNgay_PN
            // 
            this.dtpTuNgay_PN.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTuNgay_PN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTuNgay_PN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay_PN.Location = new System.Drawing.Point(350, 20);
            this.dtpTuNgay_PN.Name = "dtpTuNgay_PN";
            this.dtpTuNgay_PN.Size = new System.Drawing.Size(155, 26);
            this.dtpTuNgay_PN.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(259, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Từ ngày";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.reportViewer3);
            this.tabPage3.Controls.Add(this.btnThongKe_HD);
            this.tabPage3.Controls.Add(this.dtpDenNgay_HD);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.dtpTuNgay_HD);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1060, 613);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Hoá Đơn";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // reportViewer3
            // 
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.HoaDonBindingSource;
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "QLBH_NoiThatViwood.Report.ReportThongKeHoaDon.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(40, 124);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.ServerReport.BearerToken = null;
            this.reportViewer3.Size = new System.Drawing.Size(986, 444);
            this.reportViewer3.TabIndex = 15;
            // 
            // btnThongKe_HD
            // 
            this.btnThongKe_HD.Location = new System.Drawing.Point(479, 76);
            this.btnThongKe_HD.Name = "btnThongKe_HD";
            this.btnThongKe_HD.Size = new System.Drawing.Size(133, 29);
            this.btnThongKe_HD.TabIndex = 14;
            this.btnThongKe_HD.Text = "THỐNG KÊ";
            this.btnThongKe_HD.UseVisualStyleBackColor = true;
            this.btnThongKe_HD.Click += new System.EventHandler(this.btnThongKe_HD_Click);
            // 
            // dtpDenNgay_HD
            // 
            this.dtpDenNgay_HD.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDenNgay_HD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDenNgay_HD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay_HD.Location = new System.Drawing.Point(653, 34);
            this.dtpDenNgay_HD.Name = "dtpDenNgay_HD";
            this.dtpDenNgay_HD.Size = new System.Drawing.Size(155, 26);
            this.dtpDenNgay_HD.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(562, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Đến ngày";
            // 
            // dtpTuNgay_HD
            // 
            this.dtpTuNgay_HD.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTuNgay_HD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTuNgay_HD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay_HD.Location = new System.Drawing.Point(357, 33);
            this.dtpTuNgay_HD.Name = "dtpTuNgay_HD";
            this.dtpTuNgay_HD.Size = new System.Drawing.Size(155, 26);
            this.dtpTuNgay_HD.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(266, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Từ ngày";
            // 
            // DonDatHangTableAdapter
            // 
            this.DonDatHangTableAdapter.ClearBeforeFill = true;
            // 
            // NhapHangTableAdapter
            // 
            this.NhapHangTableAdapter.ClearBeforeFill = true;
            // 
            // HoaDonTableAdapter
            // 
            this.HoaDonTableAdapter.ClearBeforeFill = true;
            // 
            // Frm_ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 646);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_ThongKe";
            this.Text = "THỐNG KÊ";
            this.Load += new System.EventHandler(this.Frm_ThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DonDatHangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NhapHangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoaDonBindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btnThongKe_DDH;
        private System.Windows.Forms.DateTimePicker dtpDenNgay_DDH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTuNgay_DDH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.BindingSource DonDatHangBindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.DonDatHangTableAdapter DonDatHangTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtpDenNgay_PN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpTuNgay_PN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource NhapHangBindingSource;
        private DataSet1TableAdapters.NhapHangTableAdapter NhapHangTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer3;
        private System.Windows.Forms.Button btnThongKe_HD;
        private System.Windows.Forms.DateTimePicker dtpDenNgay_HD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpTuNgay_HD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource HoaDonBindingSource;
        private DataSet1TableAdapters.HoaDonTableAdapter HoaDonTableAdapter;
    }
}