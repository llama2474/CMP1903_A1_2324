﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        public int FinalSum //Public variable that sets and gets the private variable sum
        {
            get { return _sum; }
            set { _sum = value; }
        }
        private int _sum = 0; //Private variable sum
        public void Play(bool Test) //Main method for the class, handles playing the game
        {
            if (Test==false) 
            {
                Console.WriteLine("Playing Game");
            }
            Dice dice = new Dice(); //Creates a new dice object
            Dice dice2 = new Dice();
            Dice dice3 = new Dice();
        
            _sum = dice.Roll()+dice2.Roll()+dice3.Roll(); //Calls the roll die method on the dice objects and the returning integer is added to the _sum
            
            FinalSum = _sum;
            Console.WriteLine($"The sum of the three dice rolls is {_sum}");
            if (Test == false) //Checks if it is a test before asking to roll again
            {
                while (RollAgain().ToUpper() == "Y") //If the response is Y, it rolls a dice
                {
                    FinalSum += dice.Roll();
                    Console.WriteLine($"New sum = {FinalSum}"); //Shows the new total
                }
            }
        }
        private string RollAgain() //Asks if another dice should be rolled and handles the response
        {
            string Response ="";
            bool Valid = false;
            while (Valid == false) //While loop forces a correct response to continue
            {
                Console.WriteLine("Do you want to roll another dice? Y/N");
                Response = Console.ReadLine();
                if (Response.ToUpper() != "Y" & Response.ToUpper() != "N") //Checks if the response is Y or N
                {
                    Console.WriteLine("Response not valid");
                }
                else
                {
                    Valid = true; //Ends the while loop if the response is valid
                }
                
            }
            return Response;
        }
 
    }
}



