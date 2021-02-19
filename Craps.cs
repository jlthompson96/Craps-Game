//Joseph Thompson

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
            //Declare Variables
            int chips = 100;
            int wager = 0;
            int rollCounter = 1;
            int lost = 0;
            int won = 0;
            bool endGame = false;
            char answer;

            //Start Do-While Loop for Game
            do
            {
                Console.WriteLine("");
                Console.WriteLine("You currently have {0} chips.", chips);

                //Get Players Bet and Check for Enough Chips
                Console.WriteLine("How many chips would like to bet?");
                wager = Convert.ToInt16(Console.ReadLine());

                while(wager > chips || chips <= 0)
                {
                    Console.WriteLine("You dont have enough chips!");
                    Console.WriteLine("Please enter a wager based on the amount of chips you have.");
                    wager = Convert.ToInt16(Console.ReadLine());
                }

                //Roll the Die
                Random RandomNumber = new Random();

                int dieOne = RandomNumber.Next(1, 6);
                int dieTwo = RandomNumber.Next(1, 6);
                int firstRoll = dieOne + dieTwo;

                Console.WriteLine("You rolled a {0} and a {1} for a total of {2}.", dieOne, dieTwo, firstRoll);

                //Analyze First Roll
                if (firstRoll == 7 || firstRoll == 11)
                {
                    won = wager * 2 + chips;
                    chips = won;
                    endGame = true;
                    Console.WriteLine("Congrats you won!");
                    Console.WriteLine("You now have a total of {0} chips available!", won);
                }
                else if (firstRoll == 2 || firstRoll == 3 || firstRoll == 12)
                {
                    lost = chips - wager;
                    chips = lost;
                    endGame = true;
                    Console.WriteLine("Sorry you rolled a {0} on your first roll and lost", firstRoll);
                    Console.WriteLine("You now have {0} chips available.", lost);
                }
                else
                {
                    Console.WriteLine("Your point is {0}", firstRoll);
                }

                //Analyze Multiple Rolls if Needed
                while (endGame != true)
                {
                    int dieThree = RandomNumber.Next(1, 6);
                    int dieFour = RandomNumber.Next(1, 6);
                    int otherRoll = dieThree + dieFour;
                    Console.WriteLine("You rolled a {0} and a {1} for a total of {2}.", dieThree, dieFour, otherRoll);
                    if (otherRoll == firstRoll)
                    {
                        won = wager * 2 + chips;
                        chips = won;
                        Console.WriteLine("Congrats you won!");
                        Console.WriteLine("You now have a total of {0} chips available!", won);
                        endGame = true;
                    }
                    if (otherRoll == 7)
                    {
                        lost = chips - wager;
                        chips = lost;
                        Console.WriteLine("Sorry you rolled a 7 and lost");
                        Console.WriteLine("You now have {0} chips.", lost);
                        endGame = true;
                    }
                    if (otherRoll != firstRoll && otherRoll !=7)
                    {
                        Console.WriteLine("Printing from else statement");
                    }
                }

                //Ask if the Player Want to Play Again
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Would you like to play again?");
                Console.WriteLine("You currently have {0} chips left.", chips);
                Console.WriteLine("Enter Y for yes or N for no");
                answer = Convert.ToChar(Console.ReadLine());
            } while (answer == 'Y' || answer == 'y');

            //Display Remainig Chips
            Console.WriteLine("");
            Console.WriteLine("Thank you for playing!");
            Console.WriteLine("You have {0} chips left!", chips);
        }
    }
}
