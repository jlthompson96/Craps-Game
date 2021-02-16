using System;

namespace Craps_Game
{
    class Program
    {
        private enum Result { WON,LOST,CONTINUE };

        private Random RandomNumber = new Random();

            public void playGame()
            {
                playCraps();
            }

        //Play Method
        public void playCraps()
        {
            int points = 0;
            int roll = DiceRoll();

            if(roll == 7 || roll == 11)
            {
                Console.WriteLine("Congrats you won!");
            }
            else if (roll == 2 || roll == 3 || roll == 12)
            {
                Console.WriteLine("You lose you rolled a {0} on your first roll", points);
            }
            else
            {
                int total = roll + points;
                Console.WriteLine("You have a score of {0}", total);
            }
        }

        //Roll Dice
        public int DiceRoll()
        {
            int dice1 = RandomNumber.Next(1, 6);
            int dice2 = RandomNumber.Next(1, 6);
            int roll = dice1 + dice2;
            Console.WriteLine("Player rolled a {0} and a {1} for a total of {2}", dice1, dice2, roll);
            return roll;
        }
    }
}
