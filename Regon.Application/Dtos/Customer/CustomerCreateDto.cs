using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Regon.Application.Dtos.Customer
{
    public class CustomerCreateDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public IFormFile Signature { get; set; }
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
