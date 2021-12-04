using System.Text;
using Utils;

namespace _04_Giant_Squid
{
    public class Day4 : BaseDay
    {
        private int[] randomNumbers;
        private List<Board> boards;

        private void ReadBoards()
        {
            using var fs = new MemoryStream(Encoding.UTF8.GetBytes(Input));
            using var reader = new StreamReader(fs);

            randomNumbers = reader.ReadLine()
                .Split(',')
                .Select(c => int.Parse(c.Trim()))
                .ToArray();

            // Splitter
            reader.ReadLine();

            boards = new();
            while (!reader.EndOfStream)
            {
                Board board = Board.Read(reader);
                boards.Add(board);
                reader.ReadLine();
            }
        }

        public int GetWinningScore()
        {
            ReadBoards();

            foreach (var number in randomNumbers)
            {
                foreach (var board in boards)
                {
                    var result = board.MarkNumber(number);
                    if (result > 0)
                    {
                        return result * number;
                    }
                }
            }

            return -1;
        }

        public int GetLastWinningScore()
        {
            ReadBoards();

            var allBoards = boards.Count;

            foreach (var number in randomNumbers)
            {
                foreach (var board in boards)
                {
                    if (board.Won)
                    {
                        continue;
                    }

                    var result = board.MarkNumber(number);
                    if (result > 0)
                    {
                        allBoards--;
                        if (allBoards == 0)
                        {
                            return result * number;
                        }
                    }
                }
            }

            return -1;
        }
    }
}