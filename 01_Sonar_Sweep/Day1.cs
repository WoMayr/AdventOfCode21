using Utils;

namespace _01_Sonar_Sweep
{
    public class Day1 : BaseDay
    {
        public int Part1()
        {
            var depths = Input
                .Split('\n')
                .Select(int.Parse)
                .ToList();

            var increases = 0;

            for (int i = 1; i < depths.Count; i++)
            {
                var last = depths[i - 1];
                var current = depths[i];

                if (current > last)
                {
                    increases++;
                }
            }

            return increases;
        }

        private int GetSlidingWindow(List<int> numbers, int start, int length)
        {
            return numbers.GetRange(start, length).Sum();
        }

        public int Part2()
        {
            var depths = Input
                .Split('\n')
                .Select(int.Parse)
                .ToList();

            var increases = 0;
            var length = 3;

            for (int i = 1; i < depths.Count - length + 1; i++)
            {
                var last = GetSlidingWindow(depths, i - 1, length);
                var current = GetSlidingWindow(depths, i, length);

                if (current > last)
                {
                    increases++;
                }
            }

            return increases;
        }
    }
}