using System;
using System.ComponentModel.DataAnnotations;

namespace proba6.Models
{
    public class Category
    {
        [Required]
        public int Id { get; set; }
    
        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Name of the category is required")]
        public string CategoryName { get; set; }

    }

}
