using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace _16._2_JSON_Read
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            string path = "Products.json";
            Product[] products = new Product[n];
            double max = 0;
            using (StreamReader sr = new StreamReader(path))
            {
                for (int i = 0; i < n; i++)
                {
                    products[i] = JsonSerializer.Deserialize<Product>(sr.ReadLine());
                    if (products[i].Cost > max)
                    {
                        max = products[i].Cost;
                    }
                }
            }
            Console.Write("Самый дорогой товар: ");
            foreach (Product product in products)
            {
                if (product.Cost==max)
                {
                    Console.Write("{0} ", product.Name);
                }
            }
            Console.ReadKey();
        }
    }
    public class Product
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
    }
}
