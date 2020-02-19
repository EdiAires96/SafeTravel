namespace SafeTravel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_Pharmacy
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int order_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pharmacy_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int product_id { get; set; }

        public int quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? order_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? delivery_date { get; set; }

        [Column(TypeName = "text")]
        public string info { get; set; }

        public int isDelivered { get; set; }

        public virtual Pharmacy Pharmacy { get; set; }

        public virtual Product Product { get; set; }
    }
}
