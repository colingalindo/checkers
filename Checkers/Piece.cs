using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersBoard
{
    class Piece
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Piece(int row, int col)
        {
            this.Row = row;
            this.Column = col;
        }

        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Piece piece = obj as Piece;
            if ((System.Object)piece == null)
            {
                return false;
            }

            return Row == piece.Row && Column == piece.Column;
        }
    }
}
