//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace K22CNT2_VuAnhDuong_2210900017_.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KHACH_HANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACH_HANG()
        {
            this.DON_HANG = new HashSet<DON_HANG>();
        }
    
        public int MaKH { get; set; }
        public string Ten_KH { get; set; }
        public string Email { get; set; }
        public string Dia_chi { get; set; }
        public string Mat_Khau { get; set; }
        public Nullable<System.DateTime> NgayDangKy { get; set; }
        public Nullable<byte> TrangThai { get; set; }
        public string SDT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DON_HANG> DON_HANG { get; set; }
    }
}
