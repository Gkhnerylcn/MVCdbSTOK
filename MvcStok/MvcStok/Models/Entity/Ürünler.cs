//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ürünler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ürünler()
        {
            this.Satış = new HashSet<Satış>();
        }
    
        public int Urunid { get; set; }
        public string UrunAd { get; set; }
        public Nullable<short> UrunKategori { get; set; }
        public Nullable<decimal> UrunFiyat { get; set; }
        public string Marka { get; set; }
        public Nullable<byte> Stok { get; set; }
    
        public virtual Kategori Kategori { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Satış> Satış { get; set; }
    }
}
