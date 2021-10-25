using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookstore_api_10_07_2021.Models
{
    [Table("Categories")]

    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CategoryID { get; set; }

        [StringLength(100)]

        public string CategoryName { get; set; }

        [StringLength(1000)]

        public string Description { get; set; }

        public List<Book> Books { get; set; }

    }
}
