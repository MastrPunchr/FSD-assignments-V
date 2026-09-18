namespace Lab2;

class Program{

    static void Main(string[] args){
        Warrior warrior = new Warrior("Arthur");
        int initialHealth = warrior.Health;

        int length = new Random().Next(10, 21);
        int currentPosition = new Random().Next(1, length);
        int treasurePosition = (new Random().Next(1, 100) % 2 == 0) ? 0 : length;
        int previousPosition = currentPosition;
        
        int score = 0;

        Console.WriteLine("Welcome to the Adventure Game!");

        Console.WriteLine($"Length is {length}");
        while (warrior.IsAlive()){
            warrior.DisplayStats();
            Console.WriteLine($"\nYou are currently on square {currentPosition}.");
            if (currentPosition == treasurePosition){
                score += 50;
                Console.WriteLine("You've found the treasure! Congratulations!");
                break;
            }

            Console.Write("Enter 'f' to move forward, 'b' to move backward, or 'x' to exit: ");
            char move = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (move == 'f'){
                if(currentPosition < length){
                    previousPosition = currentPosition;
                    currentPosition++;
                }else{
                    Console.WriteLine("You can't move forward anymore.");
                    continue;
                }
            }else if (move == 'b'){
                if(currentPosition > 0){
                    previousPosition = currentPosition;
                    currentPosition--;
                }else{
                    Console.WriteLine("You can't move backward anymore.");
                    continue;
                }
            }else if (move == 'x'){
                Console.WriteLine("Exiting game.");
                break;
            }else{
                Console.WriteLine("Invalid input.");
                continue;
            }

            // Random chance of encountering an enemy
            if (new Random().Next(0, 2) == 1){
                Enemy enemy = new Enemy("Goblin");
                Console.WriteLine("A wild " + enemy.GetName() + " appears!");
                enemy.DisplayStats();

                while (enemy.IsAlive() && warrior.IsAlive()){
                    Console.Write("Choose an action - Attack (a) or Flee (f): ");
                    char action = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    if (action == 'a'){
                        warrior.Attack(enemy);
                        if (!enemy.IsAlive()){
                            score += 10;
                            Console.WriteLine($"{enemy.GetName()} has been defeated!");
                            break;
                        }
                        enemy.Attack(warrior);
                    }else if (action == 'f'){
                        if(new Random().Next(0, 2) == 1){
                            currentPosition = previousPosition;
                            Console.WriteLine($"You fled back to square {currentPosition}.");
                            break;
                        }
                        Console.WriteLine("You tried to flee, but it was unsuccessful.");
                        enemy.Attack(warrior);
                    }

                    if (!warrior.IsAlive()){
                        Console.WriteLine("You have been defeated!");
                    }
                }
            }else{
                if(warrior.Health < initialHealth * 0.8){
                    warrior.Heal();
                }
            }
        }
        Console.WriteLine($"Game Over - Your final score is {score}.");
    }
}