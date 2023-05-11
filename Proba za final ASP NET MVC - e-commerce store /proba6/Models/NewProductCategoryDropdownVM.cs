using System;
using System.Collections.Generic;

namespace proba6.Models
{
    public class NewProductCategoryDropdownVM
    {

        public NewProductCategoryDropdownVM()
        {
            Categories = new List<Category>();
        }

        public List<Category> Categories { get; set; }
    }
}
