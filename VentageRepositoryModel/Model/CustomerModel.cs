using System;
using System.ComponentModel.DataAnnotations;

namespace VentageRepositoryModel.Model
{
	public class CustomerModel : DataObject
	{
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public CustomerAddress Address { get; set; }

        public string Country { get; set; }

        public string? PhoneNumber { get; set; }

        [Url(ErrorMessage = "Please enter a valid URL")]
        public string? Website { get; set; }

        public List<Contact> Contacts { get; set; }

    }

    public class Contact
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string EmailAddress { get; set; }

        public string PhoneNumnber { get; set; }
    }

    public class CustomerAddress
    {
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        public string PostCode { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        public int CustomerId { get; set; }
    }
}

