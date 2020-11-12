using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CustomerWebApiDDD.Domain.Models
{
    public class Address : BaseModel
    {
        private Address() { }
        public static Address New(string street, string neighborhood, string city, string state)
        {
            return new Address()
            {
                Street = street,
                Neighborhood = neighborhood,
                City = city,
                State = state,
            };
        }

        [Required]
        [MaxLength(50)]
        public string Street { get; private set; }
        [Required]
        [MaxLength(40)]
        public string Neighborhood { get; private set; }
        [Required]
        [MaxLength(40)]
        public string City { get; private set; }
        [Required]
        [MaxLength(40)]
        public string State { get; private set; }
    }
}
