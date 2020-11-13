using CustomerWebApiDDD.Application.DTO.DTO;
using CustomerWebApiDDD.Application.Interfaces;
using CustomerWebApiDDD.Domain.Core.Interfaces.Repositories;
using CustomerWebApiDDD.Infrastruture.CrossCutting.Adapter.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CustomerWebApiDDD.Application.Services
{
    public class CustomerApplicationService : ICustomerApplicationService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerMapper _customerMapper;

        public CustomerApplicationService(ICustomerRepository customerRepository, ICustomerMapper customerMapper)
        {
            _customerRepository = customerRepository;
            _customerMapper = customerMapper;
        }

        public List<CustomerDTO> Get()
        {
            var customers = _customerRepository.Get();
            return _customerMapper.ListMapperToDTO(customers);
        }

        public CustomerDTO Get(int id)
        {
            var customer = _customerRepository.Get(id);
            return _customerMapper.MapperToDTO(customer);
        }

        public CustomerDTO Insert(CustomerDTO customerDTO)
        {
            var customer = _customerMapper.MapperToEntity(customerDTO);
            var id = _customerRepository.Insert(customer);
            return Get(id);
        }

        public CustomerDTO Update(int id, CustomerDTO customerDTO)
        {
            var customer = _customerMapper.MapperToEntity(customerDTO);
            _customerRepository.Update(id, customer);
            return Get(id);
        }

        public void Delete(int id) => _customerRepository.Delete(id);
    }
}
