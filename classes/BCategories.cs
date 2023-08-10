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
                Console.WriteLine("\nID\t\tDescripción");
            foreach (var category in listCategories){
                Console.WriteLine("{0,-10}{1,30}", category.IdCategory, category.Description);
            }
                
            }
            else{
                Console.WriteLine("SOrry, no tenemos categorías aún");
            }
            Console.ReadKey();

        }
        
    }

    
}