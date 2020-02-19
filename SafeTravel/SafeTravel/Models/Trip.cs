namespace SafeTravel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Trip")]
    public partial class Trip
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int diagnostic_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int region_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        public string country { get; set; }

        [Column(TypeName = "text")]
        public string destination { get; set; }

        [Column(TypeName = "date")]
        public DateTime? begin_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? end_date { get; set; }

        [Column(TypeName = "text")]
        public string activities { get; set; }

        [Column(TypeName = "text")]
        public string accommodation { get; set; }

        [Column(TypeName = "text")]
        public string environment { get; set; }

        public virtual Diagnostic Diagnostic { get; set; }

        public virtual Region Region { get; set; }
    }
}
