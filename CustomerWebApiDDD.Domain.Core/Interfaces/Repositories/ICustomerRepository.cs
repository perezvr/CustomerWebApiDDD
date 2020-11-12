using CustomerWebApiDDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerWebApiDDD.Domain.Core.Interfaces.Repositories
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
    }
}
