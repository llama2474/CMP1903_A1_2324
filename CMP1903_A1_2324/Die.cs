﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Dice //test
    {
        public int FinalDie //Public variable encapsulates _diceVal
        { 
          get { return _diceVal; }
          set { _diceVal = value; } 
        }

        private int _diceVal = 0;

        Random random = new Random(); //Creates a new Random object
        public int RollDie()
        {
            
            _diceVal = random.Next(1,7); //Generates a random number between 1 and6
            Console.WriteLine($"You rolled a {_diceVal}");
            return _diceVal;
        }

    }
}
