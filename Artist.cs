using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace DunGen {
    class Artist {
        // ---------------- ---------------- ---------------- ---------------- //
        public Bitmap canvas;
        private readonly int TWide;
        private readonly int THigh;
        private readonly int TSize;
        private SolidBrush sb, nb;
        // ---------------- ---------------- ---------------- ---------------- //
        public Artist(int TilesWide, int TilesHigh, int TileSize) {
            this.TWide = TilesWide;
            this.THigh = TilesHigh;
            this.TSize = TileSize;
            // Create enough space for tiles and borders
            this.canvas = new Bitmap(
                TilesWide * TileSize + (1 + TilesWide),
                TilesHigh * TileSize + (1 + TilesHigh));
            CreateGrid();
            this.sb = new SolidBrush(Color.FromArgb(150, Color.Gray));
            this.nb = new SolidBrush(Color.FromArgb(150, Color.White));
        }
        // ---------------- ---------------- ---------------- ---------------- //
        private void CreateGrid() {
            Pen p = new Pen(Color.Black);
            using (Graphics g = Graphics.FromImage(canvas)) {
                // Draw the vertical, then the horizontal lines.
                for (int i = 0; i <= TWide; i++) g.DrawLine(p, i + TSize * i, 0, i + TSize * i, canvas.Height - 1);
                for (int i = 0; i <= THigh; i++) g.DrawLine(p, 0, i + TSize * i, canvas.Width - 1, i + TSize * i);
            }
        }
        // ---------------- ---------------- ---------------- ---------------- //
        public void ColorRoom(Room room, int brush) {
            if (brush == 0) ColorRegion(room.West, room.North, room.East, room.South, nb);
            else ColorRegion(room.West, room.North, room.East, room.South, sb);
        }
        // ---------------- ---------------- ---------------- ---------------- //
        public Color GetTileColor(int xpos, int ypos) { return canvas.GetPixel((TSize + 1) * xpos + 1, (TSize + 1) * ypos + 1); }
        // ---------------- ---------------- ---------------- ---------------- //
        public void SaveDun(string Path) { this.canvas.Save(Path); }
        // ---------------- ---------------- ---------------- ---------------- //
        public void ColorRegion(int x1, int y1, int x2, int y2, Brush brush) {
            for (int i = x1; i <= x2; i++) {
                for (int j = y1; j <= y2; j++) {
                    ColorTile(i, j, brush);
                }
            }
        }
        // ---------------- ---------------- ---------------- ---------------- //
        public void ColorTile(int xpos, int ypos, Brush brush) {
            if (xpos < 0 || xpos > TWide || ypos < 0 || ypos > THigh) throw new IndexOutOfRangeException("Index is out of range!");
            using (Graphics g = Graphics.FromImage(canvas)) {
                Rectangle r = new Rectangle((TSize + 1) * xpos + 1, (TSize + 1) * ypos + 1, TSize, TSize);
                g.FillRectangle(brush, r);
            }
        }
        // ---------------- ---------------- ---------------- ---------------- //
    } // End of class
} // End of namespace