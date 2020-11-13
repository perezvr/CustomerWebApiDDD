using CustomerWebApiDDD.Application.DTO.DTO;
using CustomerWebApiDDD.Application.Interfaces;
using CustomerWebApiDDD.Domain.Core.Interfaces.Repositories;
using CustomerWebApiDDD.Infrastruture.CrossCutting.Adapter.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerWebApiDDD.Application.Services
{
    public class AddressApplicationSerivce : IAddressApplicationService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IAddressMapper _addresMapper;

        public AddressApplicationSerivce(IAddressRepository addressRepository, IAddressMapper addresMapper)
        {
            _addressRepository = addressRepository;
            _addresMapper = addresMapper;
        }
        
        public List<AddressDTO> Get()
        {
            var addresses = _addressRepository.Get();
            return _addresMapper.ListMapperToDTO(addresses);
        }

        public AddressDTO Get(int id)
        {
            var address = _addressRepository.Get(id);
            return _addresMapper.MapperToDTO(address);
        }

        public AddressDTO Insert(AddressDTO addressDTO)
        {
            var address = _addresMapper.MapperToEntity(addressDTO);
            var id = _addressRepository.Insert(address);
            return Get(id);
        }

        public AddressDTO Update(int id, AddressDTO addressDTO)
        {
            var address = _addresMapper.MapperToEntity(addressDTO);
            _addressRepository.Update(id, address);
            return Get(id);
        }

        public void Delete(int id) => _addressRepository.Delete(id);
    }
}
