using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    public static class Testing
    {
        public static void TestGame()  //Creates both game objects and runs the games in test mode
        {
            Console.WriteLine("TESTING GAME");
            Game.ThreeOrMore threeOrMore = new Game.ThreeOrMore();
            threeOrMore.Play("3");
            Game.SevenOut sevenOut = new Game.SevenOut();
            sevenOut.Play("3");
        }

        public static void TestSum(int one, int two, int sum) //Checks if the Seven out sum is correct
        {
            Debug.Assert(one + two == sum);
            Console.WriteLine("SUM CHECKED");
        }

        public static void TestStop(int sum) //Checks if the seven out game stops on a seven
        {
            Debug.Assert(sum == 7);
            Console.WriteLine("SEVEN DETECTED, GAME WILL STOP");
        }

        public static void TestScore(int Score,int Points,int FinalScore ) //Checks if the points in the three or more game have been added correectly
        {
            Debug.Assert(Score + Points == FinalScore);
            Console.WriteLine($"SCORE CHECKED, {Points} POINTS HAVE BEEN ADDED");
        }

        public static void TestEnd(int FinalScore) //Checks if the three or more game ends after 20 points are reached
        {
            Debug.Assert(FinalScore >= 20);
            Console.WriteLine("SCORE >= 20 GAME WILL END");
        }
    }
}
