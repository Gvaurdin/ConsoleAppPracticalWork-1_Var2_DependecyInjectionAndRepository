using ConsoleAppPracticalWork_1_DependecyInjectionAndRepository.Model;
using ConsoleAppPracticalWork_1_DependecyInjectionAndRepository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppPracticalWork_1_DependecyInjectionAndRepository.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly List<Product> products = new List<Product>();
        public void Create(Product product)
        {
            products.Add(product);
        }

        public void Delete(int id)
        {
            var product = Read(id);
            if (product != null)
            {
                products.Remove(product);
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public Product Read(int id)
        {
            return products.First(p => p.Id == id);
        }

        public void Update(Product product, int id)
        {
            var updateProduct = Read(id);
            if (updateProduct != null)
            {
                updateProduct.Name = product.Name;
                updateProduct.Price = product.Price;
            }
        }
    }
}
