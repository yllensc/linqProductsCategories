using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace linqProducts.Entities
{
    public class BCategories
    {
        public int IdCategory { get; set; }
        public string? Description { get; set; }

        public BCategories() { }

        public BCategories(int id, string description)
        {
            this.IdCategory = id;
            this.Description = description;
        }

        //metodo interno para imprimir bonito las categorías :3

        public void ShowCategories(IList<BCategories> listCategories)
        {
            if (listCategories.Count > 0)
            {
                Console.WriteLine("\n{0,-10}{1,40}", "ID", "Descripción");

                var formattedCategories = listCategories
                    .Select(category => $"{category.IdCategory,-10}{category.Description,40}");

                foreach (var formattedCategory in formattedCategories)
                {
                    Console.WriteLine(formattedCategory);
                }
            }
            else
            {
                Console.WriteLine("Sorry, no tenemos categorías aún");
            }

            Console.ReadKey();
        }

        public void AddCategory(IList<BCategories> listCategories)
        {
            try
            {
                Console.Write("Ingrese el ID de la categoría: ");
                int id = int.Parse(Console.ReadLine() ?? string.Empty);

                Console.Write("Ingrese la descripción de la categoría: ");
                string description = Console.ReadLine() ?? string.Empty;

                if (listCategories.Any(category => category.IdCategory == id || category.Description == description))
                {
                    Console.WriteLine("Ya existe una categoría con el mismo ID o descripción.");
                }
                else
                {
                    BCategories categoryNew = new BCategories(id, description);
                    listCategories.Add(categoryNew);
                    Env.StoreProducts.ListCategories.Add(categoryNew);
                    Console.WriteLine("Categoría agregada exitosamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}