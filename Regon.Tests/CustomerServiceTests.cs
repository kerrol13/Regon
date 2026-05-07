using Moq;
using Regon.Application.Dtos.Customer;
using Regon.Application.Services;
using Regon.Domain.Entities;
using Regon.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Xunit;

namespace Regon.Tests
{
    public class CustomerServiceTests
    {
        [Fact]
        public async Task CreateCustomer_Should_CallRepository_Add()
        {
            var repoMock = new Mock<ICustomerRepository>();

            var service = new CustomerService(repoMock.Object);

            var customer = new CustomerCreateDto
            {
                FirstName = "Sample",
                LastName = "Test",
                Email = "sample@test.com"
            };

            await service.AddAsync(customer, "signature-path");

            repoMock.Verify(r => r.AddAsync(It.IsAny<Customer>()), Times.Once);
            repoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task GetCustomerById_Should_ReturnCustomer()
        {
            var repoMock = new Mock<ICustomerRepository>();

            var expectedCustomer = new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = "Sample"
            };

            repoMock.Setup(r => r.GetByIdAsync(expectedCustomer.Id))
                    .ReturnsAsync(expectedCustomer);

            var service = new CustomerService(repoMock.Object);

            var result = await service.GetByIdAsync(expectedCustomer.Id);

            Assert.NotNull(result);
            Assert.Equal(expectedCustomer.Id, result!.Id);
        }

        [Fact]
        public async Task GetAllCustomers_ShouldReturn_AllCustomers()
        {
            var repoMock = new Mock<ICustomerRepository>();

            var expectedCustomers = new List<Customer>
            {
                new() { Id = Guid.NewGuid(), FirstName = "Sample" },
                new() { Id = Guid.NewGuid(), FirstName = "Test" }
            };

            repoMock
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(expectedCustomers);

            var service = new CustomerService(repoMock.Object);

            var result = await service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());

            repoMock.Verify(r => r.GetAllAsync(), Times.Once);
        }
    }
}
