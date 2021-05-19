using CwordCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CwordTester.Forms
{
    public partial class TestForm : Form
    {
        CwordInputController cwordInputController;

        public TestForm()
        {
            InitializeComponent();
        }

        public void LoadNewProject()
        {
            App.drawer = new Drawer(App.project, drawPanel, App.COLS, App.ROWS);
            App.drawer.drawMode = Drawer.DrawMode.Decision;
            App.drawer.Draw();

            var questionTextBuilder = new QuestionTextBuilder(App.project);
            questionTextBox.Text = questionTextBuilder.BuildAndGet();

            cwordInputController = new CwordInputController(App.project, App.drawer, drawPanel);
            KeyPress += cwordInputController.InputKeyboardHandler;
            KeyDown += cwordInputController.SelectionKeyboardMoveHandler;
        }


        private void StopDecideAction(object sender, EventArgs e)
        {
            var reportManager = new ReportManager(App.project, App.config.reportsFolder, App.personName, App.crosswordName);
            var path = reportManager.MakeReportSaveAndGetPath();
            App.drawer.drawMode = Drawer.DrawMode.Errors;
            App.drawer.Draw();
            cwordInputController.locked = true;
            Process.Start(path);
            MessageBox.Show("Прохождение кроссворда завершено. Посмотрите ваш результат и закройте это окно.", "CwordTester");
            App.drawer.FastClear();
            App.testForm.Hide();
            App.startForm.Show();
        }

        private void CloseAction(object sender, FormClosedEventArgs e)
        {
            App.Close();
        }
    }
}
