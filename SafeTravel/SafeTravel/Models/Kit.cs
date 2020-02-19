namespace SafeTravel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kit")]
    public partial class Kit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kit()
        {
            Appointment = new HashSet<Appointment>();
            Kit_Product = new HashSet<Kit_Product>();
        }

        [Key]
        public int kit_id { get; set; }

        public int medic_id { get; set; }

        [Column(TypeName = "text")]
        public string info { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointment { get; set; }

        public virtual Medic Medic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kit_Product> Kit_Product { get; set; }
    }
}
