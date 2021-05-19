using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CwordBuilder
{

    enum Status{
        good = 0,
        bad = 1,
    }

    enum Direction
    {
        right = 0,
        bottom = 1
    }

    class CwordItem
    {
        public char symbol = ' ';
        //public int index = 0;
        public Direction direction = Direction.right;
        /*public List<Question> questions = new List<Question>();*/

    }

    class CwordField
    {
        public int cols;
        public int rows;

        private List<List<CwordItem>> listGrid;

        public CwordField(int rows, int cols)
        {
            SetSize(rows, cols);
        }

        private CwordItem buildDefaultItem()
        {
            return new CwordItem();
        }

        private void PrepareListGrid()
        {
            listGrid = new List<List<CwordItem>>();
            for (int i = 0; i < rows; i++)
            {
                var currRowList = new List<CwordItem>();
                for(int j = 0; j < cols; j++)
                {
                    currRowList.Add(buildDefaultItem());
                }
                listGrid.Add(currRowList);
            }
        }

        public void SetSize(int rows, int cols)
        {
            this.cols = cols;
            this.rows = rows;
            PrepareListGrid();
        }

        public CwordItem Get(int row, int col)
        {
            return listGrid[row][col];
        }
    }

    class Generator
    {
        private int cols = 25;
        private int rows = 25;
        private int cubeLen = 20;

        CwordField cwordField;
        Graphics graphics;

        // Генерирует, Возвращает результат в questions, отрисовывает
        public Status GenerateAndDraw(Questions questions, Graphics graphics)
        {
            cwordField = new CwordField(rows, cols);
            this.graphics = graphics;

            if(PlaceQuestions(questions) == Status.bad) return Status.bad;
           
            Draw();
            return Status.good;
        }

        // функция которая располагает слова на поле кроссворда
        private Status PlaceQuestions(Questions questions)
        {
            var shuffleQuestions = questions.GetShuffleQuestions();

            if(shuffleQuestions.Count > 0)
                PutQuestionToField(shuffleQuestions[0], Direction.right, 12, 5);

            for(int k = 1; k < shuffleQuestions.Count; k++)
            {
                var question = shuffleQuestions[k];
                var word = question.WordText;

                int maxBall = 0;
                Question maxBallCuestion = null;
                Direction maxBallDirection = Direction.bottom;
                int maxBallRow = 0;
                int maxBallCol = 0;

                // горизонталбная проверка
                for (int i = 0; i < rows; i++)
                {
                    for(int j = 0; j < cols - word.Length; j++)
                    {
                        int ball = GetPlaceBall(question, Direction.right, i, j);
                        if(ball > maxBall)
                        {
                            maxBall = ball;
                            maxBallCuestion = question;
                            maxBallDirection = Direction.right;
                            maxBallRow = i;
                            maxBallCol = j;
                        }
                    }
                }

                // вертикальная проверка
                for (int i = 0; i < rows - word.Length; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        int ball = GetPlaceBall(question, Direction.bottom, i, j);
                        if (ball > maxBall)
                        {
                            maxBall = ball;
                            maxBallCuestion = question;
                            maxBallDirection = Direction.bottom;
                            maxBallRow = i;
                            maxBallCol = j;
                        }
                    }
                }

                // нашли ли мы для слова нормальный балл
                if (maxBall > 0)
                    PutQuestionToField(maxBallCuestion, maxBallDirection, maxBallRow, maxBallCol);
                else
                    return Status.bad;

            }

            return Status.good;

        }

        // получить оценку на сколько эффективно располагать слово здесь
        private int GetPlaceBall(Question question, Direction direction, int row, int col)
        {
            int ballCounter = 0;

            string word = question.WordText;
            int stepCol = direction == Direction.right ? 1 : 0;
            int stepRow = direction == Direction.bottom ? 1 : 0;

            bool badBall = false;

            // проверка на то что слово не перезапишет ни одно слово если его добавить сюда
            for (int i = 0; i < word.Length; i++)
            {
                CwordItem currItem = cwordField.Get(row + i * stepRow, col + i * stepCol);
                if (currItem.symbol != word[i] && currItem.symbol != ' ') badBall = true;

            }

            // проверка на то что перед и после слова пусто
            if (direction == Direction.right)
            {
                // слева
                if (col > 0 && cwordField.Get(row, col - 1).symbol != ' ') badBall = true;
                // справа
                if (col < cols - 1 && cwordField.Get(row, col + word.Length).symbol != ' ') badBall = true;
            }

            if (direction == Direction.bottom)
            {
                // сверху
                if (row > 0 && cwordField.Get(row - 1, col).symbol != ' ') badBall = true;
                // снизу
                if (row < rows - 1 && cwordField.Get(row + word.Length, col).symbol != ' ') badBall = true;
            }


            // проверка на то что по бокам от слова пусто кроме мест перекрестков
            for (int i = 0; i < word.Length; i++)
            {
                CwordItem currItem = cwordField.Get(row + i * stepRow, col + i * stepCol);
                if(currItem.symbol == ' ')
                {
                    if (direction == Direction.right)
                    {
                        if (row > 0 && cwordField.Get(row - 1, col + i).symbol != ' ') badBall = true;
                        if (row < rows - 1 && cwordField.Get(row + 1, col + i).symbol != ' ') badBall = true;
                    }

                    if (direction == Direction.bottom)
                    {
                        if (col > 0 && cwordField.Get(row + i, col - 1).symbol != ' ') badBall = true;
                        if (col < cols - 1 && cwordField.Get(row + i, col + 1).symbol != ' ') badBall = true;
                    }
                }
            }

            if (badBall) return 0;

            // повышаем балл в зависимости от колва перечений
            for (int i = 0; i < word.Length; i++)
            {
                CwordItem currItem = cwordField.Get(row + i * stepRow, col + i * stepCol);
                if (currItem.symbol == word[i])
                    ballCounter++;

            }

            return ballCounter;
        }

        private void PutQuestionToField(Question question, Direction direction, int row, int col)
        {
            string word = question.WordText;
            int stepCol = direction == Direction.right ? 1 : 0;
            int stepRow = direction == Direction.bottom ? 1 : 0;
            for (int i = 0; i < word.Length; i++)
            {
                CwordItem currItem = cwordField.Get(row + i * stepRow, col + i * stepCol);
                currItem.symbol = word[i];
                currItem.questions.Add(question);
                currItem.direction = direction;

                question.StartPos = new int[] {row, col};
                question.EndPos = new int[] { row + i * stepRow, col + i * stepCol };
            }
        }

        public void Draw()
        {
            graphics.Clear(SystemColors.Control);

            Pen blackPen = new Pen(Color.Black, 1);

            Font font = new Font(FontFamily.GenericSansSerif, 10);
            Font indexFont = new Font(FontFamily.GenericSansSerif, 6);
            Brush brush = new SolidBrush(Color.Blue);
            Brush indexBrush = new SolidBrush(Color.Red);

            for (int i = 0; i < rows; i++){
                for (int j = 0; j < cols; j++)
                {
                    int offsetY = cubeLen * i + 10;
                    int offsetX = cubeLen * j + 10;
                    CwordItem currItem = cwordField.Get(i, j);
                    if (currItem.symbol != ' ')
                    {
                        graphics.DrawRectangle(blackPen, offsetX, offsetY, cubeLen, cubeLen);
                        graphics.DrawString(currItem.symbol.ToString(), font, brush, offsetX + 5, offsetY + 1);

                        //if(currItem.index > 0)
                        //    graphics.DrawString(currItem.index.ToString(), indexFont, indexBrush, offsetX + 1, offsetY + 1);
                    }
                }
            }
        }

    }
}
