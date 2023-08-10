using linqProducts.classes;
using linqProducts.Views;
using Newtonsoft.Json;

internal class Program{

    //listas
    static IList<BProducts> listProducts = new List<BProducts>(){
        new BProducts() {CodeProduct = 1, NameProduct = "leche alquería", IdCategory = 1, PriceBuy = 2000, PriceSell = 3000, Stock = 20},
        new BProducts() {CodeProduct = 1, NameProduct = "leche vaquita", IdCategory = 1, PriceBuy = 2000, PriceSell = 2500, Stock = 20},
        new BProducts() {CodeProduct = 1, NameProduct = "olla super pro", IdCategory = 2, PriceBuy = 200000, PriceSell = 230000, Stock = 10},
        new BProducts() {CodeProduct = 1, NameProduct = "cepillo cool", IdCategory = 3, PriceBuy = 4000, PriceSell = 6500, Stock = 50},
        new BProducts() {CodeProduct = 1, NameProduct = "jabón de avena", IdCategory = 3, PriceBuy = 3000, PriceSell = 4500, Stock = 50},
        new BProducts() {CodeProduct = 1, NameProduct = "gaseosa de sandía", IdCategory = 4, PriceBuy = 4000, PriceSell = 5000, Stock = 200},
        new BProducts() {CodeProduct = 1, NameProduct = "smirnoff", IdCategory = 5, PriceBuy = 4000, PriceSell = 10000, Stock = 100},
        new BProducts() {CodeProduct = 1, NameProduct = "lomo de cerdo", IdCategory = 7, PriceBuy = 12000, PriceSell = 15000, Stock = 50}

    };
    static IList<BCategories> listCategories = new List<BCategories>(){
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
        Env.Products = listProducts;

        string json = JsonConvert.SerializeObject(Env.Products, Formatting.Indented);
        File.WriteAllText(Env.FileProduct, json);
        bool blContinue = true;
        int optionMain;
        do
        {
            MainMenu MainMenu = new MainMenu();
            optionMain = MainMenu.ShowMenu();
            switch (optionMain)
            {
                case 0:
                    Console.WriteLine("Hey, ojito, ingresa números.");
                    Console.ReadKey();
                    break;
                case 1:
                    Console.WriteLine("Registra tu producto.");
                    
                    break;
                case 2:
                    Console.WriteLine("Registra tu producto.");

                    break;
                case 3:
                    Console.WriteLine("Registra tu producto.");

                    break;
                case 4:
                    Console.WriteLine("Lista de categorías.");
                    categoriesMethods.ShowCategories(listCategories);

                    break;
                case 5:
                    Console.WriteLine("Registra tu producto.");

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



/**************************GROUPBY************************************/

//Product p1 = new Product( 1, "motor", 200000, 1);
//Product p2 = new Product( 2, "bobina", 50000, 1);
//Product p3 = new Product( 3, "conector", 10000, 1);
//Product p4 = new Product( 4, "aceite", 100000, 2);
//Product p5 = new Product( 5, "gas", 16000, 2);
//Product p6 = new Product( 6, "objeto misterioso", 18000, 2);
//Product p7 = new Product( 7, "freno", 18000, 3);
//Product p8 = new Product( 8, "frenillo", 300000, 3);
//Product p9 = new Product( 9, "frenito", 454000, 3);
//
//IList<Product> productList = new List<Product>() { p1, p2, p3, p4, p5, p6, p7, p8, p9 };
//		
//		var groupedResult = from p in productList
//                    group p by p.Category;
//
//		//iterate each group        
//		foreach (var intCategory in groupedResult)
//		{
//            Console.ForegroundColor = ConsoleColor.Blue;
//			Console.WriteLine("Categoría: {0}", intCategory.Key); //Group 
//			Console.ForegroundColor = ConsoleColor.DarkMagenta;
//
//			foreach(Product p in intCategory) // Collection
//				Console.WriteLine($"Producto: {p.Name} - $: {p.Value}");
//		}

/****************************JOIN**********************************/
//IList<Student> studentList = new List<Student>() {
//				new Student() { StudentID = 1, StudentName = "John", Age = 18, StandardID = 1 } ,
//				new Student() { StudentID = 2, StudentName = "Steve",  Age = 21, StandardID = 1 } ,
//				new Student() { StudentID = 3, StudentName = "Bill",  Age = 18, StandardID = 2 } ,
//				new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID = 2 } ,
//				new Student() { StudentID = 5, StudentName = "Ron" , Age = 21, StandardID = 3}
//			};
//
//IList<Standard> standardList = new List<Standard>() {
//				new Standard(){ StandardID = 1, StandardName="Standard 1"},
//				new Standard(){ StandardID = 2, StandardName="Standard 2"},
//				new Standard(){ StandardID = 3, StandardName="Standard 3"}
//			};
//
//var resultJoin = studentList.Join(
//				standardList,
//				standard => standard.StandardID,
//				student => student.StandardID,
//				(student, standar) => new
//				{
//					StudentName = student.StudentName,
//					StandarID = standar.StandardID
//				});
//foreach (var obj in resultJoin)
//		{
//			
//			Console.WriteLine("{0} - {1}", obj.StudentName, obj.StandarID);
//		}

/**************************EJERCICIO PRODUCTS************************************/

