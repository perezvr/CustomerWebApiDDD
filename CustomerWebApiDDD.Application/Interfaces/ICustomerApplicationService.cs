using CustomerWebApiDDD.Application.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CustomerWebApiDDD.Application.Interfaces
{
    public interface ICustomerApplicationService
    {
        ActionResult<List<CustomerDTO>> Get();
        ActionResult<CustomerDTO> Get(int id);
        void Insert(CustomerDTO customerDTO);
        void Update(int id, CustomerDTO customerDTO);
        void Delete(int id);
    }
}
