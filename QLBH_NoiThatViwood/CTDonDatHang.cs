//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLBH_NoiThatViwood
{
    using System;
    using System.Collections.Generic;
    
    public partial class CTDonDatHang
    {
        public string MaDonDat { get; set; }
        public string MaSP { get; set; }
        public int SoLuongDat { get; set; }
    
        public virtual DonDatHang DonDatHang { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
