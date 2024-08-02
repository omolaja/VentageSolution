using System;
using System.ComponentModel.DataAnnotations;

namespace VentageRepositoryModel.Model
{
    public class CustomerAddressModel :DataObject, ICustomerAddressModel
    {

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        public string PostCode { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string CountryId { get; set; }

        public int CustomerId { get; set; }

    }
}

