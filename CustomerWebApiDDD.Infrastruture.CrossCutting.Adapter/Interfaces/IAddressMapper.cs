using CustomerWebApiDDD.Application.DTO.DTO;
using CustomerWebApiDDD.Domain.Models;
using System.Collections.Generic;

namespace CustomerWebApiDDD.Infrastruture.CrossCutting.Adapter.Interfaces
{
    public interface IAddressMapper
    {
        Address MapperToEntity(AddressDTO addressDTO);
        List<AddressDTO> ListMapperToDTO(List<Address> addresses);
        AddressDTO MapperToDTO(Address address);
    }
}
