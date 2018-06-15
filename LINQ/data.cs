using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace LINQ
{
    public class ProductDetailForView
    {
        public ProductDetail ProductDetails { get; set; }
        public string ProductName { get; set; }
        public int ItemsCount { get; set; }
    }

    public class Product
    {
        private static int _idCounter = 0;
        public int Id { get; private set; }
        public string Name { get; set; }

        public Product()
        {
            Id = ++_idCounter;
        }
    }

    public class ProductDetail
    {
        private static int _idCounter = 0;
        public int Id { get; private set; }
        public string Name { get; set; }
        public int ProductId { get; set; }

        public ProductDetail()
        {
            Id = ++_idCounter;
        }
    }

    public class Item
    {
        private static int _idCounter = 0;
        public int Id { get; private set; }
        public string Name { get; set; }
        public int ProdetailId { get; set; }

        public Item()
        {
            Id = ++_idCounter;
        }

    }

    public class Data
    {
        public List<Product> Products { get; set; }
        public List<ProductDetail> ProductDetails { get; set; }
        public List<Item> Items { get; set; }

        public Data()
        {
            Products = new List<Product>()
            {
                new Product(){Name= "Drink"},
                new Product(){Name = "Food"},
                new Product(){Name = "Toy"},
                new Product(){Name = "Game"}
            };

            ProductDetails = new List<ProductDetail>()
            {
                new ProductDetail(){Name = "SofeDrink",ProductId = 1},
                new ProductDetail(){Name = "Alcoholic",ProductId = 1},
                new ProductDetail(){Name = "Meat",ProductId = 2},
                new ProductDetail(){Name="Vegetables", ProductId = 2},
                new ProductDetail(){Name = "Moddel", ProductId = 3},
                new ProductDetail(){Name = "Online", ProductId = 4},
                new ProductDetail(){Name = "Console", ProductId = 4}
            };
            Items = new List<Item>()
            {
                new Item(){Name = "Cola", ProdetailId = 1},
                new Item(){Name = "Sprite", ProdetailId = 1},
                new Item(){Name = "MountainDew" , ProdetailId = 1},
                new Item(){Name="Beer", ProdetailId = 2},
                new Item(){Name = "VodKa", ProdetailId = 2},
                new Item(){Name = "CockTail", ProdetailId = 2},
                new Item(){Name = "Chicken", ProdetailId = 3},
                new Item(){Name= "Beef", ProdetailId = 3},
                new Item(){Name= "Mushroom", ProdetailId = 4},
                new Item(){Name = "Cabbage", ProdetailId = 4},
                new Item(){Name = "Peanut", ProdetailId = 4},
                new Item(){Name = "Car", ProdetailId = 5},
                new Item(){Name= "Plane", ProdetailId = 5},
                new Item(){Name = "Dota2", ProdetailId = 6},
                new Item(){Name="LOL", ProdetailId = 6},
                new Item(){Name="SuperMario", ProdetailId = 7},
                new Item(){Name="GTA5", ProdetailId = 7}
            };
        }

    }

    
}