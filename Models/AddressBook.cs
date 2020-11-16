using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookPro.Models
{
    public class AddressBook
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "File Name")]
        public string FileName { get; set; }

        public byte[] Image { get; set; }

        [Display(Name = "Address 1")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        public string City { get; set; }

        [StringLength(2)]
        public string State { get; set; }

        [DataType(DataType.PostalCode)]
        [StringLength(5)]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Date Added")]
        public DateTimeOffset DateAdded { get; set; }
    }
}
