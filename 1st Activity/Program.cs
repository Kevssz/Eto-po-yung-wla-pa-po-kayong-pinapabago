using System;
using System.Collections.Generic;
using System.Linq;

namespace MilkTeaShop
{
    class Program
    {
        static void Main(string[] args)
        {
            // Available milk tea flavors
            List<string> flavors = new List<string> { "Classic", "Taro", "Matcha", "Strawberry", "Red Velvet" };

            // Available sizes with corresponding prices
            Dictionary<string, double> sizes = new Dictionary<string, double>
            {
                { "Regular", 1.50 },
                { "Large", 2.00 }
            };

            // Available add-ons with corresponding prices
            Dictionary<string, double> addons = new Dictionary<string, double>
            {
                { "Pearls", 0.50},
                { "Jelly", 0.40},
                { "Popping Boba", 0.30},
                { "Cream Cheese", 0.20},
                { "Oreo", 0.10}
            };

            bool placeAnotherOrder = true;

            while (placeAnotherOrder)
            {
                // Display available options
                Console.WriteLine("Welcome to the Milk Tea Shop!");
                Console.WriteLine("Available Flavors:");
                for (int i = 0; i < flavors.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {flavors[i]}");
                }
                Console.WriteLine("Available Sizes:");
                foreach (var size in sizes)
                {
                    Console.WriteLine($"{size.Key}: ${size.Value}");
                }
                Console.WriteLine("Available Add-ons:");
                foreach (var addon in addons)
                {
                    Console.WriteLine($"{addon.Key}: ${addon.Value}");
                }

                // Get user inputs
                Console.Write("Enter the number corresponding to the flavor: ");
                int flavorIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                Console.Write("Enter the number corresponding to the size: ");
                int sizeIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                Console.Write("Enter the number corresponding to the add-on (0 for none): ");
                int addonIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                // Validate inputs
                if (flavorIndex < 0 || flavorIndex >= flavors.Count || sizeIndex < 0 || sizeIndex >= sizes.Count || addonIndex < -1 || addonIndex >= addons.Count)
                {
                    Console.WriteLine("Invalid selection. Please try again.");
                    continue;
                }

                string selectedFlavor = flavors[flavorIndex];
                string selectedSize = sizes.Keys.ToList()[sizeIndex];
                string selectedAddon = addonIndex == -1 ? "None" : addons.Keys.ToList()[addonIndex];

                // Calculate the price based on the selected options
                double price = sizes[selectedSize];

                // Additional price for add-ons
                if (addonIndex != -1)
                {
                    price += addons[selectedAddon];
                }

                // Display the selected options and the total price
                Console.WriteLine("\nOrder Summary:");
                Console.WriteLine("---------------");
                Console.WriteLine($"Flavor: {selectedFlavor}");
                Console.WriteLine($"Size: {selectedSize}");
                Console.WriteLine($"Add-on: {selectedAddon}");
                Console.WriteLine($"Price: ${price}");

                // Payment process (cash only)
                Console.WriteLine("\nPayment Options:");
                Console.WriteLine("Cash");

                Console.Write("Enter the amount in cash: ");
                double cashAmount = Convert.ToDouble(Console.ReadLine());

                if (cashAmount < price)
                {
                    Console.WriteLine("Insufficient cash amount. Exiting the program.");
                    return;
                }

                double change = cashAmount - price;

                Console.WriteLine($"Payment successful! Change: ${change:F2}. Your order has been placed.");

                // Ask if the user wants to place another order
                Console.Write("\nPlace another order? (yes/no) ");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() != "yes")
                {
                    placeAnotherOrder = false;
                }
            }

            Console.WriteLine("\nThank you for shopping with us!");
        }
    }
}