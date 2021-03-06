﻿using System.Runtime.Serialization;

namespace CustomerWebApiDDD.Application.DTO.DTO
{
    [DataContract]
    public class AddressDTO
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "street")]
        public string Street { get; set; }
        [DataMember(Name = "neighborhood")]
        public string Neighborhood { get; set; }
        [DataMember(Name = "city")]
        public string City { get; set; }
        [DataMember(Name = "state")]
        public string State { get; set; }
    }
}
