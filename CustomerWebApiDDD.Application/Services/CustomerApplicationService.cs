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

        public void Insert(CustomerDTO customerDTO)
        {
            var customer = _customerMapper.MapperToEntity(customerDTO);
            _customerRepository.Insert(customer);
        }

        public void Update(int id, CustomerDTO customerDTO)
        {
            var customer = _customerMapper.MapperToEntity(customerDTO);
            _customerRepository.Update(id, customer);
        }

        public void Delete(int id) => _customerRepository.Delete(id);
    }
}
