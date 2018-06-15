using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var data= new Data();

            var query = from o in data.ProductDetails
                join o1 in data.Products on o.ProductId equals o1.Id into j1
                from s1 in j1.DefaultIfEmpty()
                join o2 in data.Items on o.Id equals o2.ProdetailId into j2
                select new ProductDetailForView(){ ProductDetails = o, ProductName = s1.Name,ItemsCount=j2.Count()};

            var list = query.ToList();
            foreach (var item in list)
            {
                Console.WriteLine($"id:{item.ProductDetails.Id}, Name:{item.ProductDetails.Name}, Category:{item.ProductName}, Count:{item.ItemsCount}");
            }

            Console.ReadKey();
        }
    }
}
