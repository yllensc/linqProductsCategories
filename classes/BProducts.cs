using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace linqProducts.classes
{
    public class BProducts
    {
        public int CodeProduct { get; set; }
        public string? NameProduct { get; set; }
        public int Stock { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }
        public double PriceSell { get; set; }

        public double PriceBuy { get; set; }

        public int IdCategory { get; set; }

        public BProducts() { 
            if(!File.Exists(Env.FileProduct)){
                File.WriteAllText(Env.FileProduct, "");
            }
        }
        public BProducts(int code, string nameProduct, int stock, double priceSell, double priceBuy, int category)
        {
            this.CodeProduct = code;
            this.NameProduct = nameProduct;
            this.Stock = stock;
            this.PriceSell = priceSell;
            this.PriceBuy = priceBuy;
            this.IdCategory = category;
            this.StockMin = 10;
            this.StockMax = int.MaxValue;


        }

        public void AddProduct(IList<BProducts> listProducts, IList<BCategories> listCategories)
        {
            Console.WriteLine("Escoge la categoría en la que se encuentra tu producto: ");

        }


        public enum categories
        {
            lacteos = 1,
            hogar = 2,
            aseo = 3,
            gaseosas = 4,
            alcohol = 5,
            abarrotes = 6,
            carnes = 7
        }

    }


}
