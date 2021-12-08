using System.Text.RegularExpressions;
using Utils;

namespace _05_Hydrothermal_Venture
{
    public class Day5 : BaseDay
    {
        public int[,] Read1()
        {
            List<HydrothermalLine> lines;
            int[,] grid;
            ReadInput(out lines, out grid);

            foreach (var (x1, y1, x2, y2) in lines)
            {
                int dx = 0;
                int dy = 0;
                int cnt = 0;
                if (x1 == x2)
                {
                    cnt = Math.Abs(y1 - y2);
                    dy = y1 > y2 ? -1 : 1;
                }
                else if (y1 == y2)
                {
                    cnt = Math.Abs(x1 - x2);
                    dx = x1 > x2 ? -1 : 1;
                }
                else
                {
                    continue;
                }

                for (int i = 0; i <= cnt; i++)
                {
                    grid[x1 + (dx * i), y1 + (dy * i)]++;
                }
            }

            return grid;
        }

        private void ReadInput(out List<HydrothermalLine> lines, out int[,] grid)
        {
            lines = new List<HydrothermalLine>();
            int width = 0;
            int height = 0;
            foreach (var item in Input.Split('\n'))
            {
                var newEntry = HydrothermalLine.FromString(item);
                lines.Add(newEntry);

                var x = Math.Max(newEntry.x1, newEntry.x2);
                if (x > width)
                {
                    width = x;
                }
                var y = Math.Max(newEntry.y1, newEntry.y2);
                if (y > height)
                {
                    height = y;
                }
            }

            grid = new int[width + 1, height + 1];
        }

        public int[,] Read2()
        {
            List<HydrothermalLine> lines;
            int[,] grid;
            ReadInput(out lines, out grid);

            foreach (var (x1, y1, x2, y2) in lines)
            {
                int dx = 0;
                int dy = 0;
                int cnt = 0;
                if (x1 == x2)
                {
                    cnt = Math.Abs(y1 - y2);
                    dy = y1 > y2 ? -1 : 1;
                } 
                else if (y1 == y2)
                {
                    cnt = Math.Abs(x1 - x2);
                    dx = x1 > x2 ? -1 : 1;
                }
                else
                {
                    cnt = Math.Abs(y1 - y2);
                    dy = y1 > y2 ? -1 : 1;
                    dx = x1 > x2 ? -1 : 1;
                }

                for (int i = 0; i <= cnt; i++)
                {
                    grid[x1 + (dx * i), y1 + (dy * i)]++;
                }
            }

            return grid;
        }

        public int Overlapping(int[,] grid)
        {
            var cnt = 0;
            foreach (var item in grid)
            {
                if (item > 1)
                {
                    cnt++;
                }
            }
            return cnt;
        }
    }
}