using ConsoleAppPracticalWork_1_DependecyInjectionAndRepository.Controller;
using ConsoleAppPracticalWork_1_DependecyInjectionAndRepository.Migrations;
using ConsoleAppPracticalWork_1_DependecyInjectionAndRepository.Model;
using ConsoleAppPracticalWork_1_DependecyInjectionAndRepository.Repositories;
using ConsoleAppPracticalWork_1_DependecyInjectionAndRepository.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleAppPracticalWork_1_DependecyInjectionAndRepository.UI
{
    public static class UserInterface
    {
        public static string GetLine()
        {
            int width = Console.WindowWidth;
            if (width < 2) width = 2;

            StringBuilder line =  new StringBuilder(width);
            line.Append('\n');

            for (int i = 1; i < width; i++)
            {
                line.Append('=');
            }

            line.Append('\n');
            return line.ToString();
        }

        public static string MenuHeader()
        {
            string menu_header = ($"{GetLine()}{"ID",-4}{"Name",-15}{"Price",-10}{GetLine()}");
            return menu_header;
        }


        public static void Menu()
        {
            List<string> list = new List<string>
            {
                "Create product",
                "Read product",
                "Update product",
                "Delete product"     
            };

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IProductRepository, ProductRepositoryDB>()
                .AddSingleton<ProductController>()
                .BuildServiceProvider();

            var productController = serviceProvider.GetService<ProductController>();

            int selected_item_index = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\tData base Device Shop\n\t\t Click escape if you need to exit the program\n" +
                    " Select action :");
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == selected_item_index)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine($"  {list[i]}");
                }
                Console.BackgroundColor = ConsoleColor.Black;

                Console.WriteLine(GetLine());

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selected_item_index > 0)
                        {
                            selected_item_index--;
                        }
                        else selected_item_index = list.Count;
                        break;

                    case ConsoleKey.DownArrow:
                        if (selected_item_index < list.Count)
                        {
                            selected_item_index++;
                        }
                        if (selected_item_index == list.Count)
                        {
                            selected_item_index = 0;
                        }
                        break;
                    case ConsoleKey.Escape:
                        {
                            Environment.Exit(0);
                        }
                        break;

                    case ConsoleKey.Enter:
                        {
                          switch(selected_item_index)
                            {
                                case 0:
                                    {
                                        double price = 0;
                                        Console.Write("Enter to name product : ");
                                        string? inputName = Console.ReadLine();
                                        if (inputName.Length < 2)
                                        {
                                            Console.WriteLine("Incorrect name was entered");
                                            return;
                                        }
                                        Console.Write("Enter to price of product : ");
                                        string? inputPrice = Console.ReadLine();
                                        if (double.TryParse(inputPrice, out price) && price > 0 || price < 100)
                                        {
                                            Product product = new Product()
                                            {
                                                Name = inputName,
                                                Price = price,
                                            };
                                            productController.CreateProduct(product);
                                            Console.WriteLine("Product suceffull created");
                                            Thread.Sleep(1000);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error input price count");
                                            Thread.Sleep(1000);
                                            break;
                                        }

                                    }
                                    break;
                                case 1:
                                    {
                                        if (productController.GetProducts().ToList() != null)
                                        {
                                            List<Product> products = productController.GetProducts().ToList();
                                            Console.WriteLine(MenuHeader());
                                            for (global::System.Int32 i = 0; i < products.Count; i++)
                                            {
                                                Console.WriteLine($"{products[i].Id,-4}{products[i].Name,-15}{products[i].Price,-10}\n");
                                            }
                                            Console.ReadKey();
                                        }
                                        else break;
                                    }
                                    break;
                                case 2:
                                    {
                                        Console.Write("Enter to id of product : ");
                                        string input = Console.ReadLine();
                                        int id = 0;
                                        if (int.TryParse(input, out id) && id > 0 || id < 100)
                                        {
                                            if (productController.GetProducts().ToList() != null)
                                            {
                                                List<Product> products = productController.GetProducts().ToList();

                                                if (products.Any(p => p.Id == id))
                                                {
                                                    double price = 0;
                                                    Console.Write("Enter to name product : ");
                                                    string? inputName = Console.ReadLine();
                                                    if (inputName.Length < 2)
                                                    {
                                                        Console.WriteLine("Incorrect name was entered");
                                                        Thread.Sleep(1000);
                                                        break;
                                                    }
                                                    Console.Write("Enter to price of product : ");
                                                    string? inputPrice = Console.ReadLine();
                                                    if (double.TryParse(inputPrice, out price) && price > 0 || price < 100)
                                                    {
                                                        Product product = new Product()
                                                        {
                                                            Name = inputName,
                                                            Price = price,
                                                        };
                                                        productController.UpdateProduct(product,id);
                                                        Console.WriteLine("Product succeffull updated");
                                                        Thread.Sleep(1000);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Error input price count");
                                                        Thread.Sleep(1000);
                                                        break;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Product not found");
                                                    Thread.Sleep(1000);
                                                    break;
                                                }
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("Error input number count");
                                            Thread.Sleep(1000);
                                            break;
                                        }
                                    }
                                    break;
                                case 3:
                                    {
                                        Console.Write("Enter to id of product : ");
                                        string input = Console.ReadLine();
                                        int id = 0;
                                        if (int.TryParse(input, out id) && id > 0 || id < 100)
                                        {
                                            if (productController.GetProducts().ToList() != null)
                                            {
                                                List<Product> products = productController.GetProducts().ToList();

                                                if (products.Any(p => p.Id == id))
                                                {
                                                    productController.DeleteProduct(id);
                                                    Console.WriteLine("Product succeffull deleted");
                                                    Thread.Sleep(1000);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Product not found");
                                                    Thread.Sleep(1000);
                                                    break;
                                                }
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("Error input number count");
                                            Thread.Sleep(1000);
                                            break;
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                }
                Console.BackgroundColor = ConsoleColor.Black;
            }

        }
    }
}
