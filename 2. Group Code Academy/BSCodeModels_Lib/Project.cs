using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BSCodeModels_Lib.Support.SuportEnums;

namespace BSCodeModels_Lib
{
    [Table("tbl_project")]
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Please enter name!")]
        [Display(Name = "Project Name")]
        [StringLength(150, MinimumLength =5, ErrorMessage ="Project name must be between 5 and 150 characters!")]
        public string Name { get; set; }

        [StringLength(100, ErrorMessage = "Project description too long!")]
        public string Description { get; set; }

        [Display(Name = "Project level")]
        public Level Level { get; set; }

        [Display(Name = "Project technology used")]
        [Required(ErrorMessage = "Please enter technology used!")]
        public string TehnologyUsed { get; set; }

        [Display(Name = "Project link")]
        public string ProjectURL { get; set; }

        [Display(Name = "Project image")]
        public string ImageName { get; set; }
    }
}
