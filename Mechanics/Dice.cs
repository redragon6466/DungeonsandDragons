using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DNDSim.Mechanics
{
    public static class Dice
    {
        public static byte RollTheDice(byte numberOfDice, byte diceType)
        {
            return RollTheDice(numberOfDice, diceType, 0);
        }

        public static byte RollTheDice(byte numberOfDice, byte diceType, byte modifier)
        {
            Random rnd = new Random();
            int total = 0;
            int result =0 ;
            Debug.WriteLine("Rolling " + numberOfDice + "d" + diceType);
            for (int i = 0; i < numberOfDice; i++)
            {
                result =rnd.Next((int)diceType);
                //Debug.WriteLine("rolled a "+ result);
                total += result;  
            }
            
            return (byte)(result + modifier);
        }
    }
}
