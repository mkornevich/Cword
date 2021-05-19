using CwordCommon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CwordBuilder
{
    class Drawer
    {

        Table table;

        Graphics graphics;

        int cols = 25;

        int rows = 25;

        int cubeLen = 25;

        public Drawer(Table table, Graphics graphics, int rows, int cols)
        {
            this.table = table;
            this.graphics = graphics;
            this.rows = rows;
            this.cols = cols;
        }

        public void Clear()
        {
            graphics.Clear(SystemColors.Control);
        }

        public void Draw()
        {
            Clear();            

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    DrawCell(table.Get(row, col));
                }
            }

        }

        Pen blackPen = new Pen(Color.Black, 1);
        Pen grayPen = new Pen(Color.Gray, 1);

        Font font = new Font(FontFamily.GenericSansSerif, 10);

        Brush brush = new SolidBrush(Color.Blue);

        Font horizontalFont = new Font(FontFamily.GenericSansSerif, 6);
        Brush horizontalBrush = new SolidBrush(Color.Red);

        Font verticalFont = new Font(FontFamily.GenericSansSerif, 6);
        Brush verticalBrush = new SolidBrush(Color.Green);

        private void DrawCell(Cell cell)
        {
            int offsetY = cubeLen * cell.Pos.row + 10;
            int offsetX = cubeLen * cell.Pos.col + 10;
            int hpX = 26;
            int hpY = 2;
            int vpX = 2;
            int vpY = 26;
            string letter = cell.letter.ToString();

            bool isStartCell = false;

            if (letter != " ")
            {

                if (cell.horizontalElement != null)
                {
                    var elementCellsInfo = table.GetElementCellsInfo(cell.horizontalElement);
                    var startCell = elementCellsInfo.GetStartCell();
                    if (cell == startCell)
                    {
                        graphics.DrawString(cell.horizontalElement.number.ToString(), horizontalFont, horizontalBrush, offsetX + 14, offsetY + 1);
                        graphics.DrawLine(grayPen, offsetX + hpX - 3, offsetY + hpY + 2, offsetX + hpX + 15, offsetY + hpY + 2);
                        graphics.DrawLine(grayPen, offsetX + hpX + 8, offsetY + hpY, offsetX + hpX + 15, offsetY + hpY + 2);
                        graphics.DrawLine(grayPen, offsetX + hpX + 8, offsetY + hpY + 4, offsetX + hpX + 15, offsetY + hpY + 2);
                        isStartCell = true;
                    }
                }

                if (cell.verticalElement != null)
                {
                    var elementCellsInfo = table.GetElementCellsInfo(cell.verticalElement);
                    var startCell = elementCellsInfo.GetStartCell();
                    if (cell == startCell)
                    {
                        graphics.DrawString(cell.verticalElement.number.ToString(), verticalFont, verticalBrush, offsetX + 1, offsetY + 14);
                        graphics.DrawLine(grayPen, offsetX + vpX + 2, offsetY + vpY - 3, offsetX + vpX + 2, offsetY + vpY + 15);
                        graphics.DrawLine(grayPen, offsetX + vpX, offsetY + vpY + 8, offsetX + vpX + 2, offsetY + vpY + 15);
                        graphics.DrawLine(grayPen, offsetX + vpX + 4, offsetY + vpY + 8, offsetX + vpX + 2, offsetY + vpY + 15);
                        isStartCell = true;
                    }
                }

                graphics.DrawRectangle(blackPen, offsetX, offsetY, cubeLen, cubeLen);

                if(isStartCell)
                    graphics.DrawString(cell.letter.ToString(), font, brush, offsetX + 8, offsetY + 5);
                else
                    graphics.DrawString(cell.letter.ToString(), font, brush, offsetX + 6, offsetY + 3);

            }

        }

    }
}
