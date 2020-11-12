using CustomerWebApiDDD.Application.DTO.DTO;
using CustomerWebApiDDD.Domain.Models;
using CustomerWebApiDDD.Infrastruture.CrossCutting.Adapter.Interfaces;
using System.Collections.Generic;

namespace CustomerWebApiDDD.Infrastruture.CrossCutting.Adapter.Maps
{
    public class AddressMapper : IAddresMapper
    {
        public Address MapperToEntity(AddressDTO addressDTO) => Address.New(addressDTO.Street, addressDTO.Neighborhood, addressDTO.City, addressDTO.State);

        public List<AddressDTO> ListMapperToEntity(List<Address> addresses)
        {
            List<AddressDTO> addressesDTO = new List<AddressDTO>();

            foreach (var address in addresses)
            {
                addressesDTO.Add(new AddressDTO()
                {
                    Id = address.Id,
                    Street = address.Street,
                    Neighborhood = address.Neighborhood,
                    City = address.City,
                    State = address.State,
                });
            }

            return addressesDTO;
        }

        public AddressDTO MapperToDTO(Address address) => new AddressDTO()
        {
            Id = address.Id,
            Street = address.Street,
            Neighborhood = address.Neighborhood,
            City = address.City,
            State = address.State,
        };
    }
}
