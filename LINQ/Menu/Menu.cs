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
                System.Console.WriteLine("1. Visa alla produkter");
                System.Console.WriteLine("2. Visa leverantörer med enheter på lager färre än 10");
                System.Console.WriteLine("3. Visa Pris för alla ordrar under 1 månad");
                System.Console.WriteLine("4. Delete a product");
                System.Console.WriteLine("5. Exit");
                System.Console.Write("Enter your choice: ");
                var choice = System.Console.ReadLine();
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
                        System.Environment.Exit(0);
                        break;
                    default:
                        System.Console.WriteLine("\nFelaktigt val. Försök igen");
                        ReturnToMenu();
                        break;
                }
            }
        }

        public void ReturnToMenu()
        {
            Console.WriteLine();
            System.Console.WriteLine("Press any key to return to the menu...");
            System.Console.ReadKey();
            Console.Clear();
            DisplayMenu();
        }
    }
}
