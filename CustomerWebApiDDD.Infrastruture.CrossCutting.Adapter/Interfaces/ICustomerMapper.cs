using CustomerWebApiDDD.Application.DTO.DTO;
using CustomerWebApiDDD.Domain.Models;
using System.Collections.Generic;

namespace CustomerWebApiDDD.Infrastruture.CrossCutting.Adapter.Interfaces
{
    public interface ICustomerMapper
    {
        Customer MapperToEntity(CustomerDTO customerDTO);
        List<CustomerDTO> ListMapperToDTO(List<Customer> customers);
        CustomerDTO MapperToDTO(Customer customer);
    }
}
