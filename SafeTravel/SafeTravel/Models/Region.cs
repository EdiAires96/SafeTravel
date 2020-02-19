namespace SafeTravel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Region")]
    public partial class Region
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Region()
        {
            Trip = new HashSet<Trip>();
        }

        [Key]
        public int region_id { get; set; }

        [Required]
        [StringLength(50)]
        public string r_name { get; set; }

        [Column(TypeName = "text")]
        public string countries { get; set; }

        [Column(TypeName = "text")]
        public string precautions { get; set; }

        [Column(TypeName = "text")]
        public string info { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trip> Trip { get; set; }
    }
}
