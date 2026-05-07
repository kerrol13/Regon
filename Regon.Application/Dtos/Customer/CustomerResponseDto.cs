using System;
using System.Collections.Generic;
using System.Text;

namespace Regon.Application.Dtos.Customer
{
    public class CustomerResponseDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? SignaturePath { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
