using CustomerWebApiDDD.Application.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerWebApiDDD.Application.Interfaces
{
    public interface IAddressApplicationService
    {
        ActionResult<List<AddressDTO>> Get();
        ActionResult<AddressDTO> Get(int id);
        void Insert(AddressDTO addressDTO);
        void Update(int id, AddressDTO addressDTO);
        void Delete(int id);
    }
}
