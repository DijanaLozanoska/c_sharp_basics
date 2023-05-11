using System;
using System.ComponentModel.DataAnnotations;

namespace Shop1.Models
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

