using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Game
    {
        private readonly Grid grid;

        public Game(int rows, int cols)
        {
            grid = new Grid(rows, cols); //get me a grid of size x,y
        }

        public void Run(int generations = 100, int delayMs = 1000)
        {
            for (int i = 0; i < generations; i++)
            {
                grid.Display(i + 1);
                grid.Update();
                System.Threading.Thread.Sleep(delayMs);
            }
        }
    }

}
