using Regon.Application.Common;
using Regon.Application.Dtos.Customer;
using Regon.Application.Interfaces;
using Regon.Application.Mappers;
using Regon.Domain.Entities;
using Regon.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Regon.Application.Services
{
    public class CustomerService(ICustomerRepository customerRepo,ILocalFileService localFileService) : ICustomerService
    {

        public async Task<CustomerResponseDto?> GetByIdAsync(Guid id)
        {
            var customer = await customerRepo.GetByIdAsync(id);
            return customer?.ToCustomerResponseDto();
        }

        public async Task<IEnumerable<CustomerResponseDto>> GetAllAsync()
        {
            var customer = await customerRepo.GetAllAsync();
            return customer.Select(x => x.ToCustomerResponseDto()).ToList();
        }

        public async Task<CustomerResponseDto> AddAsync(CustomerCreateDto createDto)
        {
            if (createDto.Signature == null || createDto.Signature.Length == 0)
            {
                throw new ArgumentException("Signature file is required");
            }

            var signaturePath = await localFileService.SaveFileAsync(createDto.Signature);

            var customer = createDto.ToEntity();
            customer.SignaturePath = signaturePath;

            await customerRepo.AddAsync(customer);
            await customerRepo.SaveChangesAsync();

            return customer.ToCustomerResponseDto();
        }
    }
}
