using CwordCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwordTester
{
    class ReportManager
    {
        Project project;

        string reportsFolder;

        string personName;

        string crosswordName;

        public ReportManager(Project project, string reportsFolder, string personName, string crosswordName)
        {
            this.project = project;
            this.reportsFolder = reportsFolder;
            this.personName = personName;
            this.crosswordName = crosswordName;
        }

        public string MakeReportSaveAndGetPath()
        {
            string report = MakeReport();
            var dateTimeStr = DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss");
            var fileName = string.Format("{0}/{1} - {2}.txt", reportsFolder, dateTimeStr, personName);
            File.WriteAllText(fileName, report);
            return fileName;
        }

        private string MakeReport()
        {
            var dateTimeStr = DateTime.Now.ToString("dd.MM.yyyy - HH:mm:ss");
            int elementCountAll = project.elements.Count;
            int errorElementCount = 0;
            

            var errorElements = new StringBuilder();
            foreach (var element in project.elements)
            {
                List<Cell> cells = project.table.GetElementCellsInfo(element).Cells;
                bool hasError = false;
                string answerWord = "";
                foreach (var cell in cells)
                {
                    if (cell.answerLetter != cell.letter) hasError = true;
                    answerWord += cell.answerLetter == ' '? '_' : cell.answerLetter;
                }

                if (hasError)
                {
                    errorElementCount++;
                    errorElements.Append(string.Format("{0} ) {1}\r\nВерный ответ: {2}\r\nВаш ответ: {3}\r\n\r\n", 
                        element.number, element.question, element.word, answerWord));
                }
            }

            int successElementCount = elementCountAll - errorElementCount;
            int percent = (int)Math.Round(100f / elementCountAll * successElementCount);


            var output = new StringBuilder();
            output.Append(string.Format("Название кроссворда: {0}\r\n", crosswordName));
            output.Append(string.Format("ФИО: {0}\r\n", personName));
            output.Append(string.Format("Дата: {0}\r\n", dateTimeStr));
            output.Append(string.Format("Всего вопросов: {0}\r\n", elementCountAll));
            output.Append(string.Format("Успешно отвеченных вопросов: {0}\r\n", successElementCount));
            output.Append(string.Format("Кол-во баллов в процентах: {0}\r\n", percent));
            output.Append("\r\n=== Неверно отвеченные вопросы ===\r\n");
            output.Append(errorElements);

            return output.ToString();
        }
    }
}
