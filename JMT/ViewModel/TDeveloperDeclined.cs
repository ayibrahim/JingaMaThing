using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
namespace JMT.ViewModel
{
    public class TDeveloperDeclined
    {
        [Column("DeveloperDeclinedID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int DeveloperDeclinedID { get; set; }

        [Column("OrderDescription")]
        [StringLength(1073741791)]
        public string OrderDescription { get; set; }

        [Column("DeclineReason")]
        [StringLength(1073741791)]
        public string DeclineReason { get; set; }

        [Column("DeclinedDate")]
        public DateTime DeclinedDate { get; set; }

        [Column("DeveloperPendingID")]
        public int DeveloperPendingID { get; set; }

        [Column("DeveloperID")]
        public int DeveloperID { get; set; }
    }
}
