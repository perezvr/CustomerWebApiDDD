using CustomerWebApiDDD.Application.DTO.DTO;
using System.Collections.Generic;

namespace CustomerWebApiDDD.Application.Interfaces
{
    public interface IAddressApplicationService
    {
        List<AddressDTO> Get();
        AddressDTO Get(int id);
        AddressDTO Insert(AddressDTO addressDTO);
        AddressDTO Update(int id, AddressDTO addressDTO);
        void Delete(int id);
    }
}
