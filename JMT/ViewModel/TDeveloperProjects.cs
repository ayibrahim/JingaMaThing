using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.ViewModel
{
    public class TDeveloperProjects
    {
        [Column("DeveloperProjectID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int DeveloperProjectID { get; set; }

        [Column("DeveloperID")]
        [Required]
        public int DeveloperID { get; set; }

        [Column("PreviewImageSrc")]
        [StringLength(1073741791)]
        [Required]
        public string PreviewImageSrc { get; set; }

        [Column("ThumbnailImageSrc")]
        [StringLength(1073741791)]
        [Required]
        public string ThumbnailImageSrc { get; set; }

        [Column("Alt")]
        [StringLength(1073741791)]
        [Required]
        public string Alt { get; set; }

        [Column("Title")]
        [StringLength(1073741791)]
        [Required]
        public string Title { get; set; }

       
    }
}
