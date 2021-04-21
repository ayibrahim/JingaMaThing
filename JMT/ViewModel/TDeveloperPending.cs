using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.ViewModel
{
    public class TDeveloperPending
    {
        [Column("DeveloperPendingID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int DeveloperPendingID { get; set; }

        [Column("CustomerID")]
        [Required]
        public int CustomerID { get; set; }

        [Column("DeveloperID")]
        [Required]
        public int DeveloperID { get; set; }

        [Column("OrderDesc")]
        [StringLength(1073741791)]
        public string OrderDesc { get; set; }

        [Column("DateRequested")]
        public DateTime DateRequested { get; set; }

        [Column("Budget")]
        [StringLength(1073741791)]
        public string Budget { get; set; }

        [Column("Requirements")]
        [StringLength(1073741791)]
        public string Requirements { get; set; }

        [Column("DPStatus")]
        [StringLength(1073741791)]
        public string DPStatus { get; set; }

        [Column("DateCreated")]
        public DateTime DateCreated { get; set; }
    }
}
