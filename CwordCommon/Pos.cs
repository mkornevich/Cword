using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwordCommon
{
    public class Pos
    {
        public int row;

        public int col;

        public Pos(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public Pos(Pos pos)
        {
            row = pos.row;
            col = pos.col;
        }
    }
}
