

using ConsoleAppPracticalWork_1_DependecyInjectionAndRepository.Controller;
using ConsoleAppPracticalWork_1_DependecyInjectionAndRepository.Model;
using ConsoleAppPracticalWork_1_DependecyInjectionAndRepository.Repositories.Interfaces;
using ConsoleAppPracticalWork_1_DependecyInjectionAndRepository.Repositories;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IProductRepository, ProductRepository>()
    .AddSingleton<ProductController>()
    .BuildServiceProvider();


var productController = serviceProvider.GetService<ProductController>();

var newProduct = new Product { Id = 1, Name = "Laptop", Price = 1999.99 };
productController.CreateProduct(newProduct);


var product = productController.GetProduct(1);
Console.WriteLine($"Product:{product.Name} \nPrice:{product.Price}");

Product prod = new Product()
{
    Name = "Iphone",
    Price = 900
};
productController.UpdateProduct(prod, 1);
Console.WriteLine($"Product:{product.Name} \nPrice:{product.Price}");
