using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        public int CategorytId { get; set; }
        public Category Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);            
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(name.Length < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categorytId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategorytId = categorytId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name. name is too short, at leat 3 characters are needed");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description. Description is required");

            DomainExceptionValidation.When(description.Length < 5, "Invalid description. Description is too short, at leat 5 characters are needed");

            DomainExceptionValidation.When(price < 0, "Invalid price value");

            DomainExceptionValidation.When(stock < 0, "Invalid stock amount");

            DomainExceptionValidation.When(string.IsNullOrEmpty(image), "Invalid image. Image is required");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
    }
}
