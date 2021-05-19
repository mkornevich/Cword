using CwordCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CwordBuilder.Forms
{
    public partial class MainForm : Form
    {

        private List<Element> elements;

        public MainForm()
        {

            InitializeComponent();
            App.OnLoadNewProject += LoadNewProjectListener;
        }

        private void LoadNewProjectListener()
        {
            elements = App.project.elements;
            SyncElementListBox();
            App.drawer.Draw();
            UpdateFormText(false);
            elementsListBox.SelectedIndex = elementsListBox.Items.Count - 1;
        }

        private void CreateNewProjectAction(object sender, EventArgs e)
        {
            App.projectFilePath = null;
            App.LoadNewProject(App.projectManager.BuildEmptyProject(App.ROWS, App.COLS));
        }

        private void OpenProjectAction(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                App.projectFilePath = openFileDialog.FileName;
                App.LoadNewProject(App.projectManager.LoadProjectFromFile(openFileDialog.FileName));
            }
        }
        private void SaveProjectAction(object sender, EventArgs e)
        {
            if (App.projectFilePath != null)
            {
                App.projectManager.SaveProjectToFile(App.projectFilePath, App.project);
                UpdateFormText(false);
            }
            else
            {
                SaveAsProjectAction(sender, e);
            }

        }

        private void SaveAsProjectAction(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                App.projectFilePath = saveFileDialog.FileName;
                App.projectManager.SaveProjectToFile(saveFileDialog.FileName, App.project);
                UpdateFormText(false);
            }
        }

        private void AddNewElementAction(object sender, EventArgs e)
        {
            var newWordIndex = elements.Count + 1;

            while (elements.Exists(element => element.word == "новое" + newWordIndex)) 
                newWordIndex++;

            elements.Add(new Element("новое" + newWordIndex, "", elements.Count + 1));
            SyncElementListBox();
            elementsListBox.SelectedIndex = elements.Count - 1;
            wordTextBox.Focus();
            UpdateFormText(true);
            ClearCrossword();
        }

        private void RemoveSelectedElementAction(object sender, EventArgs e)
        {
            var index = elementsListBox.SelectedIndex;
            if (index >= 0)
            {
                elements.RemoveAt(index);

                // перерастановка номеров к вопросам
                for (int i = 0; i < elements.Count; i++)
                    elements[i].number = i + 1;

                SyncElementListBox();
                UpdateFormText(true);
                ClearCrossword();
            }
        }

        private void StoreSelectedElementAction(object sender, EventArgs e)
        {

            var index = elementsListBox.SelectedIndex;
            if (index >= 0 && index < elements.Count)
            {
                var element = elements[index];

                if (element.word != wordTextBox.Text)
                {
                    var validator = new InputWordValidator(elements);
                    if (!validator.Validate(wordTextBox.Text))
                    {
                        MessageBox.Show("Введенное слово \"" + wordTextBox.Text + "\" не соответствует следующим требованиям:" + validator.Errors,
                            "Ошибка при обновлении слова.");
                        return;
                    }
                }

                element.word = wordTextBox.Text;
                element.question = questionTextBox.Text;
                SyncElementListBox();
                UpdateFormText(true);
                ClearCrossword();
            }
        }

        private void LoadSelectedElementAction(object sender, EventArgs e)
        {
            var index = elementsListBox.SelectedIndex;
            if (index >= 0 && index < elements.Count)
            {
                var question = elements[index];
                wordTextBox.Text = question.word;
                questionTextBox.Text = question.question;
            }
        }

        private void ShowAboutFormAction(object sender, EventArgs e)
        {
            App.aboutForm.ShowDialog();
        }


        private void FormAndDrawAction(object sender, EventArgs e)
        {
            if (App.former.Form() == Former.FormStatus.Success)
            {
                infoLbl.Text = "Кроссворд был успешно сгенерирован.";
                App.drawer.Draw();
            }
            else
            {
                infoLbl.Text = "НЕ УДАЛОСЬ сгенерировать кроссворд!";
                App.drawer.FastClear();
            }
            UpdateFormText(true);
        }

        private void SyncElementListBox()
        {
            var prevSelIndex = elementsListBox.SelectedIndex;
            elementsListBox.Items.Clear();
            foreach (var element in elements)
                elementsListBox.Items.Add(element.word);

            if (prevSelIndex < elementsListBox.Items.Count)
                elementsListBox.SelectedIndex = prevSelIndex;
            else
                elementsListBox.SelectedIndex = elementsListBox.Items.Count - 1;

            if (elements.Count == 0)
            {
                wordTextBox.Enabled = false;
                questionTextBox.Enabled = false;
                wordTextBox.Text = "";
                questionTextBox.Text = "";
            }
            else
            {
                wordTextBox.Enabled = true;
                questionTextBox.Enabled = true;
            }

        }

        private void UpdateFormText(bool isProjectModified)
        {
            Text = "CwordBuilder - " + (App.projectFilePath ?? "Новый проект (несохраненный)") + " " + (isProjectModified ? "*" : "");
        }

        private void ClearCrossword()
        {
            App.project.table.Clear();
            App.drawer.FastClear();
            infoLbl.Text = "Кроссворд УДАЛЕН так как его данные изменены!";
        }
    }
}
