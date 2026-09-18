using System;
using System.Collections.Generic;
namespace PotionLab;
class Program
{
    static List<Potion> potionInventory = new List<Potion>();

    static Dictionary<int, string> potionTypes = new Dictionary<int, string>{
            { 1, "Healing" },
            { 2, "Poison" },
            { 3, "Invisibility" }
        };

    static Dictionary<int, string> potencyLevels = new Dictionary<int, string>{
            { 1, "Low" },
            { 2, "Medium" },
            { 3, "High" }
        };

    static void Main(string[] args){
        bool isRunning = true;
        Console.WriteLine("Welcome to Alchemy Shelf!\n");

        while (isRunning){
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Create a Potion");
            Console.WriteLine("2. View Inventory");
            Console.WriteLine("3. Use a Potion");
            Console.WriteLine("4. Exit");

            string option = Console.ReadLine();

            switch (option){
                case "1":
                    CreatePotion();
                    break;
                case "2":
                    ViewInventory();
                    break;
                case "3":
                    UsePotion();
                    break;
                case "4":
                    Console.WriteLine("Exiting...");
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    static void CreatePotion(){
        Console.WriteLine("Select potion type:");
        foreach (var t in potionTypes){
            Console.WriteLine($"{t.Key}. {t.Value}");
        }
        int typeChoice = int.Parse(Console.ReadLine());
        if(!potionTypes.ContainsKey(typeChoice)){
            Console.WriteLine("Invalid potion type.");
            return;
        }
        string type = potionTypes[typeChoice];

        Console.WriteLine("Select potency level:");
        foreach (var level in potencyLevels){
            Console.WriteLine($"{level.Key}. {level.Value}");
        }
        int potencyChoice = int.Parse(Console.ReadLine());
        if(!potencyLevels.ContainsKey(potencyChoice)){
            Console.WriteLine("Invalid potency level.");
            return;
        }
        string potency = potencyLevels[potencyChoice];

        Potion potion = new Potion(type, potency);
        potionInventory.Add(potion);
        Console.WriteLine("Potion created successfully!");
    }


    static void ViewInventory(){
        if (potionInventory.Count == 0){
            Console.WriteLine("No potions in inventory.");
            return;
        }

        Console.WriteLine("Potion Inventory:");
        foreach (var potion in potionInventory){
            Console.WriteLine(potion.DescribePotion());
        }
        Console.WriteLine($"Total potions created: {Potion.GetTotalPotions()}");
    }

    static void UsePotion(){
        if (potionInventory.Count == 0){
            Console.WriteLine("No potions to use.");
            return;
        }

        Console.WriteLine("Enter the ID of the potion to use:");
        int id = int.Parse(Console.ReadLine());

        Potion potion = potionInventory.Find(p => p.GetPotionId() == id);
        if (potion != null){
            Console.WriteLine(potion.UsePotion());
            potionInventory.Remove(potion);
            Console.WriteLine("Potion used and removed from inventory.");
        }else{
            Console.WriteLine("Potion not found.");
        }
    }
}
