using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Board
    {
        private static readonly int OffSet = 75;
        private static readonly int NodeRadius = 10;
        private static readonly int NodeDistance = 75;
        private static readonly Point NoMatchNode = new Point(-1, -1);
        private Point lastPlacedNode = NoMatchNode;
        public Point LastPlacedNode { get { return lastPlacedNode; } }
        public Piece[,] pieces = new Piece[9, 9];


        public bool CanBePlaced(int x, int y)
        {
            Point nodeId = FindTheClosestNode(x, y);
            if (nodeId == NoMatchNode)
            {
                return false;
            }
            return true;
        }
        public Piece PlaceAPiece(int x, int y, PieceType pieceType)
        {
            Point nodeId = FindTheClosestNode(x, y);
            if (nodeId == NoMatchNode)
            {
                return null;
            }
            if (pieces[nodeId.X, nodeId.Y] != null)
            {

                return null;

            }
            Point point = ConverToFormPosition(nodeId);
            if (pieceType == PieceType.Black)
            {
                pieces[nodeId.X, nodeId.Y] = new BlackPiece(point.X, point.Y);
            }
            else if (pieceType == PieceType.White)
            {
                pieces[nodeId.X, nodeId.Y] = new WhitePiece(point.X, point.Y);
            }
            lastPlacedNode = nodeId;
            return pieces[nodeId.X, nodeId.Y];
        }
        private Point ConverToFormPosition(Point point)
        {
            Point formPosition = new Point();
            formPosition.X = point.X * NodeDistance + OffSet;
            formPosition.Y = point.Y * NodeDistance + OffSet;
            return formPosition;
        }

        private Point FindTheClosestNode(int x, int y)
        {
            int nodeIdX = FindTheClosestNode(x);

            if (nodeIdX == -1)
            {
                return NoMatchNode;
            }
            int nodeIdY = FindTheClosestNode(y);
            if (nodeIdY == -1)
            {
                return NoMatchNode;
            }
            return new Point(nodeIdX, nodeIdY);
        }
        private int FindTheClosestNode(int pos)
        {
            if (pos < OffSet - NodeRadius)
            {
                return -1;
            }
            pos -= OffSet;
            int quotient = pos / NodeDistance;
            int reminder = pos % NodeDistance;
            if (reminder <= NodeRadius)
            {
                return quotient;
            }
            else if (reminder >= NodeDistance - NodeRadius)
            {
                return quotient + 1;
            }
            else
            {
                return -1;
            }
        }
        public PieceType GetPieceType(int nodeIdX, int nodeIdY)
        {
            if (pieces[nodeIdX, nodeIdY] == null)
            {
                return PieceType.None;
            }
            else
            {
                return pieces[nodeIdX, nodeIdY].GetPieceType();
            }

        }
    }
}
