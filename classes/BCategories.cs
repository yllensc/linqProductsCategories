using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace linqProducts.classes
{
    public class BCategories
    {
        public int IdCategory { get; set; }
        public string ? Description { get; set; }

        public BCategories(){}

        public BCategories(int id, string description){
            this.IdCategory = id;
            this.Description = description;
        }

        public void ShowCategories(IList<BCategories> listCategories){
            if(listCategories.Count>0){
                Console.WriteLine("\n{0,-10}{1,30}", "ID", "Descripción");
            foreach (var category in listCategories){
                Console.WriteLine("{0,-10}{1,30}", category.IdCategory, category.Description);
            }
                
            }
            else{
                Console.WriteLine("SOrry, no tenemos categorías aún");
            }
            Console.ReadKey();

        }

        public void AddCategory(IList<BCategories> listCategories)
    {
        try{
        Console.Write("Ingrese el ID de la categoría: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Ingrese la descripción de la categoría: ");
        string ? description = Console.ReadLine();

        if (listCategories.Any(category => category.IdCategory == id || category.Description == description))
        {
            Console.WriteLine("Ya existe una categoría con el mismo ID o descripción.");
        }
        else
        {
            listCategories.Add(new BCategories(id, description));
            Console.WriteLine("Categoría agregada exitosamente.");
        }
        }
        catch(Exception ex){
            Console.WriteLine(ex.Message);
        }
    }
        
    }

    
}