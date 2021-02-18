//Joseph Thompson

using System;

namespace Craps_Game
{
    class Craps
    {
        private enum Result { WON,LOST,CONTINUE };

        private Random RandomNumber = new Random();

        //Play Method
        public void playCraps()
        {
            int points = 0;
            int chips = 100;
            int prize = 0;
            string answer = "";
            int roll = DiceRoll();
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Welcome to the Game of Craps!");
            Console.WriteLine("-----------------------------");

            do
            {
                //Get Wager
                Console.WriteLine("You have: {0} chips", chips);
                Console.WriteLine("How much would you like to wager?");
                int wager = Convert.ToInt32(Console.ReadLine());

                if (chips < wager)
                {
                    Console.WriteLine("You dont have enough chips to bet {0}", wager);
                }

                //Determine Roll Outcome
                if (roll == 7 || roll == 11)
                {
                    prize = wager * 2;
                    chips = prize + chips;
                    Console.WriteLine("Congrats you won!");
                    Console.WriteLine("You won {0} chips and now have a totoal of {1}", prize, chips);
                }
                else if (roll == 2 || roll == 3 || roll == 12)
                {
                    prize = chips - wager;
                    Console.WriteLine("You lose! You have {0} chips remaining", prize);
                }
                else
                {
                    int total = roll + points;
                    Console.WriteLine("You have a score of {0}", total);
                }

                Console.WriteLine("Would you like to play again?");
                answer = Console.ReadLine();
            } while (answer == "yes" && chips > 0);
            
        }

        //Roll Dice
        public int DiceRoll()
        {
            int dice1 = 2; //RandomNumber.Next(1, 6);
            int dice2 = 1; //RandomNumber.Next(1, 6);
            int roll = dice1 + dice2;
            Console.WriteLine("Player rolled a {0} and a {1} for a total of {2}", dice1, dice2, roll);
            return roll;
        }
    }
}
