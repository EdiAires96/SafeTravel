namespace SafeTravel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Appointment")]
    public partial class Appointment
    {
        [Key]
        public int appointment_id { get; set; }

        public int medic_id { get; set; }

        public int patient_id { get; set; }

        public int? diagnostic_id { get; set; }

        public DateTime a_date { get; set; }

        [Column(TypeName = "text")]
        public string obs { get; set; }

        public int? kit_id { get; set; }

        public virtual Diagnostic Diagnostic { get; set; }

        public virtual Kit Kit { get; set; }

        public virtual Medic Medic { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
