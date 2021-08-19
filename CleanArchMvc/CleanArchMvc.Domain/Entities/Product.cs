using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {

            DomainExceptionValidation.When(id < 0, "O id não pode ser negativo.");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }
        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "O nome não pode ser vazio ou nulo.");
            DomainExceptionValidation.When(name.Length < 3, "O nome não pode ter menos que 3 caracteres.");
            DomainExceptionValidation.When(name.Length > 40, "O nome não pode ter mais que 40 caracteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "A Descrição não pode ser vazio ou nulo.");
            DomainExceptionValidation.When(description.Length < 5, "A Descrição não pode ter menos que 5 caracteres.");
            DomainExceptionValidation.When(description.Length > 200, "O nome não pode ter mais que 40 caracteres.");

            DomainExceptionValidation.When(price < 0, "O Preço não pode ser menor que zero.");

            DomainExceptionValidation.When(stock < 0, "O Stock não pode ser menor que zero.");

            DomainExceptionValidation.When(image?.Length > 250, "A Image não pode ter mais que 250 caracteres.");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
        public int CategoryId { get;  set; } // Chave estrangeira
        public Category Category { get;  set; } // Um produto tem uma categoria.

    }
}
