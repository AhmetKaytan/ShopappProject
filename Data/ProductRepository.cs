using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopapp.webui.Models;

namespace shopapp.webui.Data
{
    public class ProductRepository
    {
        private static List<Product> _products = null;

        static ProductRepository()
        {
            _products = new List<Product>()
            {
                new Product{ProductId=1, Name = "Iphone 7", Price=3000, Description="iyi telefon", IsApproved = false, ImageUrl="1.jpg", CategoryId=1},
                new Product{ProductId=2, Name = "Iphone 8", Price=4000, Description="çok iyi telefon", IsApproved = true, ImageUrl="2.jpg", CategoryId=1},
                new Product{ProductId=3, Name = "Iphone X", Price=5000, Description="çok iyi telefon", IsApproved = true, ImageUrl="3.jpg", CategoryId=1},
                new Product{ProductId=4, Name = "Iphone 11", Price=6000, Description="çok iyi telefon", ImageUrl="4.jpg", CategoryId=1},
                new Product{ProductId=5, Name = "Iphone 11", Price=6000, Description="çok iyi telefon", ImageUrl="4.jpg", CategoryId=1},
                new Product{ProductId=6, Name = "Lenovo", Price=3000, Description="iyi bilgisayar", IsApproved = false, ImageUrl="1.jpg", CategoryId=2},
                new Product{ProductId=7, Name = "Lenovo", Price=4000, Description="çok iyi bilgisayar", IsApproved = true, ImageUrl="2.jpg", CategoryId=2},
                new Product{ProductId=8, Name = "Lenovo", Price=5000, Description="çok iyi bilgisayar", IsApproved = true, ImageUrl="3.jpg", CategoryId=2},
                new Product{ProductId=9, Name = "Lenovo", Price=6000, Description="çok iyi bilgisayar", ImageUrl="4.jpg", CategoryId=2}
            };
        }

        public static List<Product> Products
        {
            get
            {
                return _products;
            }
        }

        public static void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public static Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.ProductId == id);
        }

        public static void EditProduct(Product product)
        {
            foreach (var p in _products)
            {
                if (p.ProductId == product.ProductId)
                {
                    p.Name = product.Name;
                    p.Price = product.Price;
                    p.Description = product.Description;
                    p.ImageUrl = product.ImageUrl;
                    p.CategoryId = product.CategoryId;
                }
            }
        }
        public static void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}