using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cword.Generator.Common
{
    class Pos
    {
        public int col;

        public int row;

        public Pos(int row, int col)
        {
            this.col = col;
            this.row = row;
        }
    }
}
