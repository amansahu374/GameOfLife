using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Grid
    {
        private readonly int rows;
        private readonly int cols;
        private Cell[,] cells;

        public Grid(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            cells = new Cell[rows, cols];
            Initialize();
        }

        private void Initialize()
        {
            var rand = new Random();
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    cells[r, c] = new Cell(rand.NextDouble() > 0.7); // 30% chance alive
        }

        public void Display(int generation)
        {
            Console.Clear();
            Console.WriteLine($"Generation {generation}");
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                    Console.Write(cells[r, c]);
                Console.WriteLine();
            }
        }

        public void Update()
        {
            var newCells = new Cell[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    int aliveNeighbors = CountAliveNeighbors(r, c);
                    bool isAlive = cells[r, c].IsAlive;

                    bool nextState;

                    if (isAlive)
                    {
                        if (aliveNeighbors < 2 || aliveNeighbors > 3)
                            nextState = false; // Dies
                        else
                            nextState = true;  // Lives
                    }
                    else
                    {
                        if (aliveNeighbors == 3)
                            nextState = true;  // Becomes alive
                        else
                            nextState = false; // Stays dead
                    }


                    newCells[r, c] = new Cell(nextState);
                }
            }

            cells = newCells;
        }

        private int CountAliveNeighbors(int row, int col)
        {
            int count = 0;

            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    if (r == row && c == col) continue;
                    if (r >= 0 && r < rows && c >= 0 && c < cols)
                        if (cells[r, c].IsAlive) count++;
                }
            }

            return count;
        }
    }
}
