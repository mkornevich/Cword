using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cword.Generator.Common
{
    class Cell
    {

        public char letter = ' ';

        public Element horizontalElement;

        public Element verticalElement;

        private Pos pos;

        public Pos Pos => pos;

        public Cell(Pos pos)
        {
            this.pos = pos;
        }

        public Cell(int row, int col) : this(new Pos(row, col))
        {
            
        }

        public Aligment GetAligmentForElement(Element element)
        {
            return horizontalElement == element ? Aligment.Horizontal : Aligment.Vertical;
        }

        public void Append(char letter, Element element, Aligment aligment)
        {
            this.letter = letter;
            if (aligment == Aligment.Horizontal)
            {
                horizontalElement = element;
            }
            else // Aligment.Vertical
            {
                verticalElement = element;
            }
        }

    }
}
