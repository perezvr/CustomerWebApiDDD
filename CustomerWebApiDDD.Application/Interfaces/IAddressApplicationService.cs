using CustomerWebApiDDD.Application.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

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
