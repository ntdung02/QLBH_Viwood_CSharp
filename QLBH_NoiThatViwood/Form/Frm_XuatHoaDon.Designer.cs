
namespace QLBH_NoiThatViwood
{
    partial class Frm_XuatHoaDon
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
            this.XuatHoaDonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new QLBH_NoiThatViwood.DataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.txtMaHoaDon = new System.Windows.Forms.TextBox();
            this.XuatHoaDonTableAdapter = new QLBH_NoiThatViwood.DataSet1TableAdapters.XuatHoaDonTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.XuatHoaDonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // XuatHoaDonBindingSource
            // 
            this.XuatHoaDonBindingSource.DataMember = "XuatHoaDon";
            this.XuatHoaDonBindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.XuatHoaDonBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLBH_NoiThatViwood.Report.ReportXuatHoaDon.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(598, 569);
            this.reportViewer1.TabIndex = 0;
            // 
            // txtMaHoaDon
            // 
            this.txtMaHoaDon.Location = new System.Drawing.Point(588, 29);
            this.txtMaHoaDon.Name = "txtMaHoaDon";
            this.txtMaHoaDon.Size = new System.Drawing.Size(1, 20);
            this.txtMaHoaDon.TabIndex = 2;
            // 
            // XuatHoaDonTableAdapter
            // 
            this.XuatHoaDonTableAdapter.ClearBeforeFill = true;
            // 
            // Frm_XuatHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(598, 569);
            this.Controls.Add(this.txtMaHoaDon);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_XuatHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XUẤT HOÁ ĐƠN";
            this.Load += new System.EventHandler(this.Frm_XuatHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.XuatHoaDonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource XuatHoaDonBindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.XuatHoaDonTableAdapter XuatHoaDonTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TextBox txtMaHoaDon;
    }
}