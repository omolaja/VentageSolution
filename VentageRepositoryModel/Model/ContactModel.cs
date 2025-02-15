﻿using System;
using System.ComponentModel.DataAnnotations;

namespace VentageRepositoryModel.Model
{
    public class ContactModel : DataObject, IContactModel
    {

        public int CustomerId { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

    }
}

