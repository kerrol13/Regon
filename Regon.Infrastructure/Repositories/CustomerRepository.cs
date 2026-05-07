using Regon.Domain.Entities;
using Regon.Domain.Repositories;
using Regon.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Regon.Infrastructure.Repositories
{
    public class CustomerRepository(AppDbContext context) : BaseRepository<Customer>(context),ICustomerRepository
    {
    }
}
    