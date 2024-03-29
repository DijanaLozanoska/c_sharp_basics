﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Shop1.Models
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
            [Display(Name = "Email Address: ")]
            [Required(ErrorMessage = "E-mail input is required")]
            public string Email { get; set; }

            [Display(Name = "Shipping Address: ")]
            public string Address { get; set; }

            [Display(Name = "Order Date: ")]
            public DateTime OrderDate { get; set; }

            public virtual List<OrderDetails> OrderDetails { get; set; }
        
    }
}
