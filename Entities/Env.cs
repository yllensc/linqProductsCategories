using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using linqProductsCategories.Entities;
using Newtonsoft.Json;

namespace linqProducts.Entities
{
    public static class Env
    {
        private static string fileStore = "tiendaCampus.json";
        private static StoreProducts storeProducts = new StoreProducts();
        //json con todo dentro:
        public static string FileStore{ get{ return fileStore; } set{ fileStore = value; } }
        public static StoreProducts StoreProducts{ get{ return storeProducts; } set{ storeProducts = value; } }

    public static void loadData<T>(string nameFile, List<T> list){
        if (!File.Exists(nameFile))
        {
            list = new List<T>();
            return;
        }

        using (StreamReader reader = new StreamReader(nameFile)){
            string json = reader.ReadToEnd();
            if (string.IsNullOrWhiteSpace(json))
            {
                list = new List<T>();
                return;
            }
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true  };
            list = System.Text.Json.JsonSerializer.Deserialize<List<T>>(json, options) ?? new List<T>();
        }
    }

    public static void loadData(string nameFile){
        if (!File.Exists(nameFile))
        {
            new StoreProducts();
            return;
        }

        using (StreamReader reader = new StreamReader(nameFile)){
            string json = reader.ReadToEnd();
            if (string.IsNullOrWhiteSpace(json))
            {
                new StoreProducts();
                return;
            }
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            Env.StoreProducts = System.Text.Json.JsonSerializer.Deserialize<StoreProducts>(json, options) ?? new StoreProducts();
        }
    }

    public static void JsonAddStoreProducts(string fileName){
    string jsonFile = JsonConvert.SerializeObject(Env.StoreProducts, Formatting.Indented);
    File.WriteAllText(fileName, jsonFile);
    }

    public static void JsonAdd<T>(List<T> list, string fileName){
    string jsonFile = JsonConvert.SerializeObject(list, Formatting.Indented);
    File.WriteAllText(fileName, jsonFile);

}
       
    }
}