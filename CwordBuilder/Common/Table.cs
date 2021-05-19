using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cword.Generator.Common
{
    class Table
    {
        public int cols;

        public int rows;

        private Cell[,] container;

        public Table(int rows, int cols)
        {
            MakeContainer(rows, cols);
        }

        public void MakeContainer(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            container = new Cell[rows, cols];
        }

        private Cell MakeEmptyCell(Pos pos)
        {
            return new Cell(pos);
        }

        public Cell Get(Pos pos)
        {
            if (container[pos.row, pos.col] == null)
                container[pos.row, pos.col] = MakeEmptyCell(pos);
            return container[pos.row, pos.col];
        }

        public Cell Get(int row, int col)
        {
            return Get(new Pos(row, col));
        }

        public void Set(Cell cell, int row, int col)
        {
            container[row, col] = cell;
        }

        public void Clear()
        {
            container = new Cell[rows, cols];
        }

        public ElementCellsInfo GetElementCellsInfo(Element element)
        {
            Cell startCell = null;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    var currCell = Get(row, col);
                    if (currCell.letter == ' ') continue;
                    if (currCell.horizontalElement == element || currCell.verticalElement == element)
                    {
                        startCell = currCell;
                        goto LoopEnd;
                    }
                }
            }

            LoopEnd:

            if (startCell == null)
            {
                throw new Exception("Cells for need element not found");
            }

            var aligment = startCell.GetAligmentForElement(element);
            
            var cells = new List<Cell>();

            if (aligment == Aligment.Horizontal)
            {
                int row = startCell.Pos.row;
                for (int col = startCell.Pos.col; col < startCell.Pos.col + element.word.Length; col++)
                {
                    cells.Add(Get(row, col));
                }
            }
            else // Aligment.Vertical
            {
                int col = startCell.Pos.col;
                for (int row = startCell.Pos.row; row < startCell.Pos.row + element.word.Length; row++)
                {
                    cells.Add(Get(row, col));
                }
            }

            return new ElementCellsInfo(cells, element);

        }

    }
}
