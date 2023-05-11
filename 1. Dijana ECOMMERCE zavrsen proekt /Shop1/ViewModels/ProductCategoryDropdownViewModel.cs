using System;
using System.Collections.Generic;

namespace Shop1.Models
{
    public class ProductCategoryDropdownViewModel
    {
        public ProductCategoryDropdownViewModel()
        {
            Categories = new List<Category>();
        }

        public List<Category> Categories { get; set; }
    }

}