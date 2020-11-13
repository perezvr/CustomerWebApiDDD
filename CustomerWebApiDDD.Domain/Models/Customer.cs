using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public bool Validate()
        {
            if (!ValidateCpf())
                throw new ArgumentException("Invalid CPF");

            var vContext = new ValidationContext(this);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(this, vContext, results, true))
                throw new ArgumentException(results[0].ErrorMessage);

            return true;
        }

        public bool ValidateCpf()
        {

            string valor = Cpf.Replace(".", "");

            valor = valor.Replace("-", "");

            if (valor.Length != 11)
                return false;

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(valor[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }

            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }

            else if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }
    }
}
