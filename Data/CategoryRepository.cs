using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopapp.webui.Models;

namespace shopapp.webui.Data
{
    public static class CategoryRepository
    {
        private static List<Category> _categories = null;

        static CategoryRepository()
        {
            _categories = new List<Category>()
            {
                new Category{CategoryId=1, Name = "Telefon", Description="Telefon Kategorisi"},
                new Category{CategoryId=2, Name = "Bilgisayar", Description="Bilgisayar Kategorisi"},
                new Category{CategoryId=3, Name = "Elektronik", Description="Elektronik Kategorisi"},
                new Category{CategoryId=4, Name = "Kitap", Description="Kitap Kategorisi"}
            };
        }

        public static List<Category> Categories
        {
            get { return _categories; }
        }

        public static void AddCategory(Category category)
        {
            _categories.Add(category);
        }

        public static Category GetCategoryById(int id)
        {
            return _categories.FirstOrDefault(c => c.CategoryId == id);
        }
    }
}