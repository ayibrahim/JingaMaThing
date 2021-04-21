using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.ViewModel
{
    public class TRoles
    {
        [Column("RoleID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int RoleID { get; set; }

        [Column("RoleDesc")]
        [StringLength(1073741791)]
        [Required]
        public string RoleDesc { get; set; }

       
    }
}
