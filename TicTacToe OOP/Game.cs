using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TicTacToe_OOP
{
    class Game
    {

        List<Player> Players = new List<Player>();
        List<GamePiece> X_or_O = new List<GamePiece>();
        Board PlayBoard = new Board();
        public int Turns = 0;
        public int CurrentlyActivePlayer = 0;
        public bool GameOver = false;
        public Game()
        {
            Run();
        }

        private void Run()
        {
            Console.WriteLine("Welcome to the game TicTacToe, Please enter the name of the players to begin!\n");
            GeneratePlayers();
            
            while (GameOver == false)
            {
                PlayOneRound();
                if (GameOver == true)
                {

                    break;
          
                }
                else { 
                }
            }
        }
        public bool PlayOneRound()
        {
            Turns++;
            PlayBoard.FormBoard();
            Console.WriteLine("The board is played by using the numbers 1-9 as shown here" +
                "\n 1 | 2 | 3 |" +
                "\n 4 | 5 | 6 |" +
                "\n 7 | 8 | 9 |");
            Console.WriteLine("\n" + Players[CurrentlyActivePlayer].Playername);
            Console.Write("Please enter a Number on the board: ");
            
            int.TryParse(Console.ReadLine(), out int space);

            Console.Clear();

            while (!Judge(space))
            {
                PlayBoard.FormBoard();
                Console.WriteLine("The board is played by using the numbers 1-9 as shown here" +
                "\n 1 | 2 | 3 |" +
                "\n 4 | 5 | 6 |" +
                "\n 7 | 8 | 9 |");
                Console.WriteLine("\nTry again you entered not a valid cordinate");
                Console.Write(Players[CurrentlyActivePlayer].Playername + " Please enter a new Row value: ");
                int.TryParse(Console.ReadLine(), out space);

                Console.Clear();

            }
            
                PlayBoard.BoardPieces[space - 1].Sign = Players[CurrentlyActivePlayer].Piece;

            if (win())
            {
                Turns = 0;
                Console.WriteLine("congratulations " + Players[CurrentlyActivePlayer].Playername + ". you win");
                Console.WriteLine("do you want to play another round? [y]es [N]o");
                var playAgain = Console.ReadKey().KeyChar;
                switch (playAgain)
                {
                    case 'y':
                        {
                            this.GameOver = false;
                            PlayBoard.BoardPieces.Clear();
                            PlayBoard.IntBoard();


                            break;


                        }
                    case 'n':
                        {
                            this.GameOver = true;

                            break;
                        }
                        
                }
            }
            if (draw())
            {
                Console.WriteLine("It's a draw");
                Console.WriteLine("do you want to play another round? [y]es [N]o");
                var playAgain = Console.ReadKey().KeyChar;
                switch (playAgain)
                {
                    case 'y':
                        {
                            this.GameOver = false;
                            PlayBoard.BoardPieces.Clear();
                            PlayBoard.IntBoard();

                            break;
                        }
                    case 'n':
                        {
                            this.GameOver = true;

                            break;
                        }
                }
            }
            Console.Clear();
            ChangeActivePlayer();

            return false;
        }
        private bool Judge(int space) // tjekker om inputtet er korrekt iforhold til spillepladen
        {

            if (space > 9 || space < 1)
            {
                return false;
            }
            else if (PlayBoard.BoardPieces[space - 1].Sign == Players[0].Piece)
            {
                return false;
            }
            else if (PlayBoard.BoardPieces[space - 1].Sign == Players[1].Piece)
            {
                return false;
            }
            else

                return true;
        }

        private void ChangeActivePlayer()
        {
            if (CurrentlyActivePlayer == 0)
            {
                CurrentlyActivePlayer = 1;
            }
            else
            {
                CurrentlyActivePlayer = 0;
            }
        }

        private void GeneratePlayers()
        {
            GeneratePieces();
            string playerName;
            Random rnd = new Random();

            Console.Write("Enter a name for player 1: ");
            playerName = Console.ReadLine();
            int index = rnd.Next(0, 2);
            Players.Add(new Player(X_or_O[index].Sign, playerName));

            Console.Write("Enter a name for player 2: ");
            playerName = Console.ReadLine();

            Players.Add(new Player(X_or_O[index == 0 ? 1 : 0].Sign, playerName));

            foreach (var item in Players)
            {
                Console.WriteLine(item.Piece + " " + item.Playername);
            }

            Console.Clear();
        }
        

        public void GeneratePieces()
        {
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    string o = "o";
                    GamePiece Opiece = new GamePiece(o);
                    X_or_O.Add(new GamePiece(Opiece.Sign));
                }
                else if (i == 1)
                {
                    string x = "x";
                    GamePiece Xpiece = new GamePiece(x);

                    X_or_O.Add(new GamePiece(Xpiece.Sign));
                }
            }
        }
        private bool draw() //kriterier for at være uafgjort
        {


            if (Turns == 9)
            {
                return true;
            }

            return false; 

        }
        private bool win() //kriterier for at vind
        {
            if (PlayBoard.BoardPieces[0].Sign == Players[CurrentlyActivePlayer].Piece && PlayBoard.BoardPieces[1].Sign == Players[CurrentlyActivePlayer].Piece && PlayBoard.BoardPieces[2].Sign == Players[CurrentlyActivePlayer].Piece)
            {
                return true;
            }
            else if (PlayBoard.BoardPieces[3].Sign == Players[CurrentlyActivePlayer].Piece && PlayBoard.BoardPieces[4].Sign == Players[CurrentlyActivePlayer].Piece && PlayBoard.BoardPieces[5].Sign == Players[CurrentlyActivePlayer].Piece)
            {
                return true;
            }
            else if (PlayBoard.BoardPieces[6].Sign == Players[CurrentlyActivePlayer].Piece && PlayBoard.BoardPieces[7].Sign == Players[CurrentlyActivePlayer].Piece && PlayBoard.BoardPieces[8].Sign == Players[CurrentlyActivePlayer].Piece)
            {
                return true;
            }
            else if (PlayBoard.BoardPieces[0].Sign == Players[CurrentlyActivePlayer].Piece && PlayBoard.BoardPieces[3].Sign == Players[CurrentlyActivePlayer].Piece && PlayBoard.BoardPieces[6].Sign == Players[CurrentlyActivePlayer].Piece)
            {
                return true;

            }
            else if (PlayBoard.BoardPieces[1].Sign == Players[CurrentlyActivePlayer].Piece && PlayBoard.BoardPieces[4].Sign == Players[CurrentlyActivePlayer].Piece && PlayBoard.BoardPieces[7].Sign == Players[CurrentlyActivePlayer].Piece)
            {
                return true;
            }
            else if (PlayBoard.BoardPieces[2].Sign == Players[CurrentlyActivePlayer].Piece && PlayBoard.BoardPieces[5].Sign == Players[CurrentlyActivePlayer].Piece && PlayBoard.BoardPieces[8].Sign == Players[CurrentlyActivePlayer].Piece)
            {
                return true;
            }
            else if (PlayBoard.BoardPieces[0].Sign == Players[CurrentlyActivePlayer].Piece && PlayBoard.BoardPieces[4].Sign == Players[CurrentlyActivePlayer].Piece && PlayBoard.BoardPieces[8].Sign == Players[CurrentlyActivePlayer].Piece)
            {
                return true;
            }
            else if (PlayBoard.BoardPieces[2].Sign == Players[CurrentlyActivePlayer].Piece && PlayBoard.BoardPieces[4].Sign == Players[CurrentlyActivePlayer].Piece && PlayBoard.BoardPieces[6].Sign == Players[CurrentlyActivePlayer].Piece)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}


