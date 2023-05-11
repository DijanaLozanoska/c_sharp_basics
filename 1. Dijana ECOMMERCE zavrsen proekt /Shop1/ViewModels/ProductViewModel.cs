using System;
using System.ComponentModel.DataAnnotations;
using Shop1.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop1.ViewModels
{
    public class ProductViewModel : EditImageViewModel
    {
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Name of the product is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Product name must be between 3 and 50 chars")]
        public string ProductName { get; set; }

        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }

        [Display(Name = "Product Price")]
        [Required(ErrorMessage = "Price of the product is required")]
        public decimal ProductPrice { get; set; }

        [Required]
        [Display(Name = "Available")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Product Category")]
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Categories { get; set; }
    }
}
