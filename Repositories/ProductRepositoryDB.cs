using ConsoleAppPracticalWork_1_DependecyInjectionAndRepository.Data;
using ConsoleAppPracticalWork_1_DependecyInjectionAndRepository.Model;
using ConsoleAppPracticalWork_1_DependecyInjectionAndRepository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppPracticalWork_1_DependecyInjectionAndRepository.Repositories
{
    public class ProductRepositoryDB : IProductRepository
    {
        public void Create(Product product)
        {
            using var context = new ProductContext();
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            using var context = new ProductContext();
            var product = context.Products.First(p => p.Id == id);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using var context = new ProductContext();
            return context.Products.ToList();
        }

        public Product Read(int id)
        {
            using var context = new ProductContext();
            return context.Products.First(x => x.Id == id);
        }

        public void Update(Product product, int id)
        {
            using var context = new ProductContext();
            var updateProduct = context.Products.First(P => P.Id == id);
            if (updateProduct != null)
            {
                updateProduct.Name = product.Name;
                updateProduct.Price = product.Price;
                context.SaveChanges();
            }

        }
    }
}
