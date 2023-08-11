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

        public BProducts()
        {
            if (!File.Exists(Env.FileProduct))
            {
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

        public void ShowProducts(IList<BProducts> listProducts)
        {
            if (listProducts.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nID\t\tNombre\t\tStock");
                Console.ResetColor();
                foreach (var product in listProducts)
                {
                    Console.WriteLine("{0}\t\t{1}\t\t{2}", product.CodeProduct, product.NameProduct, product.Stock);
                }

            }
            else
            {
                Console.WriteLine("SOrry, no tenemos productos aún");
            }
            Console.ReadKey();

        }

        public void AddProduct(IList<BProducts> listProducts, IList<BCategories> listCategories)
        {
            Console.WriteLine("Escoge la categoría en la que se encuentra tu producto: ");
            int selectedCategoryId;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out selectedCategoryId) ||
                    !listCategories.Any(category => category.IdCategory == selectedCategoryId))
                {
                    Console.WriteLine("Selecciona una categoría válida.");
                }
                else
                {
                    break;
                }
            } while (true);
            try{

            Console.Write("Ingresa el código del producto: ");
            int code = int.Parse(Console.ReadLine());

            Console.Write("Ingresa el nombre del producto: ");
            string nameProduct = Console.ReadLine();

            Console.Write("Ingresa el stock del producto: ");
            int stock = int.Parse(Console.ReadLine());

            Console.Write("Ingresa el precio de venta del producto: ");
            double priceSell = double.Parse(Console.ReadLine());

            Console.Write("Ingresa el precio de compra del producto: ");
            double priceBuy = double.Parse(Console.ReadLine());

            listProducts.Add(new BProducts(code, nameProduct, stock, priceSell, priceBuy, selectedCategoryId));

            Console.WriteLine("Producto agregado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void PrintProductGroupInfo(IList<BProducts> listProducts, IList<BCategories> listCategories)
        {
            var groupedProducts = from product in listProducts
                                  join category in listCategories on product.IdCategory equals category.IdCategory
                                  group product by product.IdCategory into grouped
                                  select new
                                  {
                                      CategoryId = grouped.Key,
                                      CategoryDescription = listCategories.Single(c => c.IdCategory == grouped.Key).Description,
                                      Products = grouped.ToList()
                                  };

            foreach (var group in groupedProducts)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"Categoría: {group.CategoryDescription} (ID: {group.CategoryId})");
                Console.ResetColor();
                if(group.Products.Count > 0){
                    Console.WriteLine("\n{0,-30}{1,-10}{2,-20}{3,-20}{4,-25}{5,-25}","Producto","Stock", "$ compra", "$ venta", "$ total compra", " $ total venta");
                foreach (var product in group.Products)
                {
                    double totalBuyPrice = product.PriceBuy * product.Stock;
                    double totalSellPrice = product.PriceSell * product.Stock;

                    Console.WriteLine("{0,-30}{1,-10}{2,-20}{3,-20}{4,-25}{5,-25}",product.NameProduct,product.Stock,product.PriceBuy,product.PriceSell,totalBuyPrice,totalSellPrice);
                }

                Console.WriteLine();
                }
            }

            double grandTotalBuyPrice = groupedProducts.SelectMany(group => group.Products).Sum(product => product.PriceBuy * product.Stock);
            double grandTotalSellPrice = groupedProducts.SelectMany(group => group.Products).Sum(product => product.PriceSell * product.Stock);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Total general de compra: {grandTotalBuyPrice:C}");
            Console.WriteLine($"Total general de venta: {grandTotalSellPrice:C}");
            Console.ResetColor();
            Console.ReadKey();
        }
    }

}


