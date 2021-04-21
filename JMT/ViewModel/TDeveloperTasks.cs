using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.ViewModel
{
    public class TDeveloperTasks
    {
        [Column("DeveloperTaskID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int DeveloperTaskID { get; set; }

        [Column("OrderID")]
        [Required]
        public int OrderID { get; set; }

        [Column("DeveloperID")]
        [Required]
        public int DeveloperID { get; set; }

        [Column("Title")]
        [StringLength(1073741791)]
        public string Title { get; set; }

        [Column("Description")]
        [StringLength(1073741791)]
        public string Description { get; set; }

        [Column("Notes")]
        [StringLength(1073741791)]
        public string Notes { get; set; }

        [Column("Status")]
        [StringLength(1073741791)]
        public string Status { get; set; }

       
    }
}
