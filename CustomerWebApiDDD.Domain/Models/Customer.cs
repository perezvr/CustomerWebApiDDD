using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CustomerWebApiDDD.Domain.Models
{
    public class Customer : BaseModel
    {
        private Customer() { }

        public static Customer New(int id, string name, string cpf, DateTime birth)
        {
            return new Customer()
            {
                Id = id,
                Name = name,
                Cpf = cpf,
                Birth = birth,
            };
        }

        public static Customer New(string name, string cpf, DateTime birth)
        {
            return new Customer()
            {
                Name = name,
                Cpf = cpf,
                Birth = birth,
            };
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; private set; }
        [Required]
        public string Cpf { get; private set; }
        [Required]
        public DateTime Birth { get; private set; }
    }
}
