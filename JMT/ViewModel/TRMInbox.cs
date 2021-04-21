using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.ViewModel
{
    public class TRMInbox
    {
        [Column("RMInboxID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int RMInboxID { get; set; }

        [Column("ResourceManagerID")]
        [Required]
        public int ResourceManagerID { get; set; }

        [Column("FirstName")]
        [StringLength(1073741791)]
        public string FirstName { get; set; }

        [Column("LastName")]
        [StringLength(1073741791)]
        public string LastName { get; set; }

        [Column("ChatMessage")]
        [StringLength(1073741791)]
        [Required]
        public string ChatMessage { get; set; }

        [Column("MessageDate")]
        [Required]
        public DateTime MessageDate { get; set; }

        [Column("Email")]
        [StringLength(1073741791)]
        public string Email { get; set; }

        [Column("Title")]
        [StringLength(1073741791)]
        public string Title { get; set; }
    }
}
