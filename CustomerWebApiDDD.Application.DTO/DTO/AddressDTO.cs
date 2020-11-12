using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CustomerWebApiDDD.Application.DTO.DTO
{
    [DataContract]
    public class AddressDTO
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "street")]
        public string Street { get; private set; }
        [DataMember(Name = "neighborhood")]
        public string Neighborhood { get; private set; }
        [DataMember(Name = "city")]
        public string City { get; private set; }
        [DataMember(Name = "state")]
        public string State { get; private set; }
    }
}
