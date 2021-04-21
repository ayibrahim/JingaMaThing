using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.ViewModel
{
    public class TResourceManagers
    {
        [Column("ResourceManagerID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ResourceManagerID { get; set; }

        [Column("FirstName")]
        [StringLength(1073741791)]
        [Required]
        public string FirstName { get; set; }

        [Column("LastName")]
        [StringLength(1073741791)]
        [Required]
        public string LastName { get; set; }

        [Column("PhoneNumber")]
        [StringLength(1073741791)]
        [Required]
        public string PhoneNumber { get; set; }

        [Column("Email")]
        [StringLength(1073741791)]
        [Required]
        public string Email { get; set; }

        [Column("Password")]
        [StringLength(1073741791)]
        [Required]
        public string Password { get; set; }

        [Column("RoleID")]
        [Required]
        public int RoleID { get; set; }

        [Column("Photo")]
        [StringLength(1073741791)]
        public string Photo { get; set; }

        [Column("SideBarColor")]
        [StringLength(1073741791)]
        [Required]
        public string SideBarColor { get; set; }

        [Column("DashboardColor")]
        [StringLength(1073741791)]
        [Required]
        public string DashboardColor { get; set; }
    }
}
