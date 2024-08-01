using System;
using System.ComponentModel.DataAnnotations;

namespace VentageRepositoryModel.Model
{
    public class CustomerModel : DataObject, ICustomerModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public CustomerAddressModel Address { get; set; }

        public string Country { get; set; }

        public string? PhoneNumber { get; set; }

        [Url(ErrorMessage = "Please enter a valid URL")]
        public string? Website { get; set; }

        public List<ContactModel> Contacts { get; set; }

    }

    
}

