using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp_net_core_web_app_razor_pages.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }
    }
}
