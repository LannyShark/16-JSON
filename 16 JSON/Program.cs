using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace _16._1_JSON_Create
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            string path = "Products.json";
            Product[] products = new Product[n];
            for (int i = 0; i < n; i++)
            {
                products [i] = new Product();
                Console.Write("Введите код {0} товара: ", i+1);
                products[i].Code = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите наименование {0} товара: ", i+1);
                products[i].Name = Console.ReadLine();
                Console.Write("Введите стоимость {0} товара: ", i+1);
                products[i].Cost = Convert.ToDouble(Console.ReadLine());
            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                };
                foreach (Product product in products)
                {
                    sw.WriteLine(JsonSerializer.Serialize(product, options));
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
