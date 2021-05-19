using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CwordTester.Forms
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            crosswordsFolderTextBox.Text = App.config.crosswordsFolder;
            reportsFolderTextBox.Text = App.config.reportsFolder;
            LoadCrosswords();
            
        }

        private void LoadCrosswords()
        {
            if (!Directory.Exists(App.config.crosswordsFolder))
            {
                MessageBox.Show("Не удалось загрузить папку с кроссвордами так как такой папки не существует. Измените папку с кроссвордами.", "Ошибка загрузки списка кроссвордов!");
                return;
            }
            App.selectProjectManager.crosswordsFolder = App.config.crosswordsFolder;
            App.selectProjectManager.LoadPatches();
            crosswordListBox.Items.Clear();
            crosswordListBox.Items.AddRange(App.selectProjectManager.GetShortNames());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void OpenAboutFormAction(object sender, EventArgs e)
        {
            App.aboutForm.ShowDialog();
        }

        private void StartDecideAction(object sender, EventArgs e)
        {
            if (personNameTextBox.Text.Length < 4)
            {
                MessageBox.Show("Слишком короткое ФИО, введите ФИО длиной от 4 символов.", "Некорректное ФИО!");
                return;
            }

            if (crosswordListBox.SelectedIndex < 0)
            {
                MessageBox.Show("Укажите кроссворд для прохождения.", "Кроссворд не выбран!");
                return;
            }

            if (!Directory.Exists(App.config.reportsFolder))
            {
                MessageBox.Show("Укажите существующую папку для сохранения результатов.", "Неверно указана папка для сохранения результатов!");
                return;
            }

            App.personName = personNameTextBox.Text;
            App.crosswordName = crosswordListBox.SelectedItem.ToString();
            App.project = App.selectProjectManager.GetProjectByShortName(App.crosswordName);
            App.startForm.Hide();
            App.testForm.Show();
            App.testForm.LoadNewProject();
        }

        private void ChangeCrosswordsFolderAction(object sender, EventArgs e)
        {
            folderDialog.Description = "Укажите папку в которой распологаются кроссворды с расширением .cwd";
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                crosswordsFolderTextBox.Text = folderDialog.SelectedPath;
                App.config.crosswordsFolder = folderDialog.SelectedPath;
                App.config.Store();
                LoadCrosswords();
            }
        }

        private void ChangeReportsFolderAction(object sender, EventArgs e)
        {
            folderDialog.Description = "Укажите папку в которорую необходимо сохранять отчеты о прохождении кроссвордов.";
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                reportsFolderTextBox.Text = folderDialog.SelectedPath;
                App.config.reportsFolder = folderDialog.SelectedPath;
                App.config.Store();
            }
        }

        private void CloseAction(object sender, FormClosedEventArgs e)
        {
            App.Close();
        }
    }
}
