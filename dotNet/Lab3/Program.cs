using System;
using System.Collections.Generic;
using System.Linq;

class Program{
    static List<IItem> inventory = new List<IItem>();

    static void Main(string[] args){
        bool running = true;
        while (running){
            Console.WriteLine("\nAL2 Inventory Management");
            Console.WriteLine("1. Add item to inventory");
            Console.WriteLine("2. Display all items");
            Console.WriteLine("3. Search for items by type and category");
            Console.WriteLine("4. Use an item");
            Console.WriteLine("5. Recharge an item");
            Console.WriteLine("6. Exit");

            Console.Write("Choose an option: ");
            string input = Console.ReadLine() ?? "";

            switch (input){
                case "1":
                    AddItem();
                    break;
                case "2":
                    DisplayItems();
                    break;
                case "3":
                    SearchItems();
                    break;
                case "4":
                    UseItem();
                    break;
                case "5":
                    RechargeItem();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, please choose again.");
                    break;
            }
            
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    static void AddItem()
    {
        Console.WriteLine("Select the type of item to add:");
        Console.WriteLine("1. Artifact");
        Console.WriteLine("2. Grimoire");
        Console.WriteLine("3. Tool");
        Console.WriteLine("4. Wand");

        Console.Write("Choose an item type: ");
        string type = Console.ReadLine() ?? "";
        Console.Write("Enter the name of the item: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Enter a description for the item: ");
        string description = Console.ReadLine() ?? "";

        switch (type){
            case "1":
                inventory.Add(new Artifact(name, description));
                break;
            case "2":
                inventory.Add(new Grimoire(name, description));
                break;
            case "3":
                Console.Write("Enter the category of the tool: ");
                string category = Console.ReadLine() ?? "";
                inventory.Add(new Tool(name, description, category));
                break;
            case "4":
                Console.Write("Enter the category of the wand: ");
                string wandCategory = Console.ReadLine() ?? "";
                inventory.Add(new Wand(name, description, wandCategory));
                break;
            default:
                Console.WriteLine("Invalid item type.");
                break;
        }

        Console.WriteLine("Item added successfully.");
    }

    static void DisplayItems(){
        if (inventory.Count == 0){
            Console.WriteLine("Inventory is empty.");
            return;
        }

        Console.WriteLine("Inventory Items:");
        for (int i = 0; i < inventory.Count; i++){
            Console.Write($"{i + 1}. ");
            inventory[i].Display();
        }
    }


    static void UseItem(){
        if (inventory.Count == 0){
            Console.WriteLine("Inventory is empty.");
            return;
        }

        Console.WriteLine("Enter the index number of the item to use:");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= inventory.Count){
            IItem item = inventory[index - 1];
            if (item is IUsable usable){
                usable.Use();
            }else{
                Console.WriteLine("Selected item is not usable.");
            }
        }else{
            Console.WriteLine("Invalid index. Please enter a number from 1 to " + inventory.Count);
        }
    }

   static void RechargeItem(){
        if (inventory.Count == 0){
            Console.WriteLine("Inventory is empty.");
            return;
        }

        Console.WriteLine("Enter the index number of the magical item to recharge:");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= inventory.Count){
            IItem item = inventory[index - 1];
            if (item is IMagical magical){
                magical.Recharge();
            }else{
                Console.WriteLine("Selected item cannot be recharged or is not a magical item.");
            }
        }else{
            Console.WriteLine("Invalid index. Please enter a number from 1 to " + inventory.Count);
        }
    }

    static void SearchItems(){
        Console.WriteLine("Select the type of item to search for:");
        Console.WriteLine("1. Artifact");
        Console.WriteLine("2. Grimoire");
        Console.WriteLine("3. Tool");
        Console.WriteLine("4. Wand");

        Console.Write("Choose an item type: ");
        string type = Console.ReadLine() ?? "";

        List<IItem> filteredItems = new List<IItem>();
        string? category = null;

        switch (type){
            case "1":
                filteredItems = inventory.OfType<Artifact>().Cast<IItem>().ToList();
                break;
            case "2":
                filteredItems = inventory.OfType<Grimoire>().Cast<IItem>().ToList();
                break;
            case "3":
                filteredItems = inventory.OfType<Tool>().Cast<IItem>().ToList();
                if (filteredItems.Any()){
                    category = SelectCategory(filteredItems.OfType<ICategorizable>());
                }
                break;
            case "4":
                filteredItems = inventory.OfType<Wand>().Cast<IItem>().ToList();
                if (filteredItems.Any()){
                    category = SelectCategory(filteredItems.OfType<ICategorizable>());
                }
                break;
            default:
                Console.WriteLine("Invalid item type.");
                return;
        }
        if(category == null){
            return;
        }

        DisplayFilteredItems(filteredItems, category!);
    }

    static string? SelectCategory(IEnumerable<ICategorizable> categorizables){
        var categories = categorizables.Select(c => c.Category).Distinct().ToList();
        if (categories.Count == 0){
            Console.WriteLine("No categories available.");
            return null;
        }

        Console.WriteLine("Available categories:");
        for (int i = 0; i < categories.Count; i++){
            Console.WriteLine($"{i + 1}. {categories[i]}");
        }

        Console.Write("Select a category: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        if (choice < 1 || choice > categories.Count){
            Console.WriteLine("Invalid category selection.");
            return null;
        }

        return categories[choice - 1];
    }

    static void DisplayFilteredItems(List<IItem> items, string category){
        var categorizedItems = items;
        if (category != null){
            categorizedItems = items.OfType<ICategorizable>().Where(c => c.Category == category).Cast<IItem>().ToList();
        }

        if (categorizedItems.Count == 0){
            Console.WriteLine("No items found.");
            return;
        }

        Console.WriteLine("Filtered Items:");
        foreach (var item in categorizedItems){
            int index = inventory.IndexOf(item) + 1;  // Get the global index from the main inventory list
            Console.Write($"{index}. ");
            item.Display();
        }
    }

}
