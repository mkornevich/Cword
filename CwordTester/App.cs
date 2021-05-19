using CwordCommon;
using CwordCommon.Forms;
using CwordTester.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CwordTester
{
    static class App
    {

        public static string CONFIG_FILE = Application.StartupPath + "\\config.json";
        public const int COLS = 25;
        public const int ROWS = 25;

        public static StartForm startForm;
        public static TestForm testForm;
        public static AboutForm aboutForm;

        public static Config config;
        public static SelectProjectManager selectProjectManager;
        public static Drawer drawer;

        public static Project project;
        public static string personName;
        public static string crosswordName;

        private static void Init()
        {
            config = Config.Load(CONFIG_FILE);
            selectProjectManager = new SelectProjectManager(config.crosswordsFolder);

            startForm = new StartForm();
            testForm = new TestForm();
            aboutForm = new AboutForm();
        }

        public static void Close()
        {
            Application.Exit();
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Init();
            Application.Run(startForm);
        }
    }
}
