using CwordCommon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CwordCommon
{
    public class Drawer
    {
        public const int CUBE_LEN = 25;
        Project project;
        Panel drawPanel;
        Graphics graphics;
        Bitmap buffer;
        int cols = 25;
        int rows = 25;
        

        public DrawMode drawMode = DrawMode.View;
        
        private struct CellInfo
        {
            public Cell cell;
            public int row;
            public int col;
            public int offsetX;
            public int offsetY;
            public bool isStartHorizontalCell;
            public bool isStartVerticalCell;
            public bool existHorizontal;
            public bool existVertical;
            public string letter;
            public string answerLetter;
            public ElementCellsInfo horizontalElementCellsInfo;
            public ElementCellsInfo verticalElementCellsInfo;

        }

        public enum DrawMode
        {
            Decision,
            View,
            Errors
        }



        public Drawer(Project project, Panel drawPanel, int rows, int cols)
        {
            this.project = project;
            this.rows = rows;
            this.cols = cols;
            this.drawPanel = drawPanel;

            buffer = new Bitmap(cols * CUBE_LEN + 10, rows * CUBE_LEN + 10);
            graphics = Graphics.FromImage(buffer);

            drawPanel.Paint += (sender, e) => FastDrawBuffered(e.Graphics);
        }

        public void FastClear()
        {
            graphics.Clear(SystemColors.Control);
            FastDrawBuffered();
        }

        public void FastDrawBuffered(Graphics drawTo = null)
        {
            var mainGraphics = drawTo ?? drawPanel.CreateGraphics();
            mainGraphics.DrawImage(buffer, 0, 0);
        }

        public void Draw()
        {
            graphics.Clear(SystemColors.Control);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    var cell = project.table.Get(row, col);
                    var nf = new CellInfo();

                    nf.cell = cell;
                    nf.col = col;
                    nf.row = row;
                    nf.offsetX = CUBE_LEN * col + 10;
                    nf.offsetY = CUBE_LEN * row + 10;
                    nf.letter = cell.letter.ToString();
                    nf.answerLetter = cell.answerLetter.ToString();
                    nf.existHorizontal = cell.horizontalElement != null;
                    nf.existVertical = cell.verticalElement != null;

                    nf.isStartHorizontalCell = false;
                    nf.isStartVerticalCell = false;
                    if (nf.existHorizontal)
                    {
                        nf.horizontalElementCellsInfo = project.table.GetElementCellsInfo(cell.horizontalElement);
                        nf.isStartHorizontalCell = nf.horizontalElementCellsInfo.GetStartCell() == cell;
                    }
                    if (nf.existVertical)
                    {
                        nf.verticalElementCellsInfo = project.table.GetElementCellsInfo(cell.verticalElement);
                        nf.isStartVerticalCell = nf.verticalElementCellsInfo.GetStartCell() == cell;
                    }

                    DrawArrowsForCell(nf);
                    DrawCubeForCell(nf);
                    DrawNumbersForCell(nf);
                    DrawLettersForCell(nf);
                    DrawSelectedCell(nf);

                }
            }

            FastDrawBuffered();
        }

        Pen arrowPen = new Pen(Color.Gray, 1);
        private void DrawArrowsForCell(CellInfo nf)
        {
            int hpX = 26;
            int hpY = 2;
            int vpX = 2;
            int vpY = 26;

            if (nf.isStartHorizontalCell)
            {
                graphics.DrawLine(arrowPen, nf.offsetX + hpX - 3, nf.offsetY + hpY + 2, nf.offsetX + hpX + 15, nf.offsetY + hpY + 2);
                graphics.DrawLine(arrowPen, nf.offsetX + hpX + 8, nf.offsetY + hpY, nf.offsetX + hpX + 15, nf.offsetY + hpY + 2);
                graphics.DrawLine(arrowPen, nf.offsetX + hpX + 8, nf.offsetY + hpY + 4, nf.offsetX + hpX + 15, nf.offsetY + hpY + 2);
            }

            if (nf.isStartVerticalCell)
            {
                graphics.DrawLine(arrowPen, nf.offsetX + vpX + 2, nf.offsetY + vpY - 3, nf.offsetX + vpX + 2, nf.offsetY + vpY + 15);
                graphics.DrawLine(arrowPen, nf.offsetX + vpX, nf.offsetY + vpY + 8, nf.offsetX + vpX + 2, nf.offsetY + vpY + 15);
                graphics.DrawLine(arrowPen, nf.offsetX + vpX + 4, nf.offsetY + vpY + 8, nf.offsetX + vpX + 2, nf.offsetY + vpY + 15);
            }
        }

        Pen cubePen = new Pen(Color.Black, 1);
        private void DrawCubeForCell(CellInfo nf)
        {
            if (nf.letter != " ")
                graphics.DrawRectangle(cubePen, nf.offsetX, nf.offsetY, CUBE_LEN, CUBE_LEN);
        }

        Font numberFont = new Font(FontFamily.GenericSansSerif, 6);
        Brush horizontalNumberBrush = new SolidBrush(Color.Red);
        Brush verticalNumberBrush = new SolidBrush(Color.Green);
        private void DrawNumbersForCell(CellInfo nf)
        {
            if(nf.isStartHorizontalCell)
                graphics.DrawString(nf.cell.horizontalElement.number.ToString(), numberFont, horizontalNumberBrush, nf.offsetX + 14, nf.offsetY + 1);

            if (nf.isStartVerticalCell)
                graphics.DrawString(nf.cell.verticalElement.number.ToString(), numberFont, verticalNumberBrush, nf.offsetX + 1, nf.offsetY + 14);
        }

        Font letterBigFont = new Font(FontFamily.GenericSansSerif, 10);
        //Font letterMediumFont = new Font(FontFamily.GenericSansSerif, 8);
        Font letterSmallFont = new Font(FontFamily.GenericSansSerif, 9);
        Brush letterGreenBrush = new SolidBrush(Color.Green);
        Brush letterRedBrush = new SolidBrush(Color.Red);
        Brush letterBlueBrush = new SolidBrush(Color.Blue);
        private void DrawLettersForCell(CellInfo nf)
        {
            if (drawMode == DrawMode.View)
            {
                if (nf.letter == " ") return;
                graphics.DrawString(nf.letter, letterBigFont, letterBlueBrush, nf.offsetX + 6, nf.offsetY + 3);
            }

            if (drawMode == DrawMode.Decision)
            {
                if (nf.answerLetter == " ") return;
                graphics.DrawString(nf.answerLetter, letterBigFont, letterBlueBrush, nf.offsetX + 6, nf.offsetY + 3);
            }

            if (drawMode == DrawMode.Errors)
            {
                if (nf.letter == " ") return;

                if (nf.letter == nf.answerLetter)
                {
                    graphics.DrawString(nf.letter, letterBigFont, letterBlueBrush, nf.offsetX + 6, nf.offsetY + 3);
                }

                if (nf.letter != nf.answerLetter && nf.answerLetter != " ")
                {
                    graphics.DrawString(nf.letter, letterSmallFont, letterRedBrush, nf.offsetX + 1, nf.offsetY - 3);
                    graphics.DrawString(nf.answerLetter, letterBigFont, letterBlueBrush, nf.offsetX + 7, nf.offsetY + 4);
                }

                if (nf.letter != nf.answerLetter && nf.answerLetter == " ")
                {
                    graphics.DrawString(nf.letter, letterBigFont, letterRedBrush, nf.offsetX + 6, nf.offsetY + 3);
                }
            }
        }

        Pen selectedCellPen = new Pen(Color.Black, 2);
        private void DrawSelectedCell(CellInfo nf)
        {
            if (project.selectedCell != null && project.selectedCell.col == nf.col && project.selectedCell.row == nf.row)
                graphics.DrawRectangle(selectedCellPen, nf.offsetX, nf.offsetY, CUBE_LEN + 1, CUBE_LEN + 1);
        }


    }
}
