using Microsoft.AspNetCore.Mvc;
using Regon.Application.Common;
using Regon.Application.Dtos.Customer;
using Regon.Application.Interfaces;
using Regon.Domain.Entities;
using Regon.Infrastructure.Storage;

namespace Regon.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomersContoller(ICustomerService customerService, ILocalFileService localFileService) : ControllerBase
    {
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var customer = await customerService.GetByIdAsync(id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var customers = await customerService.GetAllAsync();
            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromForm]CustomerCreateDto customerCreateDto)
        {
            var customers = await customerService.AddAsync(customerCreateDto);
            return Ok(customers);
        }
    }
}
