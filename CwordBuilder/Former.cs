using CwordCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwordBuilder
{
    class Former
    {
        private Table table;

        private List<Element> elements;

        private int repeatCount;

        public enum FormStatus { Success, Fail };

        public Former(List<Element> elements, Table table, int repeatCount)
        {
            this.elements = elements;
            this.table = table;
            this.repeatCount = repeatCount;
        }

        public FormStatus Form()
        {
            

            for (int i = 0; i < repeatCount; i++)
            {
                table.Clear();
                if (TryArrangeElements() == FormStatus.Success)
                    return FormStatus.Success;
            }

            return FormStatus.Fail;
        }

        // функция которая располагает слова на поле кроссворда
        private FormStatus TryArrangeElements()
        {
            if (elements.Count == 0)
                return FormStatus.Fail;

            var shuffleElements = new List<Element>(elements);
            Utils.ShuffleList(shuffleElements);

            PlaceElementToTable(shuffleElements[0], Aligment.Horizontal, 5, 3);

            for (int elementIndex = 1; elementIndex < shuffleElements.Count; elementIndex++)
            {
                var element = shuffleElements[elementIndex];
                var word = element.word;

                int maxRating = 0;
                Element maxRatingElement = null;
                Aligment maxRatingAligment = Aligment.Vertical;
                Pos maxRatingPos = null;

                // горизонталбная проверка
                for (int row = 0; row < table.rows; row++)
                {
                    for (int col = 0; col < table.cols - word.Length; col++)
                    {
                        int rating = GetPlaceRating(element, Aligment.Horizontal, row, col);
                        if (rating > maxRating)
                        {
                            maxRating = rating;
                            maxRatingElement = element;
                            maxRatingAligment = Aligment.Horizontal;
                            maxRatingPos = new Pos(row, col);
                        }
                    }
                }

                // вертикальная проверка
                for (int row = 0; row < table.rows - word.Length; row++)
                {
                    for (int col = 0; col < table.cols; col++)
                    {
                        int rating = GetPlaceRating(element, Aligment.Vertical, row, col);
                        if (rating > maxRating)
                        {
                            maxRating = rating;
                            maxRatingElement = element;
                            maxRatingAligment = Aligment.Vertical;
                            maxRatingPos = new Pos(row, col);
                        }
                    }
                }

                // нашли ли мы для слова нормальный балл
                if (maxRating > 0)
                    PlaceElementToTable(maxRatingElement, maxRatingAligment, maxRatingPos);
                else
                    return FormStatus.Fail;

            }

            return FormStatus.Success;
        }

        // получить оценку на сколько эффективно располагать слово здесь
        private int GetPlaceRating(Element element, Aligment aligment, int row, int col)
        {
            int ratingCounter = 0;

            string word = element.word;
            int stepCol = aligment == Aligment.Horizontal ? 1 : 0;
            int stepRow = aligment == Aligment.Vertical ? 1 : 0;

            // проверка на то что перед и после слова пусто
            if (aligment == Aligment.Horizontal)
            {
                // слева
                if (col > 0 && table.Get(row, col - 1).letter != ' ') return 0;
                // справа
                if (col < table.cols - 1 && table.Get(row, col + word.Length).letter != ' ') return 0;
            }

            if (aligment == Aligment.Vertical)
            {
                // сверху
                if (row > 0 && table.Get(row - 1, col).letter != ' ') return 0;
                // снизу
                if (row < table.rows - 1 && table.Get(row + word.Length, col).letter != ' ') return 0;
            }
            
            // проверка на то что слово не перезапишет ни одно слово если его добавить сюда
            for (int i = 0; i < word.Length; i++)
            {
                var cell = table.Get(row + i * stepRow, col + i * stepCol);
                if (cell.letter != word[i] && cell.letter != ' ')
                    return 0;
            }

            // проверка на то что по бокам от слова пусто кроме мест перекрестков
            for (int i = 0; i < word.Length; i++)
            {
                var cell = table.Get(row + i * stepRow, col + i * stepCol);
                if (cell.letter == ' ')
                {
                    if (aligment == Aligment.Horizontal)
                    {
                        if (row > 0 && table.Get(row - 1, col + i).letter != ' ') return 0;
                        if (row < table.rows - 1 && table.Get(row + 1, col + i).letter != ' ') return 0;
                    }

                    if (aligment == Aligment.Vertical)
                    {
                        if (col > 0 && table.Get(row + i, col - 1).letter != ' ') return 0;
                        if (col < table.cols - 1 && table.Get(row + i, col + 1).letter != ' ') return 0;
                    }
                }
            }

            // повышаем балл в зависимости от колва перечений
            for (int i = 0; i < word.Length; i++)
            {
                var cell = table.Get(row + i * stepRow, col + i * stepCol);
                if (cell.letter == word[i])
                    ratingCounter++;

            }

            return ratingCounter;
        }

        private void PlaceElementToTable(Element element, Aligment aligment, int row, int col)
        {
            string word = element.word;
            int stepCol = aligment == Aligment.Horizontal ? 1 : 0;
            int stepRow = aligment == Aligment.Vertical ? 1 : 0;
            for (int i = 0; i < word.Length; i++)
            {
                var cell = table.Get(row + i * stepRow, col + i * stepCol);
                cell.letter = word[i];

                if (aligment == Aligment.Horizontal)
                    cell.horizontalElement = element;
                else           // Aligment.Vertical
                    cell.verticalElement = element;
            }
        }

        private void PlaceElementToTable(Element element, Aligment aligment, Pos pos)
        {
            PlaceElementToTable(element, aligment, pos.row, pos.col);
        }

    }
}
