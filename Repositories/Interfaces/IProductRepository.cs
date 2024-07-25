using ConsoleAppPracticalWork_1_DependecyInjectionAndRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppPracticalWork_1_DependecyInjectionAndRepository.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void Create(Product product);

        Product Read(int id);

        void Update(Product product, int id);

        void Delete(int id);

        IEnumerable<Product> GetAll();
    }
}
