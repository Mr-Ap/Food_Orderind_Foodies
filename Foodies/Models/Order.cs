using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string ShoppingCartId { get; set; }

        [Required(ErrorMessage ="Enter Your FirstName and Lastname")]
        [Display(Name ="Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Your Address")]
        [Display(Name = "Address Line 1")]
        [StringLength(80)]
        public string AddressLine1 { get; set; }

        [Display(Name = "LandMark")]
        [StringLength(50)]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Enter City Name")]
        [StringLength(20)]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter PinCode")]
        [Display(Name="Pin Code")]
        [StringLength(6)]
        public string PinCode { get; set; }

        [Required(ErrorMessage = "Enter Mobile Number")]
        [Display(Name = "Contact/Mobile Number")]
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string Contact { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter your Email ")]
        [StringLength(25)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public decimal OrderTotal { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderPlaced { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public string OrderStatus { get; set; }

        
    }
}
