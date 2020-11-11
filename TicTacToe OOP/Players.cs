using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe_OOP
{
    class Player
    {
        public string Playername;
        public string Piece;
        
        public Player(string piece, string name)
        {
            Playername = name;
            Piece = piece;
        }
    }
}
