using CleanArchMVC.Domain.Validation;
namespace CleanArchMVC.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; } 
        public string Image { get; private set; }

        public Product(string name, string description, decimal price, int stock, string image) => ValidateDomain(name, description, price, stock, image);
        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id. Id must be greater than zero");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }
        public void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name. Tool short, minimium 3 characters");
            DomainExceptionValidation.When(description.Length < 5,  "Invalid description. Description is required");
            DomainExceptionValidation.When(price < 0, "Invalid price. Price must be greater than zero");  
            DomainExceptionValidation.When(stock < 0, "Invalid stockn. Stockn must be greater than zero");
            DomainExceptionValidation.When(image?.Length > 250, "Invalid image name. Image name too long, maximum 250 characters"); 

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
        public void Update(string name, string description, decimal price, int stock, string image, int categotyId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categotyId;
        }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
