﻿using System.ComponentModel.DataAnnotations;

namespace CustomerWebApiDDD.Domain.Models
{
    public class Address : BaseModel
    {
        private Address() { }

        public static Address New(int id, string street, string neighborhood, string city, string state)
        {
            return new Address()
            {
                Id = id,
                Street = street,
                Neighborhood = neighborhood,
                City = city,
                State = state,
            };
        }

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
