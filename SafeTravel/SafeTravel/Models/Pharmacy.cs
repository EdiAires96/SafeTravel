namespace SafeTravel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pharmacy")]
    public partial class Pharmacy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pharmacy()
        {
            Order_Pharmacy = new HashSet<Order_Pharmacy>();
            Stock = new HashSet<Stock>();
        }

        [Key]
        public int pharmacy_id { get; set; }

        [Required]
        [StringLength(50)]
        public string p_name { get; set; }

        [Required]
        [StringLength(70)]
        public string adress { get; set; }

        public int phone_number { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        public bool is_active { get; set; }

        [Required]
        [StringLength(10)]
        public string ident { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Pharmacy> Order_Pharmacy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock> Stock { get; set; }
    }
}
