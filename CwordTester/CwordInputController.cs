using CwordCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CwordTester
{
    class CwordInputController
    {
        Panel drawPanel;

        Drawer drawer;

        Project project;

        public bool locked;

        public CwordInputController(Project project, Drawer drawer, Panel drawPanel)
        {
            this.drawPanel = drawPanel;
            this.drawer = drawer;
            this.project = project;
            locked = false;

            drawPanel.MouseMove += MouseHandler;
            drawPanel.MouseDown += MouseHandler;

        }

        void MouseHandler(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || locked) return;

            int row = (e.Y - 10) / Drawer.CUBE_LEN;
            int col = (e.X - 10) / Drawer.CUBE_LEN;
            if (!IsCellFilled(row, col)) return;
            App.project.selectedCell = new Pos(row, col);
            drawPanel.Focus();
            drawer.Draw();
        }

        public void InputKeyboardHandler(object sender, KeyPressEventArgs e)
        {
            if (project.selectedCell == null || locked) return;
            string inLetter = e.KeyChar.ToString();
            var cell = project.table.Get(project.selectedCell);
            if (!Regex.IsMatch(inLetter, @"^[а-яёa-z1-9]$")) return;
            cell.answerLetter = char.Parse(inLetter);
            drawer.Draw();
        }

        public void SelectionKeyboardMoveHandler(object sender, KeyEventArgs e)
        {
            if (project.selectedCell == null || locked) return;

            var newSelectedCell = new Pos(project.selectedCell);

            switch (e.KeyCode)
            {
                case Keys.Right:
                    newSelectedCell.col++;
                    break;
                case Keys.Left:
                    newSelectedCell.col--;
                    break;
                case Keys.Up:
                    newSelectedCell.row--;
                    break;
                case Keys.Down:
                    newSelectedCell.row++;
                    break;
                default:
                    return;
            }

            if (!IsCellFilled(newSelectedCell.row, newSelectedCell.col)) return;

            project.selectedCell = newSelectedCell;
            drawer.Draw();
        }

        bool IsCellFilled(int row, int col)
        {
            if (row < 0 || col < 0 || row > project.table.rows - 1 || col > project.table.cols - 1) return false;

            var cell = project.table.Get(row, col);
            return cell.letter != ' ';
        }
    }
}
