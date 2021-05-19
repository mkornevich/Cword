using CwordCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwordTester
{
    class SelectProjectManager
    {
        public string crosswordsFolder;

        public string[] cwdFullPatches;

        private ProjectManager projectManager;

        public SelectProjectManager(string crosswordsFolder)
        {
            projectManager = new ProjectManager();
            this.crosswordsFolder = crosswordsFolder;
        }

        public void LoadPatches()
        {
            cwdFullPatches = Directory.GetFiles(crosswordsFolder, "*.cwd"); 
        }

        public string[] GetShortNames()
        {
            var names = new string[cwdFullPatches.Length];
            for (int i = 0; i < cwdFullPatches.Length; i++)
            {
                names[i] = Path.GetFileNameWithoutExtension(cwdFullPatches[i]);
            }
            return names;
        }

        public Project GetProjectByShortName(string shortName)
        {
            return projectManager.LoadProjectFromFile(string.Format("{0}/{1}.cwd", crosswordsFolder, shortName));
        }
    }
}
