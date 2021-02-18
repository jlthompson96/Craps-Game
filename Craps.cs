using System;

namespace Craps
{
    class Program
    {
        static void Main(string[] args)
        {
            title();
            playCraps();
        }

        static void title()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("-- Welcome to Craps! --");
            Console.WriteLine("Good Luck and Have Fun!");
            Console.WriteLine("-----------------------");
        }

        static void playCraps()
        {
            int chips = 100;
            int wager = 0;
            int rollCounter = 1;
            int lost = 0;
            int won = 0;
            bool endGame = false;
            char answer;

            do
            {
                Console.WriteLine("");
                Console.WriteLine("You currently have {0} chips.", chips);
                Console.WriteLine("How many would like to bet?");
                wager = Convert.ToInt16(Console.ReadLine());

                Random RandomNumber = new Random();

                int dieOne = RandomNumber.Next(1, 6);
                int dieTwo = RandomNumber.Next(1, 6);
                int firstRoll = dieOne + dieTwo;

                Console.WriteLine("You rolled a {0} and a {1} for a total of {2}.", dieOne, dieTwo, firstRoll);

                if (firstRoll == 7 || firstRoll == 11)
                {
                    won = wager * 2 + chips;
                    Console.WriteLine("Congrats you won!");
                    Console.WriteLine("You now have a total of {0} chips available!", won);
                }
                else if (firstRoll == 2 || firstRoll == 3 || firstRoll == 12)
                {
                    lost = chips - wager;
                    Console.WriteLine("Sorry you rolled a {0} on your first roll and lost", firstRoll);
                    Console.WriteLine("You now have {0} chips available.", lost);
                }
                else
                {
                    Console.WriteLine("Your point is {0}", firstRoll);
                    rollCounter++;
                }

                //Run Rest of Game
                while (rollCounter >= 2 && endGame != true)
                {
                    dieOne = RandomNumber.Next(1, 6);
                    dieTwo = RandomNumber.Next(1, 6);
                    int otherRoll = dieOne + dieTwo;

                    Console.WriteLine("You rolled a {0} and a {1} for a total of {2}.", dieOne, dieTwo, otherRoll);
                    if (otherRoll == firstRoll)
                    {
                        won = wager * 2 + chips;
                        Console.WriteLine("Congrats you won!");
                        Console.WriteLine("You now have a total of {0} chips available!", won);
                        endGame = true;
                    }
                    else if (otherRoll == 7)
                    {
                        lost = chips - wager;
                        Console.WriteLine("Sorry you rolled a 7 and lost");
                        Console.WriteLine("You now have {0} chips.", lost);
                        endGame = true;
                    }
                }
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Would you like to play again?");
                Console.WriteLine("Enter Y for yes or N for no");
                answer = Convert.ToChar(Console.ReadLine());
            } while (answer == 'Y' || answer == 'y');
        }
    }
}
