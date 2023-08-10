using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace linqProducts.classes
{
    public class Env
    {
        private static string fileProduct = "products.json";
        private static IList<BProducts> products = new List<BProducts>();
        private static string fileCategory = "category.json";
        private static IList<BCategories> categories = new List<BCategories>();

        public static string FileProduct{ get{ return fileProduct; } set{ fileProduct = value; } }
        public static IList<BProducts> Products{ get{ return products; } set{products = value; } }
        public static string FileCategory{ get{ return fileCategory; } set{ fileCategory = value; } }
        public static IList<BCategories> Categories{ get{ return categories; } set{categories = value; } }
       
    }
}