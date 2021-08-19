using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : EntityBase
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "O Id não pode ser negativo.");
            Id = id;

            ValidateDomain(name);            
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }
        public ICollection<Product> Products { get; set; } // Uma categoria pode ter vários produtos.

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "O nome não pode ser vazio ou nulo.");

            DomainExceptionValidation.When(name.Length < 3, "O nome não pode ter menos que 3 caracteres.");            

            Name = name;
        }
    }
}
