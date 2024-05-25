namespace TicTacToeGame.Models
{
    public class TicTacToe
    {
        public char[] Board { get; set; }
        public char CurrentPlayer { get; set; }

        public TicTacToe()
        {
            Board = new char[9];
            for (int i = 0; i < 9; i++)
            {
                Board[i] = ' ';
            }
            CurrentPlayer = 'X';
        }

        public bool MakeMove(int index)
        {
            if (Board[index] == ' ')
            {
                Board[index] = CurrentPlayer;
                CurrentPlayer = CurrentPlayer == 'X' ? 'O' : 'X';
                return true;
            }
            return false;
        }

        public char CheckWinner()
        {
            int[,] winningCombinations = new int[,]
            {
                {0, 1, 2},
                {3, 4, 5},
                {6, 7, 8},
                {0, 3, 6},
                {1, 4, 7},
                {2, 5, 8},
                {0, 4, 8},
                {2, 4, 6}
            };

            for (int i = 0; i < 8; i++)
            {
                if (Board[winningCombinations[i, 0]] != ' ' &&
                    Board[winningCombinations[i, 0]] == Board[winningCombinations[i, 1]] &&
                    Board[winningCombinations[i, 0]] == Board[winningCombinations[i, 2]])
                {
                    return Board[winningCombinations[i, 0]];
                }
            }
            return ' ';
        }
    }
}

