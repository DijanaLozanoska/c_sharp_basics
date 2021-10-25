using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proba6.Models
{
    public class Order
    {
        //public Order()
        //{
        //    OrderDetails = new List<OrderDetails>();
        //}
        [Key]
        public int Id { get; set; }

        public string OrderNo { get; set; }


        [Display(Name = "Order delivery to: ")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        

        [Display(Name = "Contact Number: ")]
        [Required(ErrorMessage = "Contact Number is required")]
        public string PhoneNo { get; set; }


        [EmailAddress]
        [Required(ErrorMessage = "E-mail input is required")]
        public string Email { get; set; }

        public string Address { get; set; }

        public DateTime OrderDate { get; set; }

        public virtual List<OrderDetails> OrderDetails { get; set; }
    }
}
