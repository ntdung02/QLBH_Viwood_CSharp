﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH_NoiThatViwood.Report
{
    public partial class Frm_reportNCC : Form
    {
        public Frm_reportNCC()
        {
            InitializeComponent();
        }

        private void Frm_reportNCC_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.NhaCungCap' table. You can move, or remove it, as needed.
            this.nhaCungCapTableAdapter.Fill(this.dataSet1.NhaCungCap);

            this.reportViewer1.RefreshReport();
        }
    }
}
