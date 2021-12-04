using Utils;

namespace _03_Binary_Diagnostic
{
    public class Day3 : BaseDay
    {


        public int GetPowerConsumption()
        {
            var lines = Input.Split('\n').Select(x => x.Trim()).ToArray();

            var totalLines = lines.Length;

            var highBitCounts = GetHighBitCounts(lines);

            var gammaRate = Convert.ToInt32(string.Join("", highBitCounts.Select(x => x >= totalLines / 2 ? '1' : '0')), 2);
            var epsilonRate = Convert.ToInt32(string.Join("", highBitCounts.Select(x => x >= totalLines / 2 ? '0' : '1')), 2);

            return gammaRate * epsilonRate;
        }

        public int GetLifeSupportRating()
        {
            var lines = Input.Split('\n').Select(x => x.Trim()).ToArray();

            var bitCount = lines[0].Length;

            // Oxygen generator rating
            int oxygenRating = -1;
            var oxyLines = lines;
            for (int i = 0; i < bitCount; i++)
            {
                var highBitCounts = GetHighBitCounts(oxyLines, i, 1)[0];
                var targetBit = highBitCounts >= oxyLines.Length / 2f ? '1' : '0';
                oxyLines = oxyLines
                    .Where(l => l[i] == targetBit)
                    .ToArray();

                if (oxyLines.Length == 1)
                {
                    oxygenRating = Convert.ToInt32(oxyLines[0], 2);
                    break;
                }
            }

            // CO2 scrubber rating
            int co2Scrubber = -1;
            var co2Lines = lines;
            for (int i = 0; i < bitCount; i++)
            {
                var highBitCounts = GetHighBitCounts(co2Lines, i, 1)[0];
                var targetBit = highBitCounts >= co2Lines.Length / 2f ? '0' : '1';
                co2Lines = co2Lines
                    .Where(l => l[i] == targetBit)
                    .ToArray();

                if (co2Lines.Length == 1)
                {
                    co2Scrubber = Convert.ToInt32(co2Lines[0], 2);
                    break;
                }
            }

            return oxygenRating * co2Scrubber;
        }

        private static int[] GetHighBitCounts(string[] lines, int startBit = 0, int bitCount = -1)
        {
            if (bitCount < 0)
            {
                bitCount = lines[0].Length - startBit;
            }
            var highBitCounts = new int[bitCount];

            foreach (var item in lines)
            {
                for (int i = startBit; i < startBit + bitCount; i++)
                {
                    var bit = item[i];

                    if (bit == '1')
                    {
                        highBitCounts[i - startBit]++;
                    }
                }
            }

            return highBitCounts;
        }
    }
}