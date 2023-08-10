using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace linqProducts.Views
{
    public class MainMenu
    {
        public MainMenu(){

        }

        public int  ShowMenu(){
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nGESTIÓN DE PRODUCTOS \n\n");
            Console.WriteLine("1. Registrar producto");
            Console.WriteLine("2. Registrar categoría");
            Console.WriteLine("3. Listar productos");
            Console.WriteLine("4. Listar categorías");
            Console.WriteLine("5. Costo total del inventario");
            Console.WriteLine("6. Salir\n\n");
            Console.WriteLine("******************************");
            Console.Write("Elija una Opción: ");
            Console.ResetColor();
            if (int.TryParse(Console.ReadLine(), out int option))
            {
                return option;
            }
            else{
                option = 0;
                return option;
            }
        }
    }
}