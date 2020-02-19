namespace SafeTravel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Diagnostic")]
    public partial class Diagnostic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Diagnostic()
        {
            Appointment = new HashSet<Appointment>();
            Trip = new HashSet<Trip>();
        }

        [Key]
        public int diagnostic_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? begin_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? end_date { get; set; }

        [Column(TypeName = "text")]
        public string reason { get; set; }

        [Column(TypeName = "text")]
        public string health_condition { get; set; }

        [Column(TypeName = "text")]
        public string medicines { get; set; }

        public int? isSmoker { get; set; }

        public int? firstTime { get; set; }

        [Column(TypeName = "text")]
        public string allergic { get; set; }

        [Column(TypeName = "text")]
        public string surgery { get; set; }

        [Column(TypeName = "text")]
        public string recentSick { get; set; }

        [Column(TypeName = "text")]
        public string malaria { get; set; }

        [Column(TypeName = "text")]
        public string vaccines { get; set; }

        [Column(TypeName = "text")]
        public string sickTravelling { get; set; }

        [Column(TypeName = "text")]
        public string obs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trip> Trip { get; set; }
    }
}
