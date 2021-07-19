using System;

namespace TicTacToe
{
    class Program
    {
        private static char[,] board = new char[3, 3];

        private static void Main(string[] args)
        {
            InitBoard();
            DisplayBoard();
            
            bool turnOfX = false; ;
            int row, column;
            string messageToUser;
            do
            {
                turnOfX = !turnOfX;
                do
                {
                    messageToUser = "";
                    if (turnOfX) Console.WriteLine("X choose Your location");
                    else Console.WriteLine("O choose Your location");
                    Console.WriteLine("Choose row (0,1,2): ");
                    row = int.Parse(Console.ReadLine());
                    Console.WriteLine("Choose column (0,1,2): ");
                    column = int.Parse(Console.ReadLine());
                    if (row > 2 || row < 0 || column > 2 || column < 0) messageToUser = "Please enter valid numbers 0,1,2";
                    else if (board[row, column] != ' ') messageToUser = "This cell is already ocuupied. Please enter another cell!";
                    Console.WriteLine(messageToUser);
                } while (messageToUser != "");

                if (turnOfX) board[row, column] = 'X';
                else board[row, column] = 'O';
                DisplayBoard();
            } while (!SomebodyWon()&&!IsFull());

            if (SomebodyWon()) {
                if (turnOfX) messageToUser = "Wow! X has won!";
                else messageToUser = "Foooooo! O has managed to do smth!";
            }

            else messageToUser = "Nobody has won";
            Console.WriteLine(messageToUser);
            Console.ReadKey();
        }

        private static void InitBoard()
        {
            // fills up the board with blanks
            for (var r = 0; r < 3; r++)
            {
                for (var c = 0; c < 3; c++) board[r, c] = ' ';
            }          
        }

        private static bool SomebodyWon()
        {
            return
            (board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2] && board[0, 0] != ' ') ||
            (board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2] && board[1, 1] != ' ') ||
            (board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2] && board[2, 2] != ' ') ||
            (board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0] && board[0, 0] != ' ') ||
            (board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1] && board[1, 1] != ' ') ||
            (board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2] && board[2, 2] != ' ') ||
            (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[1, 1] != ' ') ||
            (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[1, 1] != ' '); 
        }

        private static bool IsFull()
        {
            bool result = true;
            for (var r = 0; r < 3; r++)
            {
                for (var c = 0; c < 3; c++)
                {
                    if (board[r, c] == ' ') result = false;
                }
            }

            return result;
        }
        private static void DisplayBoard()
        {
            Console.WriteLine("    " + board[0, 0] + "|" + board[0, 1] + "|" + board[0, 2]);
            Console.WriteLine("    -+-+-");
            Console.WriteLine("    " + board[1, 0] + "|" + board[1, 1] + "|" + board[1, 2]);
            Console.WriteLine("    -+-+-");
            Console.WriteLine("    " + board[2, 0] + "|" + board[2, 1] + "|" + board[2, 2]);
            Console.WriteLine("    -+-+-");
        }
    }
}
