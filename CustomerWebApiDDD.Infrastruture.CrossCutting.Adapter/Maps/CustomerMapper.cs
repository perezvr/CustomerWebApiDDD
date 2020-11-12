using CustomerWebApiDDD.Application.DTO.DTO;
using CustomerWebApiDDD.Domain.Models;
using CustomerWebApiDDD.Infrastruture.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerWebApiDDD.Infrastruture.CrossCutting.Adapter.Maps
{
    public class CustomerMapper : ICustomerMapper
    {
        public Customer MapperToEntity(CustomerDTO customerDTO) => Customer.New(customerDTO.Name, customerDTO.Cpf, customerDTO.Birth);

        public List<CustomerDTO> ListMapperToDTO(List<Customer> customers)
        {
            List<CustomerDTO> customersDTO = new List<CustomerDTO>();

            foreach (var customer in customers)
            {
                customersDTO.Add(new CustomerDTO()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Cpf =  customer.Cpf,
                    Birth = customer.Birth,
                });
            }

            return customersDTO;
        }

        public CustomerDTO MapperToDTO(Customer customer) => new CustomerDTO() 
        {
            Id = customer.Id,
            Name = customer.Name,
            Cpf = customer.Cpf,
            Birth = customer.Birth,
        };
    }
}
