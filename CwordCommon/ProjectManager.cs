using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;

namespace CwordCommon
{
    public class ProjectManager
    {

        public Project BuildEmptyProject(int rows, int cols)
        {
            var project = new Project();
            project.elements = new List<Element>();
            project.table = new Table(rows, cols);
            return project;
        }

        public Project LoadProjectFromFile(string filePath)
        {
            string textProject = File.ReadAllText(filePath);

            var jProject = JObject.Parse(textProject);


            // elements
            var jElements = (JArray)jProject["elements"];
            var elements = new List<Element>();
            foreach (JObject jElement in jElements)
            {
                elements.Add(new Element(
                    (string)jElement["word"],
                    (string)jElement["question"],
                    (int)jElement["number"]
                ));
            }

            // table
            var jTable = (JObject)jProject["table"];
            var table = new Table((int)jTable["cols"], (int)jTable["rows"]);

            // cell
            var jCells = (JArray)jTable["cells"];
            foreach (JObject jCell in jCells)
            {

                int horizontalElNumber = (int)jCell["horizontal_el_number"];
                int verticalElNumber = (int)jCell["vertical_el_number"];
                int row = (int)jCell["row"];
                int col = (int)jCell["col"];

                var cell = new Cell(row, col);
                cell.letter = char.Parse((string)jCell["letter"]);
                cell.horizontalElement = horizontalElNumber == -1 ? null : elements.Find(element => element.number == horizontalElNumber);
                cell.verticalElement = verticalElNumber == -1 ? null : elements.Find(element => element.number == verticalElNumber);
                table.Set(cell, row, col);
            }

            // project
            var project = new Project();
            project.table = table;
            project.elements = elements;

            return project;
        }

        public void SaveProjectToFile(string filePath, Project project)
        {
            // elements
            var jElements = new JArray();
            foreach (var element in project.elements)
            {
                var jElement = new JObject();
                jElement["word"] = element.word;
                jElement["question"] = element.question;
                jElement["number"] = element.number;
                jElements.Add(jElement);
            }

            // cells
            var jCells = new JArray();
            var table = project.table;
            for (int row = 0; row < table.rows; row++)
            {
                for (int col = 0; col < table.cols; col++)
                {
                    var cell = table.Get(row, col);
                    if (cell.letter == ' ') continue;
                    var jCell = new JObject();
                    jCell["col"] = cell.Pos.col;
                    jCell["row"] = cell.Pos.row;
                    jCell["letter"] = cell.letter.ToString();
                    jCell["horizontal_el_number"] = cell.horizontalElement == null ? -1 : cell.horizontalElement.number;
                    jCell["vertical_el_number"] = cell.verticalElement == null ? -1 : cell.verticalElement.number;
                    jCells.Add(jCell);
                }
            }

            // table
            var jTable = new JObject();
            jTable["cols"] = table.cols;
            jTable["rows"] = table.rows;
            jTable["cells"] = jCells;

            // project
            var jProject = new JObject();
            jProject["elements"] = jElements;
            jProject["table"] = jTable;

            string textProject = jProject.ToString();

            File.WriteAllText(filePath, textProject);
        }
    }
}
