using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.ViewModel
{
    public class TCustomerPending
    {
        [Column("CustomerPendingID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int CustomerPendingID { get; set; }

        [Column("CustomerID")]
        [Required]
        public int CustomerID { get; set; }

        [Column("DeveloperID")]
        [Required]
        public int DeveloperID { get; set; }

        [Column("PriceOffered")]
        [StringLength(1073741791)]
        [Required]
        public string PriceOffered { get; set; }

        [Column("DateOffered")]
        [Required]
        public DateTime DateOffered { get; set; }

        [Column("OrderDesc")]
        [StringLength(1073741791)]
        [Required]
        public string OrderDesc { get; set; }

        [Column("Requirements")]
        [StringLength(1073741791)]
        [Required]
        public string Requirements { get; set; }

        [Column("CPStatus")]
        [StringLength(1073741791)]
        public string CPStatus { get; set; }

        [Column("DateCreated")]
        public DateTime DateCreated { get; set; }
    }
}
