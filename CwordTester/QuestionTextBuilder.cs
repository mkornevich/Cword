using CwordCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwordTester
{
    class QuestionTextBuilder
    {
        Project project;

        public QuestionTextBuilder(Project project)
        {
            this.project = project;
        }

        public string BuildAndGet()
        {
            var output = new StringBuilder();

            output.Append("\r\n=== Вопросы по горизонтали: ===\r\n\r\n");

            foreach (var element in GetElementsByAligment(Aligment.Horizontal))
            {
                output.Append(string.Format(" {0} ) {1}\r\n\r\n", element.number, element.question));
            }

            output.Append("=== Вопросы по вертикали: ===\r\n\r\n");

            foreach (var element in GetElementsByAligment(Aligment.Vertical))
            {
                output.Append(string.Format(" {0} ) {1}\r\n\r\n", element.number, element.question));
            }

            return output.ToString();
        }

        List<Element> GetElementsByAligment(Aligment aligment)
        {
            return project.elements.FindAll(element => project.table.GetElementCellsInfo(element).GetAligment() == aligment);
        }
    }
}
