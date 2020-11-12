using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CustomerWebApiDDD.Application.DTO.DTO
{
    [DataContract]
    public class CustomerDTO
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "cpf")]
        public string Cpf { get; set; }

        [DataMember(Name = "birth")]
        public DateTime Birth { get; set; }
    }
}
