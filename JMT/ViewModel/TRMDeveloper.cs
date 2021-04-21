using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.ViewModel
{
    public class TRMDeveloper
    {
        [Column("RMDeveloperID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int RMDeveloperID { get; set; }

        [Column("ResourceManagerID")]
        [Required]
        public int ResourceManagerID { get; set; }


        [Column("DeveloperID")]
        [Required]
        public int DeveloperID { get; set; }

        
    }
}
