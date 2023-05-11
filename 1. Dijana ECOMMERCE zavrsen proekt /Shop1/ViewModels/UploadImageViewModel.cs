using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Shop1.ViewModels
{
    public class UploadImageViewModel
    {
        [Display(Name = "Product Picture")]
        public IFormFile ProductPictureUpload { get; set; }

        [Display(Name = "Product Picture Back")]
        public IFormFile ProductPictureUploadBack { get; set; }
    }
}
