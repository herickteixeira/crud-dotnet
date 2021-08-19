using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product name", "Product description", 10.9m, 39, "Product image");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_IdNegative_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product name", "Product description", 10.9m, 39, "Product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O id não pode ser negativo.");
        }
        [Fact]
        public void CreateProduct_EmptyName_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "", "Product description", 10.9m, 39, "Product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome não pode ser vazio ou nulo.");
        }
        [Fact]
        public void CreateProduct_NullName_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, null, "Product description", 10.9m, 39, "Product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome não pode ser vazio ou nulo.");
        }
        [Fact]
        public void CreateProduct_ShortName_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "aa", "Product description", 10.9m, 39, "Product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome não pode ter menos que 3 caracteres.");
        }

        [Fact]
        public void CreateProduct_LongName_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                "Product description", 10.9m, 39, "Product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome não pode ter mais que 40 caracteres.");
        }
        [Fact]
        public void CreateProduct_EmptyDescription_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product name", "", 10.9m, 39, "Product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A Descrição não pode ser vazio ou nulo.");
        }
        [Fact]
        public void CreateProduct_NullDescription_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product name", null, 10.9m, 39, "Product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A Descrição não pode ser vazio ou nulo.");
        }
        [Fact]
        public void CreateProduct_NegativePrice_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product name", "Product description", -10.9m, 39, "Product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O Preço não pode ser menor que zero.");
        }
        [Fact]
        public void CreateProduct_NegativeStock_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product name", "Product description", 10.9m, -39, "Product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O Stock não pode ser menor que zero.");
        }
        [Fact]
        public void CreateProduct_LongImage_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product name", "Product description", 10.9m, 39, "Product imageeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("A Image não pode ter mais que 250 caracteres.");
        }
        [Fact]
        public void CreateProduct_NullImage_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product name", "Product description", 10.9m, 39, null);
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact]
        public void CreateProduct_NullImage_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product name", "Product description", 10.9m, 39, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }
        [Fact]
        public void CreateProduct_EmptyImage_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product name", "Product description", 10.9m, 39, "");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
        [Theory]
        [InlineData(-5)]

        public void CreateProduct_StockInvalido_DomainExceptionInvalidId(int value)
        {
            Action action = () => new Product(1, "Product name", "Product description", 9.9m, value, "Product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O Stock não pode ser menor que zero.");
        }
    }
}
