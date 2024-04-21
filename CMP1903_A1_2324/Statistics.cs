using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    public static class Statistics //Stores all relevant statistics
    {
        public static int SevenHighScore
        { get; set; }

        public static int ThreeHighScore
        { get; set; }

        public static int Draw
        { get; set; }

        public static int Player1Wins
        { get; set; }

        public static int Player2Wins
        { get; set; }

        public static int BotWins
        { get; set; }

        public static void DisplayStatistics() //Displays all the statistics
        {
            Console.WriteLine($"SevenOut High Score = {SevenHighScore}");
            Console.WriteLine($"ThreeOrMore High Score = {ThreeHighScore}");
            Console.WriteLine($"Number of Player 1 wins = {Player1Wins}");
            Console.WriteLine($"Number of Player 2 wins = {Player2Wins}");
            Console.WriteLine($"Number of Bot wins = {BotWins}");
            Console.WriteLine($"Number of Draws = {Draw}");
            Console.WriteLine($"Number of games played = {Player1Wins+Player2Wins+Draw}");
            Console.WriteLine("\nPress any key to return to the menu");
            Console.ReadKey();
            Game game = new Game();
            game.Play();
        }
    }
}
