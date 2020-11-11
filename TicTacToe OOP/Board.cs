using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe_OOP
{
    class Board
    {
        public List<BoardPiece> BoardPieces = new List<BoardPiece> {};
        public Board()
        {
            IntBoard();
            FormBoard();
        }
        public void IntBoard() //sætter værdierne i mit array til at være 0
        {

            for (int i = 1; i < 10; i++)
            {
                BoardPieces.Add(new BoardPiece(" "));             
            }
        }
        public void FormBoard()
        {
            int space = 1;
            foreach (var item in BoardPieces)
            {
                Console.Write(" " + item.Sign + " | ");
                if (space % 3 == 0)
                {
                    Console.WriteLine();
                }
                space++;
            }            
        }
    }
}
