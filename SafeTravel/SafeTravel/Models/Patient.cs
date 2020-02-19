namespace SafeTravel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Patient")]
    public partial class Patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient()
        {
            Appointment = new HashSet<Appointment>();
            FemaleCondition = new HashSet<FemaleCondition>();
            Allergy = new HashSet<Allergy>();
            Disease = new HashSet<Disease>();
            Vaccine = new HashSet<Vaccine>();
        }

        [Key]
        public int patient_id { get; set; }

        [Required]
        [StringLength(50)]
        public string p_name { get; set; }

        public int? phone_number { get; set; }

        [StringLength(30)]
        public string p_email { get; set; }

        [StringLength(50)]
        public string p_address { get; set; }

        [StringLength(30)]
        public string job { get; set; }

        [StringLength(30)]
        public string naturality { get; set; }

        [StringLength(1)]
        public string genre { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_of_birth { get; set; }

        public long? number_health { get; set; }

        public long? financial_number { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FemaleCondition> FemaleCondition { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Allergy> Allergy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Disease> Disease { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vaccine> Vaccine { get; set; }
    }
}
