using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact (DisplayName = "Teste válido")]
        public void CreateCategory_WithValidParameters_ResultIbjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValues_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O Id não pode ser negativo.");
        }
        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(1, "aa");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome não pode ter menos que 3 caracteres.");
        }
        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome não pode ser vazio ou nulo.");
        }
        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O nome não pode ser vazio ou nulo.");
        }


    }
}
