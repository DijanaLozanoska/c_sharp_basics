using System;
using System.Collections.Generic;

namespace Shop1.Models
{
    public class MergeProductCategory
    {

        public MergeProductCategory()
        {
            ProductMerged = new List<Product>();
            CategoryMerged = new List<Category>();

        }

        public List<Product> ProductMerged { get; set; }

        public List<Category> CategoryMerged { get; set; }

    }
}