using System;
using System.ComponentModel.DataAnnotations;

namespace proba6.Models
{
    public class NewProductVm
    {
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Name of the product is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Product name must be between 3 and 50 chars")]
        public string ProductName { get; set; }

        [Display(Name = "Product Description")]
        [Required(ErrorMessage = "Description of the product is required")]
        public string ProductDescription { get; set; }

        [Display(Name = "Product Price")]
        [Required(ErrorMessage = "Price of the product is required")]
        public decimal ProductPrice { get; set; }

        [Display(Name = "Product Picture")]
        public string ProductPicture { get; set; }

        [Required]
        [Display(Name = "Available")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Select product category")]
        [Required(ErrorMessage = "Product category is required")]
        public int CategoryId { get; set; }
    }
}
