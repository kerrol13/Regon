using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Moq;
using Regon.Application.Common;
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

            var localFileServiceMock = new Mock<ILocalFileService>();

            localFileServiceMock
            .Setup(x => x.SaveFileAsync(It.IsAny<IFormFile>()))
            .ReturnsAsync("fake-signature.png");

            var service = new CustomerService(repoMock.Object, localFileServiceMock.Object);

            var fileMock = new Mock<IFormFile>();

            var customer = new CustomerCreateDto
            {
                FirstName = "Sample",
                LastName = "Test",
                Email = "sample@test.com",
                Signature = CreateFakeFile(),
                PhoneNumber = "1234567890"
            };

            await service.AddAsync(customer);
            localFileServiceMock.Verify(r => r.SaveFileAsync(It.IsAny<IFormFile>()), Times.Once);
            repoMock.Verify(r => r.AddAsync(It.IsAny<Customer>()), Times.Once);
            repoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task GetCustomerById_Should_ReturnCustomer()
        {
            var repoMock = new Mock<ICustomerRepository>();
            var localFileServiceMock = new Mock<ILocalFileService>();

            var expectedCustomer = new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = "Sample"
            };

            repoMock.Setup(r => r.GetByIdAsync(expectedCustomer.Id))
                    .ReturnsAsync(expectedCustomer);

            var service = new CustomerService(repoMock.Object, localFileServiceMock.Object);

            var result = await service.GetByIdAsync(expectedCustomer.Id);

            Assert.NotNull(result);
            Assert.Equal(expectedCustomer.Id, result!.Id);
        }

        [Fact]
        public async Task GetAllCustomers_ShouldReturn_AllCustomers()
        {
            var repoMock = new Mock<ICustomerRepository>();
            var localFileServiceMock = new Mock<ILocalFileService>();

            var expectedCustomers = new List<Customer>
            {
                new() { Id = Guid.NewGuid(), FirstName = "Sample" },
                new() { Id = Guid.NewGuid(), FirstName = "Test" }
            };

            repoMock
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(expectedCustomers);

            var service = new CustomerService(repoMock.Object, localFileServiceMock.Object);

            var result = await service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());

            repoMock.Verify(r => r.GetAllAsync(), Times.Once);
        }

        private IFormFile CreateFakeFile()
        {
            var content = "fake file content";
            var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(content));

            return new FormFile(stream, 0, stream.Length, "Signature", "sig.png");
        }
    }
}
