using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace linqProducts.classes
{
    public class Env
    {
        private static string fileProduct = "products.json";
        private static string fileCategory = "category.json";

        public static string FileProduct{ get{ return fileProduct; } set{ fileProduct = value; } }
        public static string FileCategory{ get{ return fileCategory; } set{ fileCategory = value; } }

        public Env(){}
public void loadData<T>(string nameFile, List<T> list){
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
        list = System.Text.Json.JsonSerializer.Deserialize<List<T>>(json, new JsonSerializerOptions(){
            PropertyNameCaseInsensitive = true
        }) ?? new List<T>();
    }
}

       
    }
}