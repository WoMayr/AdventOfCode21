using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Giant_Squid
{
    public class Board
    {
        public int[,] Numbers { get; private set; } = new int[5,5];
        public bool[,] Marks { get; private set; } = new bool[5,5];
        public bool Won { get; set; } = false;

        public static Board Read(StreamReader reader)
        {
            var board = new Board();

            for (int i = 0; i < 5; i++)
            {
                var line = reader.ReadLine();
                var numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < 5; j++)
                {
                    board.Numbers[i, j] = numbers[j];
                }
            }

            return board;
        }

        private int CalculateScore()
        {
            var score = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!Marks[i, j])
                    {
                        score += Numbers[i, j];
                    }
                }
            }
            return score;
        }

        public int MarkNumber(int number)
        {
            int x = 0, y = 0;

            bool markedNumber = false;
            for (x = 0; x < 5; x++)
            {
                for (y = 0; y < 5; y++)
                {
                    if (Numbers[y, x] == number)
                    {
                        Marks[y, x] = true;
                        markedNumber = true;
                        break;
                    }
                }

                if (markedNumber)
                {
                    break;
                }
            }

            // Number not found on board
            if (x == 5 && y == 5)
            {
                return -1;
            }

            // Check win
            bool found = true;
            for (int testX = 0; testX < 5 && found; testX++)
            {
                if (Marks[y, testX] == false)
                {
                    found = false;
                }
            }

            if (found)
            {
                Won = true;
                return CalculateScore();
            }

            found = true;
            for (int testY = 0; testY < 5 && found; testY++)
            {
                if (Marks[testY, x] == false)
                {
                    found = false;
                }
            }

            if (found)
            {
                Won = true;
                return CalculateScore();
            }

            return -1;
        }
    }
}
