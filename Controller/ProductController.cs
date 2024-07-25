using ConsoleAppPracticalWork_1_DependecyInjectionAndRepository.Model;
using ConsoleAppPracticalWork_1_DependecyInjectionAndRepository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppPracticalWork_1_DependecyInjectionAndRepository.Controller
{
    public class ProductController
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        public void CreateProduct(Product product)
        {
            productRepository.Create(product);
        }

        public Product GetProduct(int id)
        {
            return productRepository.Read(id);
        }

        public void DeleteProduct(int id)
        {
            productRepository.Delete(id);
        }

        public void UpdateProduct(Product product, int id)
        {
            productRepository.Update(product, id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return productRepository.GetAll();
        }
    }
}
