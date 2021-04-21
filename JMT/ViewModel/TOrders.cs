using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.ViewModel
{
    public class TOrders
    {
        [Column("OrderID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int OrderID { get; set; }

        [Column("CustomerID")]
        [Required]
        public int CustomerID { get; set; }

        [Column("DeveloperID")]
        [Required]
        public int DeveloperID { get; set; }

        [Column("Price")]
        [StringLength(1073741791)]
        public string Price { get; set; }

        [Column("CompletionDate")]
        public DateTime CompletionDate { get; set; }

        [Column("OrderDesc")]
        [StringLength(1073741791)]
        public string OrderDesc { get; set; }

        [Column("Requirements")]
        [StringLength(1073741791)]
        [Required]
        public string Requirements { get; set; }

        [Column("DateCreated")]
        public DateTime DateCreated { get; set; }


        [Column("Status")]
        [StringLength(1073741791)]
        public string Status { get; set; }

        [Column("CustomerReview")]
        [StringLength(1073741791)]
        public string CustomerReview { get; set; }

        [Column("Rating")]
        [StringLength(1073741791)]
        public string Rating { get; set; }


       
    }
}
