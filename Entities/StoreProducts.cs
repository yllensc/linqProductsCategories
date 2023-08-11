using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using linqProducts.Entities;

namespace linqProductsCategories.Entities
{
    public class StoreProducts
    {
        private List<BCategories> listCategories = new List<BCategories>();
        private List<BProducts> listProducts = new List<BProducts>();

        public List<BCategories> ListCategories { get => listCategories; set => listCategories = value; }
        public List<BProducts> ListProducts { get => listProducts; set => listProducts = value; }

        public StoreProducts()
        {
        }

    

        
    }
}