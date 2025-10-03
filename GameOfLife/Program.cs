using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = 20;
            int cols = 40;
            int generations = 100; //the game will run till 100th generation

            var game = new Game(rows, cols);
            game.Run(generations); //game starts from this point

        }
    }
}
