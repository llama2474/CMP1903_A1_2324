using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Do you want to Play Y/N"); //Asks the player if they want to play
            string input = Console.ReadLine();
            while (input.ToUpper() != "Y" &&  input.ToUpper() != "N") //Checks for a correct input
            {
                Console.WriteLine("Invalid Input Try again, Only Y/N accepted");
                input = Console.ReadLine();
            }
            if (input.ToUpper() == "N")  
            {
                System.Environment.Exit(0);
            }
            else
            {
                while (input.ToUpper() == "Y") //Runs the whole program
                {
                    Game game = new Game(); //Creates a new game object
                    game.Play();
                    Console.WriteLine("Do you want to Play Again Y/N"); //Asks the player if they want to play again
                    input = Console.ReadLine();
                    while (input.ToUpper() != "Y" && input.ToUpper() != "N") //Checks for a correct input
                    {
                        Console.WriteLine("Invalid Input Try again, Only Y/N accepted");
                        input = Console.ReadLine();
                    }
                }
            }
           
            Statistics.DisplayStatistics(); //After the player doesnt want to contine, the statistics are displayed
            
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
