using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CwordCommon;
using CwordBuilder.Forms;
using CwordCommon.Forms;

namespace CwordBuilder
{

    static class App
    {
        public const int COLS = 25;

        public const int ROWS = 25;

        public static MainForm mainForm;

        public static AboutForm aboutForm;

        public static string projectFilePath = null;

        public static Project project;

        public static ProjectManager projectManager;

        public static Former former;

        public static Drawer drawer;

        public delegate void LoadNewProjectHandler();

        public static event LoadNewProjectHandler OnLoadNewProject;

        static void Init()
        {
            projectManager = new ProjectManager();

            mainForm = new MainForm();
            aboutForm = new AboutForm();

            LoadNewProject(projectManager.BuildEmptyProject(ROWS, COLS));

        }

        public static void LoadNewProject(Project project)
        {
            App.project = project;
            drawer = new Drawer(project, mainForm.drawPanel, ROWS, COLS);
            former = new Former(project.elements, project.table, 400);

            OnLoadNewProject();
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Init();
            Application.Run(mainForm);
        }

        
    }
}
