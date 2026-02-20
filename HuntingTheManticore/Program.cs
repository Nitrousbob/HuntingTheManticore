namespace HuntingTheManticore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int currentMin = 0;
            int currentMax = 100;
            Console.Title = "Hunting the Manticore";
            Console.WriteLine("Welcome to Hunting the Manticore!");
            int range = AskForANumber("How far away from the city do you want to station the Manticore? (1-100)");
            Console.Clear();
            int round = 0;
            int cityHealth = 15;
            int cityTotalHealth = 15;
            int manticoreHealth = 10;
            int manticoreTotalHealth = 10;
            

            while (manticoreHealth > 0 && cityHealth > 0)
            {
                round++;               
                DisplayStatus(round, cityHealth, cityTotalHealth, manticoreHealth, manticoreTotalHealth);
                int cDamage = CannonDamage(round);
                int shotRange = AskForANumber($"Enter the desired cannon range ({currentMin}-{currentMax})");
                if (CheckShot(range, shotRange))
                {
                    manticoreHealth -= cDamage;
                    if (manticoreHealth > 0)
                    {
                        cityHealth -= 1;
                    }
                    
                }
                else
                {
                       cityHealth -= 1;
                }
            }
            if (manticoreHealth <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
                Console.ResetColor();
                
            }
            else if (cityHealth <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The city of Consolas has been destroyed! The Manticore has won!");
                Console.ResetColor();
            }



            void DisplayStatus(int round, int cHealth, int cTHealth, int mHealth, int mTHealth)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                for (int i = 0; i < 40; i++)
                {
                    Console.Write("-");
                }
                Console.ResetColor();
                Console.WriteLine($"\nStatus: Round {round}  City: {cHealth}/{cTHealth}  Manticore: {mHealth}/{mTHealth}");

            }

            int CannonDamage(int round)
            {
                if (round % 3 == 0 && round % 5 == 0)
                {
                    Console.WriteLine("The cannon is expected to deal 10 damage this round.");
                    return 10;
                }
                else if (round % 3 == 0)
                {
                    Console.WriteLine("The cannon is expected to deal 3 damage this round.");
                    return 3;
                }
                else if (round % 5 == 0)
                {
                     Console.WriteLine("The cannon is expeced to deal 5 damage this round.");
                    return 5;
                }
                else
                {
                    Console.WriteLine("The cannon is expected to deal 1 damage this round.");
                    return 1;
                }
            }

            int AskForANumber(string message)
            {
                Console.WriteLine(message);
                int number;
                while (!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.WriteLine("Please enter a valid number.");
                }
                if (number < currentMin || number > currentMax)  
                {
                    Console.WriteLine($"Please enter a number between {currentMin} and {currentMax}.");
                    return AskForANumber(message);
                }
                
                return number;
            }

            bool CheckShot(int range, int shotRange)
            {
                if (shotRange < range)
                {
                    Console.WriteLine("That round undershot the Manticore.");
                    currentMin = shotRange +1;
                }
                else if (shotRange > range)
                {
                    Console.WriteLine("That round shot over the Manticore.");
                    currentMax = shotRange -1;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That round was a DIRECT HIT!");
                    Console.ResetColor();
                    return true;
                }
                return false;
            }
        }
    }
}
