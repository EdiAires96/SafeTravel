namespace SafeTravel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Medic")]
    public partial class Medic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medic()
        {
            Appointment = new HashSet<Appointment>();
            Kit = new HashSet<Kit>();
        }

        [Key]
        public int medic_id { get; set; }

        [Required]
        [StringLength(50)]
        public string m_mame { get; set; }

        public int phone_number { get; set; }

        [Required]
        [StringLength(30)]
        public string m_email { get; set; }

        [Required]
        [StringLength(10)]
        public string ident { get; set; }

        public bool is_active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kit> Kit { get; set; }
    }
}
