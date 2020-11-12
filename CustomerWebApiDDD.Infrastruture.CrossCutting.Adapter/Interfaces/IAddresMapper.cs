using CustomerWebApiDDD.Application.DTO.DTO;
using CustomerWebApiDDD.Domain.Models;
using System.Collections.Generic;

namespace CustomerWebApiDDD.Infrastruture.CrossCutting.Adapter.Interfaces
{
    public interface IAddresMapper
    {
        Address MapperToEntity(AddressDTO addressDTO);
        List<AddressDTO> ListMapperToEntity(List<Address> addresses);
        AddressDTO MapperToDTO(Address address);
    }
}
