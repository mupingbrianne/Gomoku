using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Gomoku
{
    abstract class Piece : PictureBox
    {
        private static readonly int ImageWidth = 50;
        public Piece(int x, int y)
        {
            this.BackColor = Color.Transparent;
            this.Location = new Point(x - ImageWidth / 2, y - ImageWidth / 2);
            this.Size = new Size(ImageWidth, ImageWidth);
        }
        public abstract PieceType GetPieceType();
    }
}
