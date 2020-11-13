using CustomerWebApiDDD.Application.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CustomerWebApiDDD.Application.Interfaces
{
    public interface ICustomerApplicationService
    {
        List<CustomerDTO> Get();
        CustomerDTO Get(int id);
        CustomerDTO Insert(CustomerDTO customerDTO);
        CustomerDTO Update(int id, CustomerDTO customerDTO);
        void Delete(int id);
    }
}
