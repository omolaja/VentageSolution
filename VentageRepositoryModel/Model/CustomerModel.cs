using System;
using System.ComponentModel.DataAnnotations;

namespace VentageRepositoryModel.Model
{
	public class CustomerModel
	{
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; } = "N/A";
        //public List<Contact> Contacts { get; set; }

    }
}

