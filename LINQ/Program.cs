using ECommerceApp.Models;
using ECommerceApp.DataAccess;
using ECommerceApp.Menu;

namespace ECommerceApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the ECommerceContext class
            // to establish a connection to the database
            using var context = new ECommerceContext();
            // Create an instance of the ProductDataAccess class
            // and pass the context object to the constructor
            var productDataAccess = new ProductDataAccess(context);
            // Create an instance of the Menu class
            // and pass the productDataAccess object to the constructor
            var menu = new Menu.Menu(productDataAccess);
            // Call the DisplayMenu method to display the menu
            menu.DisplayMenu();
        }
    }
}
