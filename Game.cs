using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Game
    {
        public Board board = new Board();
        private PieceType currentPlayer= PieceType.Black;
        private PieceType winner = PieceType.None;
        public PieceType Winner { get { return winner; } }
        public bool CanBePlaced(int x ,int y)
        {
            return board.CanBePlaced(x, y);
        }
        public Piece PlaceAPiece(int x, int y)
        {
            Piece piece = board.PlaceAPiece(x, y,currentPlayer);
            if (piece != null)
            {
                CheckWinner();
                if (currentPlayer == PieceType.Black)
                {
                    currentPlayer = PieceType.White;
                }
                else if (currentPlayer== PieceType.White)
                {
                    currentPlayer = PieceType.Black;

                }
                return piece;

            }
            return null;
        }
        private void CheckWinner()
        {
            int placedXId = board.LastPlacedNode.X;
            int placedYId = board.LastPlacedNode.Y;
            for (int xDir = -1; xDir <= 1; xDir++)
            {
                for (int yDir = -1; yDir <=1; yDir++)
                {
                    if (xDir==0&&yDir==0)
                    {
                        continue;
                    }
                    int countR= 1;
                    while (countR<5)
                    {
                        int adjcentX = placedXId + countR * xDir;
                        int adjcentY = placedYId + countR * yDir;
                        if (adjcentX<0||adjcentX>=9||
                            adjcentY<0||adjcentY>=9||
                            board.GetPieceType(adjcentX,adjcentY)!=currentPlayer)
                        {
                            break;
                        }
                        countR++;
                    }
                    int countL = 1;
                    while (countL+countR <= 5)
                    {
                        int adjcentX = placedXId-countL * xDir;
                        int adjcentY = placedYId-countL * yDir;
                        if (adjcentX < 0 || adjcentX >= 9 ||
                            adjcentY < 0 || adjcentY >= 9 ||
                            board.GetPieceType(adjcentX, adjcentY) != currentPlayer)
                        {
                            break;
                        }
                        countL++;
                    }
                    if (countL+countR>=6)
                    {
                        winner = currentPlayer;
                    }
                }

            }
        }
    }
}
