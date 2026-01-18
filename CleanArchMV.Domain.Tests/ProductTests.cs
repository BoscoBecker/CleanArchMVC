using CleanArchMVC.Domain.Entities;
using FluentAssertions;

namespace CleanArchMVC.Domain.Tests
{
    public class ProductTests
    {
        [Fact(DisplayName = "Create Product With Valid state")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 10, "product-image.jpg");
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }
        [Fact(DisplayName ="Create a Product With a short Name")]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 10, "product-image.jpg");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Tool short, minimium 3 characters");
        }
        [Fact(DisplayName = "Create a Product With Invalid price")]
        public void CreateProduct_NegativePriceValue_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -9.99m, 10, "product-image.jpg");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price. Price must be greater than zero");
        }
        [Theory]
        [InlineData(-10)]
        public void CreateProduct_NegativeStockValue_DomainExceptionInvalidStock(int value)
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, value, "product-image.jpg");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stockn. Stockn must be greater than zero");
        }

        [Fact(DisplayName = "Create a Product With Invalid Image")]
        public void CreateProduct_InvalidImage_DomainExceptionInvalidStock()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 10, 
                "product image1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111 " +
                "22222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222.jpg");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name. Image name too long, maximum 250 characters");
        }
        [Fact(DisplayName = "Create a Product With Invalid name.")]
        public void CreateProduct_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "", "Product Description", 9.99m, 10, "product-image.jpg");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }
    }
}
