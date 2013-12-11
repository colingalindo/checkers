using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersBoard
{
    class Move
    {
        public Piece piece1 { get; set; }
        public Piece piece2 { get; set; }

        public Move()
        {
            this.piece1 = null;
            this.piece2 = null;
        }

        public Move(Piece piece1, Piece piece2)
        {
            this.piece1 = piece1;
            this.piece2 = piece2;
        }

        public bool isAdjacent(string color)
        {
            if (color == "Black")
            {
                if ((piece1.Row - 1 == piece2.Row) && (piece1.Column - 1 == piece2.Column))
                    return true;
                if ((piece1.Row - 1 == piece2.Row) && (piece1.Column + 1 == piece2.Column))
                    return true;
            }
            if (color == "Red")
            {
                if ((piece1.Row + 1 == piece2.Row) && (piece1.Column - 1 == piece2.Column))
                    return true;
                if ((piece1.Row + 1 == piece2.Row) && (piece1.Column + 1 == piece2.Column))
                    return true;
            }
            if (color == "King")
            {
                if ((piece1.Row - 1 == piece2.Row) && (piece1.Column - 1 == piece2.Column))
                    return true;
                if ((piece1.Row - 1 == piece2.Row) && (piece1.Column + 1 == piece2.Column))
                    return true;
                if ((piece1.Row + 1 == piece2.Row) && (piece1.Column - 1 == piece2.Column))
                    return true;
                if ((piece1.Row + 1 == piece2.Row) && (piece1.Column + 1 == piece2.Column))
                    return true;
            }
            return false;
        }

        public Piece checkJump(string color)
        {
            if (color == "Black")
            {
                if ((piece1.Row - 2 == piece2.Row) && (piece1.Column - 2 == piece2.Column))
                    return new Piece(piece1.Row - 1, piece1.Column - 1);
                if ((piece1.Row - 2 == piece2.Row) && (piece1.Column + 2 == piece2.Column))
                    return new Piece(piece1.Row - 1, piece1.Column + 1);
            }
            if (color == "Red")
            {
                if ((piece1.Row + 2 == piece2.Row) && (piece1.Column - 2 == piece2.Column))
                    return new Piece(piece1.Row + 1, piece1.Column - 1);
                if ((piece1.Row + 2 == piece2.Row) && (piece1.Column + 2 == piece2.Column))
                    return new Piece(piece1.Row + 1, piece1.Column + 1);
            }
            if (color == "King")
            {
                if ((piece1.Row - 2 == piece2.Row) && (piece1.Column - 2 == piece2.Column))
                    return new Piece(piece1.Row - 1, piece1.Column - 1);
                if ((piece1.Row - 2 == piece2.Row) && (piece1.Column + 2 == piece2.Column))
                    return new Piece(piece1.Row - 1, piece1.Column + 1);
                if ((piece1.Row + 2 == piece2.Row) && (piece1.Column - 2 == piece2.Column))
                    return new Piece(piece1.Row + 1, piece1.Column - 1);
                if ((piece1.Row + 2 == piece2.Row) && (piece1.Column + 2 == piece2.Column))
                    return new Piece(piece1.Row + 1, piece1.Column + 1);
            }

            return null;
        }

        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Move move = obj as Move;
            if ((System.Object)move == null)
            {
                return false;
            }

            return piece1.Equals(move.piece1) && piece2.Equals(move.piece2);
        }
    }
}
