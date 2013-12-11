using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersBoard
{
    class CheckersAI
    {
        public static Move GetMove(CheckerBoard currentBoard)
        {
            List<Move> avaliableMoves = GetAvaliableMoves(currentBoard);
            avaliableMoves.Shuffle();
            if (avaliableMoves.Count < 1)
                return null;
            return avaliableMoves[0];
        }

        private static List<Move> GetAvaliableMoves(CheckerBoard currentBoard)
        {
            List<Piece> currentPieces = new List<Piece>();
            List<Move> avaliableMoves = new List<Move>();
            List<Move> jumpMoves = currentBoard.checkJumps("Red");
            if (jumpMoves.Count > 0)
            {
                return jumpMoves;
            }
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if ((currentBoard.GetState(r, c) == 1) || (currentBoard.GetState(r, c) == 3))
                    {
                        currentPieces.Add(new Piece(r, c));
                    }
                }
            }
            foreach (Piece p in currentPieces)
            {
                avaliableMoves.AddRange(CheckForMoves(p, currentBoard));
            }
            return avaliableMoves;
        }

        private static List<Move> CheckForMoves(Piece piece, CheckerBoard currentBoard)
        {
            List<Move> moves = new List<Move>();
            if (currentBoard.GetState(piece.Row, piece.Column) == 3)
            {
                if ((currentBoard.GetState(piece.Row - 1, piece.Column - 1) == 2) || (currentBoard.GetState(piece.Row - 1, piece.Column - 1) == 4))
                {
                    if(currentBoard.GetState(piece.Row - 2, piece.Column - 2) == 0)
                        moves.Add(new Move(new Piece(piece.Row + 1, piece.Column), new Piece(piece.Row - 1, piece.Column - 2)));
                }
                if ((currentBoard.GetState(piece.Row - 1, piece.Column + 1) == 2) || (currentBoard.GetState(piece.Row - 1, piece.Column + 1) == 4))
                {
                    if (currentBoard.GetState(piece.Row - 2, piece.Column + 2) == 0)
                        moves.Add(new Move(new Piece(piece.Row + 1, piece.Column), new Piece(piece.Row - 1, piece.Column + 2)));
                }
                if ((currentBoard.GetState(piece.Row + 1, piece.Column - 1) == 2) || (currentBoard.GetState(piece.Row + 1, piece.Column - 1) == 4))
                {
                    if (currentBoard.GetState(piece.Row + 2, piece.Column - 2) == 0)
                        moves.Add(new Move(new Piece(piece.Row + 1, piece.Column), new Piece(piece.Row + 3, piece.Column - 2)));
                }
                if ((currentBoard.GetState(piece.Row + 1, piece.Column + 1) == 2) || (currentBoard.GetState(piece.Row + 1, piece.Column + 1) == 4))
                {
                    if (currentBoard.GetState(piece.Row + 2, piece.Column + 2) == 0)
                        moves.Add(new Move(new Piece(piece.Row + 1, piece.Column), new Piece(piece.Row + 3, piece.Column + 2)));
                }
                if (currentBoard.GetState(piece.Row - 1, piece.Column - 1) == 0)
                    moves.Add(new Move(new Piece(piece.Row + 1, piece.Column), new Piece(piece.Row, piece.Column - 1)));
                if (currentBoard.GetState(piece.Row - 1, piece.Column + 1) == 0)
                    moves.Add(new Move(new Piece(piece.Row + 1, piece.Column), new Piece(piece.Row, piece.Column + 1)));
                if (currentBoard.GetState(piece.Row + 1, piece.Column - 1) == 0)
                    moves.Add(new Move(new Piece(piece.Row + 1, piece.Column), new Piece(piece.Row + 2, piece.Column - 1)));
                if (currentBoard.GetState(piece.Row + 1, piece.Column + 1) == 0)
                    moves.Add(new Move(new Piece(piece.Row + 1, piece.Column), new Piece(piece.Row + 2, piece.Column + 1)));
            }
            else if (currentBoard.GetState(piece.Row, piece.Column) == 1)
            {
                if ((currentBoard.GetState(piece.Row + 1, piece.Column - 1) == 2) || (currentBoard.GetState(piece.Row + 1, piece.Column - 1) == 4))
                {
                    if (currentBoard.GetState(piece.Row + 2, piece.Column - 2) == 0)
                        moves.Add(new Move(new Piece(piece.Row + 1, piece.Column), new Piece(piece.Row + 3, piece.Column - 2)));
                }
                if ((currentBoard.GetState(piece.Row + 1, piece.Column + 1) == 2) || (currentBoard.GetState(piece.Row + 1, piece.Column + 1) == 4))
                {
                    if (currentBoard.GetState(piece.Row + 2, piece.Column + 2) == 0)
                        moves.Add(new Move(new Piece(piece.Row + 1, piece.Column), new Piece(piece.Row + 3, piece.Column + 2)));
                }
                if (currentBoard.GetState(piece.Row + 1, piece.Column - 1) == 0)
                    moves.Add(new Move(new Piece(piece.Row + 1, piece.Column), new Piece(piece.Row + 2, piece.Column - 1)));
                if (currentBoard.GetState(piece.Row + 1, piece.Column + 1) == 0)
                    moves.Add(new Move(new Piece(piece.Row + 1, piece.Column), new Piece(piece.Row + 2, piece.Column + 1)));
            }
            return moves;
        }

    }
}
