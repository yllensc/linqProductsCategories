﻿using System.Security.Cryptography.X509Certificates;
using linqProducts.Entities
;
using linqProducts.Views;
using linqProductsCategories.Entities;
using Newtonsoft.Json;

internal class Program{

    //listas
    static List<BProducts> listProducts = new List<BProducts>(){
        new BProducts() {CodeProduct = 1, NameProduct = "leche alquería", IdCategory = 1, PriceBuy = 2000, PriceSell = 3000, Stock = 20},
        new BProducts() {CodeProduct = 2, NameProduct = "leche vaquita", IdCategory = 1, PriceBuy = 2000, PriceSell = 2500, Stock = 20},
        new BProducts() {CodeProduct = 3, NameProduct = "olla super pro", IdCategory = 2, PriceBuy = 200000, PriceSell = 230000, Stock = 10},
        new BProducts() {CodeProduct = 4, NameProduct = "cepillo cool", IdCategory = 3, PriceBuy = 4000, PriceSell = 6500, Stock = 50},
        new BProducts() {CodeProduct = 5, NameProduct = "jabón de avena", IdCategory = 3, PriceBuy = 3000, PriceSell = 4500, Stock = 50},
        new BProducts() {CodeProduct = 6, NameProduct = "gaseosa de sandía", IdCategory = 4, PriceBuy = 4000, PriceSell = 5000, Stock = 200},
        new BProducts() {CodeProduct = 7, NameProduct = "smirnoff", IdCategory = 5, PriceBuy = 4000, PriceSell = 10000, Stock = 100},
        new BProducts() {CodeProduct = 8, NameProduct = "lomo de cerdo", IdCategory = 7, PriceBuy = 12000, PriceSell = 15000, Stock = 50}

    };
    static List<BCategories> listCategories = new List<BCategories>(){
        new BCategories() {IdCategory = 1, Description = "lacteos"},
        new BCategories() {IdCategory = 2, Description = "hogar"},
        new BCategories() {IdCategory = 3, Description = "aseo"},
        new BCategories() {IdCategory = 4, Description = "gaseosas"},
        new BCategories() {IdCategory = 5, Description = "alcohol"},
        new BCategories() {IdCategory = 6, Description = "abarrotes"},
        new BCategories() {IdCategory = 7, Description = "carnes"},
    };

    

    //instancia para métodos
    static BProducts productsMethods = new BProducts();
    static BCategories categoriesMethods = new BCategories();

    public static void Main(string[] args){

        Env.StoreProducts.ListProducts.AddRange(listProducts);
        Env.StoreProducts.ListCategories.AddRange(listCategories);

        //data json todo junto
        Env.loadData(Env.FileStore);
        Env.JsonAddStoreProducts(Env.FileStore);
        bool blContinue = true;
        int optionMain;
        do
        {
            MainMenu MainMenu = new MainMenu();
            optionMain = MainMenu.ShowMenu();
            switch (optionMain)
            {
                case 0:
                    Console.WriteLine("\nHey, ojito, ingresa números.");
                    Console.ReadKey();
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n**********Registra tu producto**********");
                    Console.WriteLine("\nLista de categorías:");
                    Console.ResetColor();
                    categoriesMethods.ShowCategories(listCategories);
                    productsMethods.AddProduct(listProducts,listCategories);
                    Env.JsonAddStoreProducts(Env.FileStore);
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n**********Registra una categoría**********");
                    Console.WriteLine("\nLista de categorías:");
                    Console.ResetColor();
                    categoriesMethods.ShowCategories(listCategories);
                    categoriesMethods.AddCategory(listCategories);
                    Env.JsonAddStoreProducts(Env.FileStore);
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n**********Lista de productos**********");
                    productsMethods.ShowProducts(listProducts);
                    Console.ResetColor();
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n**********Lista de categorías**********");
                    Console.ResetColor();
                    categoriesMethods.ShowCategories(listCategories);
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n**********Inventario**********");
                    Console.ResetColor();
                    productsMethods.PrintProductGroupInfo(listProducts,listCategories);
                    break;
                case 6:
                    Console.WriteLine("Bye, bye");
                    blContinue = false;
                    break;
                default:
                    Console.WriteLine("No tenemos esa opción, sorry");
                    Console.ReadKey();
                    break;
            }
        } while (blContinue);
}
    }
