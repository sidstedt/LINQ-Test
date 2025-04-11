using ECommerceApp.DataAccess;

namespace ECommerceApp.Menu
{
    public class Menu
    {
        private readonly ProductDataAccess _productDataAccess;

        public Menu(ProductDataAccess productDataAccess)
        {
            _productDataAccess = productDataAccess;
        }

        public void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Visa alla produkter i Electronics");
                Console.WriteLine("2. Visa leverantörer med enheter på lager färre än 10");
                Console.WriteLine("3. Visa Pris för alla ordrar under 1 månad");
                Console.WriteLine("4. Visa dom tre mest sålda produkerna och antal");
                Console.WriteLine("5. Visa produkter baserat på dess kategori");
                Console.WriteLine("6. Visa alla ordrar med ett pelopp större än 1000");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        _productDataAccess.ListAllProducts();
                        ReturnToMenu();
                        break;
                    case "2":
                        _productDataAccess.ListSuppliersWithLowStock();
                        ReturnToMenu();
                        break;
                    case "3":
                        _productDataAccess.CalculateAllOrderValue();
                        ReturnToMenu();
                        break;
                    case "4":
                        _productDataAccess.ThreeMostSoldProducts();
                        ReturnToMenu();
                        break;
                    case "5":
                        _productDataAccess.ListProductsInCategory();
                        ReturnToMenu();
                        break;
                    case "6":
                        _productDataAccess.GetAllOrders();
                        ReturnToMenu();
                        break;
                    case "7":
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nFelaktigt val. Försök igen");
                        ReturnToMenu();
                        break;
                }
            }
        }

        public void ReturnToMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
            Console.Clear();
            DisplayMenu();
        }
    }
}
