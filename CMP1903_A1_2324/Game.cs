using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        public void Play() //Handles the user input and runs the chosen game
        {
            
            Console.WriteLine("1.Sevens Out\n2.Three or More\n3.Testing"); //Asks the player to choose a game
            Console.WriteLine("Press 1 to play sevens out, press 2 to play three or more, press 3 to run tests");
            string input = Console.ReadLine();
            while (input !="1" &&  input !="2" && input !="3") //Checks for a correct input
            {
                Console.WriteLine("Invalid Input, try again");
                Console.WriteLine("Press 1 to play sevens out, press 2 to play three or more");
                input = Console.ReadLine();
            }
            Console.WriteLine("1.1Player\n2.2Player"); //Asks the player if they want to play 2 player or one player
            Console.WriteLine("Press 1 to play 1 player, press 2 to play 2 player");
            string input2= Console.ReadLine();
            while(input2 !="1" && input2 !="2") //checks for a correct input
            {
                Console.WriteLine("Invalid Input, try again");
                Console.WriteLine("Press 1 to play 1 player, press 2 to play 2 player");
                input2 = Console.ReadLine();
            }
            if (input =="1")

            {
                SevenOut sevenOut = new SevenOut();
                sevenOut.Play(input2);
            }
            else if (input =="2")
            { 
                ThreeOrMore threeOrMore = new ThreeOrMore();
                threeOrMore.Play(input2);
            }
            else
            {
                Testing.TestGame();
            }
            
        }
        public class SevenOut
        {
            protected int FinalSum1
            {
                get { return _sum1; }
                set { _sum1 = value; }
            }
            private int _sum1 = 0;

            protected int FinalSum2
            {
                get { return _sum2; }
                set { _sum2 = value; }
            }
            private int _sum2 = 0;
            public void Play(string input) //Runs the seven out game
            {
                Dice dice1 = new Dice();
                Dice dice2 = new Dice();
                if (input!="3")
                {
                    Roll(1, false); //Calls the roll method
                }
               
                if (input =="1") //Runs the game in one player mode
                {
                    while ((dice1.FinalDie+dice2.FinalDie)!=7) //Rolls 2 dice until the sum is 7
                    {
                        _sum2 += dice1.Roll() + dice2.Roll(); //Adds the 2 rolls to the total
                        if (dice1.FinalDie==dice2.FinalDie) //Adds the 2 rolls again if its a double
                        {
                            _sum2 += dice1.FinalDie + dice2.FinalDie;
                        }
                    }
                    Console.WriteLine($"The bot got a final total of {FinalSum2}");
                    if (FinalSum1>FinalSum2)
                    {
                        Console.WriteLine("You Win");
                        Statistics.Player1Wins += 1;
                        
                    }
                    else if(FinalSum2>FinalSum1)
                    {
                        Console.WriteLine("You Lose");
                        Statistics.BotWins += 1;
                    }
                    else
                    {
                        Console.WriteLine("Its a Draw");
                        Statistics.Draw += 1;
                    }
                }
                else if(input =="2") //Runs the game for 2 players
                {
                    Roll(2,false);
                    if (FinalSum1>FinalSum2)
                    {
                        Console.WriteLine("Player 1 Wins");
                        Statistics.Player1Wins += 1;
                    }
                    else if (FinalSum2>FinalSum1)
                    {
                        Console.WriteLine("Player 2 Wins");
                        Statistics.Player2Wins += 1;
                    }
                    else
                    {
                        Console.WriteLine("Its a Draw");
                        Statistics.Draw += 1;
                    }
                }
                else //Runs the game in test mode
                {
                    Console.WriteLine("TEST RUN OF SEVEN OUT");
                    Roll(1, true);
                }
                if (FinalSum1>Statistics.SevenHighScore)
                {
                    Statistics.SevenHighScore = FinalSum1;
                }
                else if(FinalSum2>Statistics.SevenHighScore)
                {
                    Statistics.SevenHighScore=FinalSum2;
                }
                

            }
            private void Roll(int Player, bool Test) //Handles the rolling of the two dice
            {
                Console.WriteLine($"Player {Player}'s turn");
                Dice dice1 = new Dice();
                Dice dice2 = new Dice();
                int TempSum = 0;
                while ((dice1.FinalDie + dice2.FinalDie) != 7) //Keeps rolling until the sum of the two dice is a 7
                {
                    Console.WriteLine("Press any key to roll");
                    Console.ReadKey();
                    Console.WriteLine();
                    if (Player ==1) //If its player 1
                    {
                        TempSum = dice1.Roll() + dice2.Roll();
                        _sum1 += TempSum;
                        if (Test==true)
                        {
                            Testing.TestSum(dice1.FinalDie, dice2.FinalDie,TempSum); //Values are passed to the test class
                        }
                    }
                    else if (Player ==2) //If its player 2
                    {
                        _sum2 += dice1.Roll() + dice2.Roll();
                    }
                    Console.WriteLine($"You rolled a {dice1.FinalDie}");
                    Console.WriteLine($"You rolled a {dice2.FinalDie}");
                    Console.WriteLine();
                    if (dice1.FinalDie == dice2.FinalDie) //If a double is rolled, the total is added again
                    {
                        if (Player ==1)
                        {
                            _sum1 += dice1.FinalDie + dice2.FinalDie;
                        }
                        else
                        {
                            _sum2 += dice1.FinalDie + dice2.FinalDie;
                        }
                    }
                }

                if (Test == true)
                {
                        Testing.TestStop(TempSum); //Total is passed to the test class
                }

                if (Player ==1) //Prints the final sum
                {
                    Console.WriteLine($"Youre out, your final total is {FinalSum1}");
                }
                else
                {
                    Console.WriteLine($"Youre out, your final total is {FinalSum2}");
                }
            }
        }
        public class ThreeOrMore
        {
            protected int PointTotal1
            {
                get { return points1; }
                set {  points1 = value; }
            }
            private int points1 = 0;


            protected int PointTotal2
            {
                get { return points2; }
                set { points2 = value; }
            }

            private int points2 = 0;

            public void Play(string input) //Runs the three or more game
            {
             
                if (input =="1") //Runs the game for 1 player
                {
                    while (points1 <= 20 & points2 <= 20)
                    {
                        Roll(1);
                        BotRoll();
                    }
                }
                else if (input =="2") //Runs the game for 2 players
                {
                    while (points1 <= 20 & points2 <= 20)
                    {
                        Roll(1); //Rolls for player 1
                        Roll(2); //Rolls fot player 2
                    }
                }
                else //Runs the test for the game
                {
                    while (points1 <= 20)
                    {
                        Roll(3);
                    }
                    Testing.TestEnd(points1); //Passes the points to the test class
                }
                if (points1>points2) //Prints who won
                {
                    Console.WriteLine("\nPlayer 1 Wins");
                    Statistics.Player1Wins += 1;
                }
                else if(points1<points2)
                {
                    Console.WriteLine("\nPlayer 2 Wins");
                    Statistics.Player2Wins += 1;
                }
                else
                {
                    Console.WriteLine("Its a Draw");
                    Statistics.Draw += 1;
                }

                if (points1>Statistics.ThreeHighScore)
                {
                    Statistics.ThreeHighScore = points1;
                }
               else if(points2>Statistics.ThreeHighScore)
                {
                    Statistics.ThreeHighScore = points2;
                }
            }

            private void Roll(int Player)
            {
                Dice dice = new Dice();

                List<int> ListOfDice = new List<int>();
                List<int> MainCounter = new List<int>();
                for (int i = 0; i < 5; i++) //Rolls 5 dice
                {
                    Console.WriteLine("Press any key to roll");
                    Console.ReadKey();
                    Console.WriteLine();
                    ListOfDice.Add(dice.Roll());
                    Console.WriteLine($"You Rolled a {dice.FinalDie}");
                }

                if (DiceChecker(ListOfDice.ToArray(), MainCounter) == true) //Checks if you can reroll
                {
                    Reroll(ListOfDice.ToArray(), MainCounter); //Handles the rerolling of dice
                }
                
                PointCalc(MainCounter.ToArray(),Player); //Checks if any points hsould be awarded
                if (Player ==1) //Prints the total points
                {
                    Console.WriteLine($"\nEnd of Turn, you have {points1} points\nPlayer 2's Turn");
                }
                else if (Player==2)
                {
                    Console.WriteLine($"\nEnd of Turn, you have {points2} points\nPlayer 1's Turn");
                }
                else
                {
                    Console.WriteLine($"\nTEST RUN CONTINUE ROLLING, YOU HAVE {points1} POINTS");
                }
                
            }

            private void BotRoll()
            {
                Dice dice = new Dice();

                List<int> ListOfDice = new List<int>();
                List<int> MainCounter = new List<int>();

                for (int i = 0;i<5;i++) //Rolls 5 dice
                {
                    Thread.Sleep(1);
                    ListOfDice.Add(dice.Roll());
                    Console.WriteLine($"The bot rolled a {dice.FinalDie}");
                }
                int[] DiceList=ListOfDice.ToArray();
                if (DiceChecker(ListOfDice.ToArray(), MainCounter) == true) //If the bot can reroll, it will reroll only the remaining dice as this is the best option
                {
                    for (int i = 0; i < MainCounter.Count; i++) //Checks the list
                    {
                        if (MainCounter[i] == 1) //If the dice only appears once, it will be rerolled
                        {
                            DiceList[i] = dice.Roll(); //rerolls the dice
                        }
                    }
                    foreach (int i in DiceList) //Prints the bots new rolls
                    {
                        Console.WriteLine($"The bot Rerolled and got {i}");
                    }
                }

                DiceChecker(DiceList, MainCounter);//Ammends the MainCounter
                PointCalc(MainCounter.ToArray(),2); //Checks if the bot score any points
                Console.WriteLine($"End of bot's turn, it has {points2} points\nPlayer 1's Turn");
            }

            private bool DiceChecker(int[] DiceList, List<int> MainCounter) 
            {
                bool ReRoll=false;
                
                for (int i= 0; i < DiceList.Length; i++) //Checks how many times a number appears
                {
                    int TempCounter=0;
                    foreach (int d in DiceList)
                    {
                        if (d == DiceList[i]) //The number of times a number appears is counted and added to a list
                        {
                            
                            TempCounter++;
                        }
                    }
                    MainCounter.Add(TempCounter);//This list contains the number of times a number appears
                }
                foreach (int Num in MainCounter) 
                {
                    if(Num==2) //If a two appears that means that at least one pair has been rolled so the player can reroll
                    {
                        ReRoll = true;
                        break;
                    }
                    else if(Num==3) //If there is a 3 the player cannot reroll
                    {
                        ReRoll = false;
                        break;
                    }
                }
                return ReRoll;
            }

            private void Reroll(int[] DiceList, List<int> MainCounter) //Handlles the rerolling of dice
            {
                Console.WriteLine("1.Reroll All\n2.Reroll Remaining");
                Console.WriteLine("Press 1 to reroll all or 2 to reroll remaining dice");
                string input=Console.ReadLine();

                while (input != "1" && input != "2") //Checks for a correct input
                {
                    Console.WriteLine("Invalid input, try again");
                    Console.WriteLine("Press 1 to reroll all or 2 to reroll remaining dice");
                    input = Console.ReadLine();
                }

                if (input =="1") //Rerolls all the dice
                {
                    Console.WriteLine("ReRolling all dice\n");
                    Dice dice = new Dice();
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine("Press any key to roll");
                        Console.ReadKey();
                        Console.WriteLine();
                        DiceList[i] = dice.Roll();
                        Console.WriteLine($"You Rolled a {dice.FinalDie}");
                    }
                }
                else //Rerolls the remaining dice
                {
                    Console.WriteLine("ReRolling remaining dice");
                    for (int i= 0;i<MainCounter.Count;i++)
                    {
                        if (MainCounter[i] ==1) //If the number is a 1 that means it only appers once so it should be rerolled
                        {
                            Console.WriteLine("Press any key to roll");
                            Console.ReadKey();
                            Console.WriteLine();
                            Dice dice = new Dice();
                            DiceList[i] = dice.Roll();
                            Console.WriteLine($"You Rolled a {dice.FinalDie}");
                        }
                    }
                }
                DiceChecker(DiceList, MainCounter);//Ammends the MainCounter

            }

            private void PointCalc(int[] MainCounter, int Player) //Calculates how many points should be added
            {
                foreach (int i in MainCounter)
                { 
                    if (Player == 1)
                    {
                        if (i == 5)
                        {
                            points1 += 12;
                        }
                        else if (i == 4)
                        {
                            points1 += 6;
                            break;
                        }
                        else if (i == 3)
                        {
                            points1 += 3;
                            break;
                        }
                    }
                    else if (Player == 2)
                    {
                        if (i == 5)
                        {
                            points2 += 12;
                        }
                        else if (i == 4)
                        {
                            points2 += 6;
                            break;
                        }
                        else if (i == 3)
                        {
                            points2 += 3;
                            break;
                        }
                    }
                    else
                    {
                        int temppoints = points1;
                        if (i == 5)
                        {
                            points1 += 12;
                            Testing.TestScore(temppoints, 12, points1); //The Points are passed to the test class and checked
                        }
                        else if (i == 4)
                        {
                            points1 += 6;
                            Testing.TestScore(temppoints, 6, points1);
                            break;
                        }
                        else if (i == 3)
                        {
                            points1 += 3;
                            Testing.TestScore(temppoints, 3, points1);
                            break;
                        }
                    }
                }
            }
        }
    }
}
