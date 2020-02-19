namespace SafeTravel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FemaleCondition")]
    public partial class FemaleCondition
    {
        [Key]
        public int fc_id { get; set; }

        public int female_id { get; set; }

        public bool isPregnant { get; set; }

        public bool pill { get; set; }

        public bool infertility { get; set; }

        public bool hopes_get_pregnant { get; set; }

        public bool breast_feeding { get; set; }

        [Column(TypeName = "text")]
        public string info { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
