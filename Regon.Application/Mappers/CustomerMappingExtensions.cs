using Regon.Application.Dtos.Customer;
using Regon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Regon.Application.Mappers
{
    public static class CustomerMappingExtensions
    {
        public static CustomerResponseDto ToCustomerResponseDto(this Customer customer)
        {
            return new CustomerResponseDto
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                SignaturePath = customer.SignaturePath,
                DateCreated = customer.DateCreated
            };
        }

        public static Customer ToEntity(this CustomerCreateDto createDto)
        {
            return new Customer
            {
                FirstName = createDto.FirstName,
                LastName = createDto.LastName,
                Email = createDto.Email,
                PhoneNumber = createDto.PhoneNumber
            };
        }
    }
}
