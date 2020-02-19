namespace SafeTravel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Allergy")]
    public partial class Allergy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Allergy()
        {
            Patient = new HashSet<Patient>();
        }

        [Key]
        public int allergy_id { get; set; }

        [Required]
        [StringLength(50)]
        public string allergy_name { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string info { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient> Patient { get; set; }
    }
}
