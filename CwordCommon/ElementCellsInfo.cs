﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwordCommon
{
    public class ElementCellsInfo
    {
        private List<Cell> cells;

        private Element element;

        public List<Cell> Cells => cells;

        public Cell GetStartCell()
        {
            return cells[0];
        }

        public Cell GetEndCell()
        {
            return cells[cells.Count - 1];
        }

        public Aligment GetAligment()
        {
            return GetStartCell().GetAligmentForElement(element);
        }

        public ElementCellsInfo(List<Cell> cells, Element element)
        {
            this.cells = cells;
        }
    }
}
